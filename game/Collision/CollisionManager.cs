using System;
using System.Collections.Generic;
using GameDevProject.GameObjects;
using GameDevProject.GameObjects.World;
using Microsoft.Xna.Framework;

namespace GameDevProject.Collision
{
    public class CollisionManager
    {
        private CollisionDetector collisionDetector = new CollisionDetector();

        Player Player;
        List<Tile> Tiles;

        public CollisionManager(Player player, List<Tile> tiles)
        {
            Player = player;
            Tiles = tiles;
        }

        public void Update()
        {
            foreach(Tile tile in Tiles)
            {
                if (collisionDetector.collision(Player.CollisionRectangle, tile.CollisionRectangle))
                {
                    Player.collider.OnCollision(tile);
                }
            }
        }
    }
}
