using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.GameObjects.World
{
    public class Tile
    {
        public Texture2D texture { get; set; }
        public Vector2 position { get; set; }
        public Rectangle rectangle { get; set; }

        public Tile(Texture2D text, Vector2 pos, Rectangle rect)
        {
            texture = text;
            position = pos;
            rectangle = rect;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (rectangle != null) spriteBatch.Draw(texture, position, rectangle, Color.White);
        }
    }
}
