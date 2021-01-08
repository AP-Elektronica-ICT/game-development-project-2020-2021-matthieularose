﻿using System;
using Microsoft.Xna.Framework;

namespace GameDevProject.Collision
{
    public class CollisionDetector
    {
        public bool collision(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.Intersects(rect2)) return true;
            return false;
        }
    }
}