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
        private Vector2 currentPosition;
        private Vector2 nextPosition;
        private bool isTouchingGround;

        private Force gravity = new Gravity();
        private Vector2 gravitationalPull;

        //private List<GameObject> gameObjects = LevelManager.gameObjects (static value) - player
        private List<Tile> gameObjects;
        private IReadInput inputReader;


        public Motion(GameObject gameObject, List<Tile> gameObjects)
        {
            gravitationalPull = gravity.Direction;

            this.gameObject = gameObject;
            currentPosition = gameObject.Position;

            this.gameObjects = gameObjects;

            inputReader = new KeyboardInput();
        }

        public void Perform(GameTime gameTime, Vector2 forceGO)
        {
            //isTouchingGround = false;

            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 100;

            gravitationalPull += gravity.Acceleration * elapsedTime;

            nextPosition = gameObject.Position;
            nextPosition += gravitationalPull * elapsedTime;
            nextPosition += forceGO;

            //List<Tile> tiles = GetCollidingTiles(new Rectangle((int)nextPosition.X, (int)nextPosition.Y, 38, 64));

            nextPosition = CollisionPrevention(GetCollidingTiles(new Rectangle((int)nextPosition.X, (int)nextPosition.Y, 38, 64)));
            gameObject.Position = nextPosition;

            //Debug.WriteLine(isTouchingGround);
            /*
             * TODO: 
             * jump and run force
             * Cooldown for jump
             * Fix isTouchingGround
             */

            if (isTouchingGround)
            {
                gravitationalPull = gravity.Direction;
                elapsedTime = 0;
            }
        }

        //TEMP
        public Vector2 CollisionPrevention(List<Tile> tiles)
        {
            float x = nextPosition.X;
            float y = nextPosition.Y;

            float playerLeft = nextPosition.X;
            float playerRight = nextPosition.X + 38;
            float playerTop = nextPosition.Y;
            float playerBottom = nextPosition.Y + 64;

            float collisionX = nextPosition.X;
            float collisionY = nextPosition.Y;


            isTouchingGround = false;

            if (tiles.Count > 0)
            {
                foreach (Tile tile in tiles)
                {
                    float tileTop = tile.Position.Y;
                    float tileBottom = tile.Position.Y + 32;
                    float tileLeft = tile.Position.X;
                    float tileRight = tile.Position.X + 32;


                    //if (tile.tileType == TileType.Floor)
                    //{
                    //    if (playerBottom > tileTop)
                    //    {
                    //        y = tileTop - 64;
                    //        isTouchingGround = true;
                    //    }
                    //    else if (playerTop < tileBottom)
                    //    {
                    //        y = tileBottom;
                    //    }
                    //}
                    //else if (tile.tileType == TileType.Wall)
                    //{
                    //    if (playerRight > tileLeft)
                    //    {
                    //        x = tileLeft - 39;
                    //    }
                    //    if (playerLeft < tileRight)
                    //    {
                    //        x = tileRight + 1;
                    //    }
                    //}


                    //if ((playerRight > tileLeft && playerRight < tileRight) || (playerLeft > tileLeft && playerLeft < tileRight))
                    //{
                    //    if (playerBottom > tileTop)
                    //    {
                    //        y = tileTop - 64;
                    //        isTouchingGround = true;
                    //    }
                    //}

                    if (playerRight - 5 > tileLeft && playerLeft + 5 < tileRight)
                    {
                        //if (playerBottom > tileTop)
                        //{
                        //    y = tileTop - 64;
                        //    isTouchingGround = true;
                        //}
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

                    //else
                    //{
                    //    if (playerRight > tileLeft)
                    //    {
                    //        x = tileLeft - 38;
                    //    }
                    //    if (playerLeft < tileRight)
                    //    {
                    //        x = tileRight;
                    //    }
                    //}
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
                //foreach (Tile tile in tiles)
                //{
                //    float tileTop = tile.Position.Y;
                //    float tileBottom = tile.Position.Y + 32;
                //    float tileLeft = tile.Position.X;
                //    float tileRight = tile.Position.X + 32;

                //    //if (playerRight - 5 > tileLeft && playerLeft + 5 < tileRight)
                //    //{
                //    //    if (playerBottom > tileTop)
                //    //    {
                //    //        //y = tileTop - 64;
                //    //        //isTouchingGround = true;
                //    //        tileUnder = true;
                //    //        collisionY = tileTop - 64;
                //    //    }
                //    //    if (playerTop < tileBottom)
                //    //    {
                //    //        tileAbove = true;
                //    //        collisionY = tileBottom;
                //    //    }
                //    //}
                //    //else
                //    //{
                //    //    //x = tileRight;
                //    //    if (playerRight - 5 < tileLeft)
                //    //    {
                //    //        collisionX = tileLeft;
                //    //        tileL = true;
                //    //    }
                //    //    if (playerLeft + 5 > tileRight)
                //    //    {
                //    //        collisionX = tileRight - 38;
                //    //        tileR = true;
                //    //    }
                //    //}



                //    /*
                //    if (tile.Position.Y > nextPosition.Y)
                //    {
                //        if (tile.Position.Y + 32 < nextPosition.Y + 64)
                //        {
                //            //TODO: check floor
                //            if (tile.Position.X > nextPosition.X)
                //            {
                //                x = tile.Position.X - 39;
                //            }
                //            if (tile.Position.X < nextPosition.X)
                //            {
                //                x = tile.Position.X + 33;
                //            }
                //            isTouchingGround = false;
                //        }
                //        else
                //        {
                //            y = tile.Position.Y - 64;
                //            isTouchingGround = true;
                //        }
                //        //isTouchingGround = false;
                //    }
                //    else if (tile.Position.Y < nextPosition.Y)
                //    {
                //        y = tile.Position.Y + 32;
                //    }*/
                //}
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