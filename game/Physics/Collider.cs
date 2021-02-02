using System;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;

namespace GameDevProject.Physics
{
    //Klasse die bepaald wat het GameObject moet doen bij een collision
    public class Collider
    {
        public Collider(Rectangle collisionRectangle)
        {
            CollisionRectangle = collisionRectangle;
        }

        public Rectangle CollisionRectangle { get; set; }

    }
}
