using System;
using Microsoft.Xna.Framework;

namespace GameDevProject.Collision
{
    public class CollisionManager
    {
        public bool IsColliding(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.Intersects(rect2)) return true;
            return false;
        }
    }
}
