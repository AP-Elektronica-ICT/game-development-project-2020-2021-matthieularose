using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject.States
{
    public class Button : Component
    {
        private MouseState currentMouse;
        private bool isHovering;
        private MouseState previousMouse;

        private Texture2D texture;

        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Color PenColour { get; set; }
        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }
        }

        public string Text { get; set; }


        public Button(Texture2D texture)
        {
            this.texture = texture;

            PenColour = Color.Black;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            if (isHovering) colour = Color.Gray;

            spriteBatch.Draw(texture, Rectangle, colour);
        }

        public override void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                isHovering = true;

                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
