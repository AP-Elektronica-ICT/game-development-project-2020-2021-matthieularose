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

        public void OnCollision(Tile tile)
        {
            if (tile.position.Y > Player.position.Y)
            {
                Player.position = new Vector2(Player.position.X, tile.position.Y - 64);
                Player.isTouchingGround = true;
            }
            else if (tile.position.Y < Player.position.Y)
            { 
                Player.position = new Vector2(Player.position.X, tile.position.Y + 32);
            }
            else if (tile.position.X > Player.position.X)
            {
                Player.position = new Vector2(tile.position.X - 64, Player.position.Y);
            }
            else if (tile.position.X < Player.position.X)
            {
                Player.position = new Vector2(tile.position.X + 64, Player.position.Y);
            }
        }
    }
}
