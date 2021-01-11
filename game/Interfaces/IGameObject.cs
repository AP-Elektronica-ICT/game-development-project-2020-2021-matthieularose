using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Interfaces
{
    public interface IGameObject : ICollision
    {
        public Vector2 Position { get; set; }

        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
    }
}
