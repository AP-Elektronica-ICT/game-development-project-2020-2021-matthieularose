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
            Tile tile = GetTile();

            if (tile == null)
            {
                Player.collider.OnCollisionExit();
            }
            else if (tile != null)
            {
                Player.collider.OnCollisionEnter(tile);
            }
        }

        public Tile GetTile() //Door muren omdat enkel de eerste colliding tile returnt => list
        {
            foreach (Tile tile in Tiles)
            {
                if (collisionDetector.collision(Player.CollisionRectangle, tile.CollisionRectangle))
                {
                    return tile;
                    //Player.collider.OnCollisionEnter(tile);
                }
            }
            return null;
        }
    }
}
