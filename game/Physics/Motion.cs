using System;
using System.Collections.Generic;
using GameDevProject.GameObjects.World;
using Microsoft.Xna.Framework;

namespace GameDevProject.Physics
{
    public class Motion
    {
        private GameObject gameObject;
        private Vector2 currentPosition;
        private Vector2 nextPosition;
        private bool isTouchingGround;

        private Force gravity = new Gravity();
        private Vector2 gravitationalPull;

        //private List<GameObject> gameObjects = LevelManager.gameObjects (static value) - player
        private List<Tile> gameObjects;


        public Motion(GameObject gameObject, List<Tile> gameObjects)
        {
            gravitationalPull = gravity.Direction;

            this.gameObject = gameObject;
            currentPosition = gameObject.Position;

            this.gameObjects = gameObjects;
        }

        public void Perform(GameTime gameTime, Vector2 forceGO)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 100;

            gravitationalPull += gravity.Acceleration * elapsedTime;

            nextPosition += forceGO;
            nextPosition += gravitationalPull * elapsedTime;

            nextPosition = CollisionPrevention();
            gameObject.Position = nextPosition;

            if (isTouchingGround)
            {
                gravitationalPull = gravity.Direction;
                elapsedTime = 0;
            }
        }

        //TEMP
        public Vector2 CollisionPrevention()
        {
            List<Tile> tiles = GetCollidingTiles(new Rectangle((int)nextPosition.X, (int)nextPosition.Y, 32, 64));

            float x = nextPosition.X;
            float y = nextPosition.Y;

            isTouchingGround = false;

            if (tiles.Count > 0)
            {
                foreach (Tile tile in tiles)
                {
                    if (tile.Position.Y > nextPosition.Y)
                    {
                        y = tile.Position.Y - 64;
                        isTouchingGround = true;
                    }
                    else if (tile.Position.Y < nextPosition.Y)
                    {
                        y = tile.Position.Y + 32;
                    }
                    else
                    {
                        if (tile.Position.X > nextPosition.X)
                        {
                            x = tile.Position.X - 33;
                        }
                        if (tile.Position.X < nextPosition.X)
                        {
                            x = tile.Position.X + 33;
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

/*if (direction != new Vector2(0,0))
            //{
                Vector2 nextPosition = position;
                if (direction.X != 0)
                {
                    nextPosition += (direction * runVelocity);

                    //position += direction * runVelocity;
                }
                if (direction.Y != 0) //<
                {
                    nextPosition += (direction * jumpVelocity);

                    //position += direction * jumpVelocity;
                    //isTouchingGround = false;
                }

            gravVelocity += grav * elapsedTime;
            nextPosition += gravVelocity * elapsedTime;


            if (GetCollidingTiles(new Rectangle((int)nextPosition.X, (int)nextPosition.Y, 32, 64)).Count > 0)
                {
                    //collider.OnCollisionEnter();
                    if (floorTile != null) position = new Vector2(nextPosition.X, floorTile.position.Y - 64);
                    gravVelocity = gravVelocityPointer;
                    elapsedTime = 0;
                }
                else
                {
                    position = nextPosition;
                    direction = new Vector2(0, -1);
                }*/


/*float x = Player.position.X;
            float y = Player.position.Y;

            if (tile.position.Y > Player.position.Y)
            {
                //Player.position = new Vector2(Player.position.X, tile.position.Y - 64);
                y = tile.position.Y - Player.CollisionRectangle.Height;
                Player.isTouchingGround = true;

                //if (tile.position.X > Player.position.X + 32 || tile.position.X + 32 < Player.position.X)
                //    Player.isTouchingGround = false;
                //else Player.isTouchingGround = true;
            }
            else if (tile.position.Y < Player.position.Y)
            {
                //Player.position = new Vector2(Player.position.X, tile.position.Y + 32);
                y = tile.position.Y + 32;
            }
            else
            {
                if (tile.position.X > Player.position.X)
                {
                    //Player.position = new Vector2(tile.position.X - 64, Player.position.Y);
                    x = tile.position.X - 33;
                }
                if (tile.position.X < Player.position.X)
                {
                    //Player.position = new Vector2(tile.position.X + 64, Player.position.Y);
                    x = tile.position.X + 33;
                }
            }

            Player.position = new Vector2(x, y);*/
