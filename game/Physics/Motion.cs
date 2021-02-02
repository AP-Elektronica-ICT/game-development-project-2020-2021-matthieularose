using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameDevProject.GameObjects.World;
using GameDevProject.Input;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;

namespace GameDevProject.Physics
{
    public class Motion
    {
        private GameObject gameObject;
        private Vector2 nextPosition;
        private bool isTouchingGround;

        private Force gravity = new Gravity();
        private Vector2 gravitationalPull;

        private List<Tile> gameObjects;

        public Motion(GameObject gameObject, List<Tile> gameObjects)
        {
            gravitationalPull = gravity.Direction;

            this.gameObject = gameObject;

            this.gameObjects = gameObjects;
        }

        public void Perform(GameTime gameTime, Vector2 forceGO)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 100;

            gravitationalPull += gravity.Acceleration * elapsedTime;

            nextPosition = gameObject.Position;
            nextPosition += gravitationalPull * elapsedTime;
            nextPosition += forceGO;

            nextPosition = CollisionPrevention(GetCollidingTiles(new Rectangle((int)nextPosition.X, (int)nextPosition.Y, 38, 64)));
            gameObject.Position = nextPosition;

            if (isTouchingGround)
            {
                gravitationalPull = gravity.Direction;
            }
        }

        public Vector2 CollisionPrevention(List<Tile> tiles)
        {
            float x = nextPosition.X;
            float y = nextPosition.Y;

            float playerLeft = nextPosition.X;
            float playerRight = nextPosition.X + 38;
            float playerBottom = nextPosition.Y + 64;

            isTouchingGround = false;

            if (tiles.Count > 0)
            {
                foreach (Tile tile in tiles)
                {
                    float tileTop = tile.Position.Y;
                    float tileBottom = tile.Position.Y + 32;
                    float tileLeft = tile.Position.X;
                    float tileRight = tile.Position.X + 32;

                    if (playerRight - 5 > tileLeft && playerLeft + 5 < tileRight)
                    {
                        if (tile.Position.Y > nextPosition.Y)
                        {
                            if (playerBottom > tileTop)
                            {
                                y = tileTop - 64;
                                isTouchingGround = true;
                            }
                        }
                        else if (tile.Position.Y < nextPosition.Y)
                        {
                            y = tileBottom;
                        }
                    }
                }

                if (!isTouchingGround)
                {
                    foreach (Tile tile in tiles)
                    {
                        float tileTop = tile.Position.Y;
                        float tileBottom = tile.Position.Y + 32;
                        float tileLeft = tile.Position.X;
                        float tileRight = tile.Position.X + 32;

                        if (playerRight - 5 < tileLeft)
                        {
                            x = tileLeft - 38;
                        }
                        if (playerLeft + 5 > tileRight)
                        {
                            x = tileRight;
                        }
                    }
                }
            }

            return new Vector2(x, y);
        }

        public List<Tile> GetCollidingTiles(Rectangle nextRectangle)
        {
            Collision collision = new Collision();
            List<Tile> tiles = new List<Tile>();

            foreach (Tile tile in gameObjects)
            {
                if (collision.GameObject(nextRectangle, tile) != null)
                {
                    tiles.Add(tile);
                }
            }
            return tiles;
        }
    }
}