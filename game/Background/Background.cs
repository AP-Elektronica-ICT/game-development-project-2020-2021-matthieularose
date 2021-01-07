using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Background
{
    public class Background
    {
        public Vector2 Position;
        public Texture2D Texture;

        public Background(Vector2 position, Texture2D texture)
        {
            Position = position;
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
