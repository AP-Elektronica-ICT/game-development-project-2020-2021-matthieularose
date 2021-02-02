using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Textures
{
    public class TileTexture
    {
        private Rectangle sourceRectangle { get; set; }

        public TileTexture(Rectangle rectangle)
        {
            sourceRectangle = rectangle;
        }
    }
}
