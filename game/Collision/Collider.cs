using System;
using GameDevProject.GameObjects;
using GameDevProject.GameObjects.World;
using Microsoft.Xna.Framework;

namespace GameDevProject.Collision
{
    public class Collider
    {
        Player Player;

        public Collider(Player player)
        {
            Player = player;
        }

        public void OnCollisionEnter(Tile tile)
        {
            float x = Player.position.X;
            float y = Player.position.Y;

            if (tile.position.Y > Player.position.Y)
            {
                //Player.position = new Vector2(Player.position.X, tile.position.Y - 64);
                y = tile.position.Y - 64;
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

            Player.position = new Vector2(x, y);
        }

        public void OnCollisionExit()
        {
            Player.isTouchingGround = false;
        }
    }
}
