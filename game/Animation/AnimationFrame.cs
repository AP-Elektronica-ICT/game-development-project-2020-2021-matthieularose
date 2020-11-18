using System;
using Microsoft.Xna.Framework;

namespace GameDevProject.Animation
{
    public class AnimationFrame
    {
        public Rectangle sourceRectangle { get; set; }

        public AnimationFrame(Rectangle rectangle)
        {
            sourceRectangle = rectangle;
        }
    }
}
