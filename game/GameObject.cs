using System;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject
{
    public abstract class GameObject : IGameObject
    {
        public GameObject()
        {
        }

        public abstract Vector2 Position { get; set; }
        public abstract Rectangle CollisionRectangle { get; set; }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
