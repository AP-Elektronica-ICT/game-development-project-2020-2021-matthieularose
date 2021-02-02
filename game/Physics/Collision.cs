using System;
using GameDevProject.GameObjects.World;
using Microsoft.Xna.Framework;

namespace GameDevProject.Physics
{
    //Klasse die een colliding GameObject returnt
    public class Collision
    {
        public Tile GameObject(Rectangle collisionRectangle, Tile gameObject)
        {
            if (collisionRectangle.Intersects(gameObject.CollisionRectangle)) return gameObject;
            else return null;
        }
    }
}
