using System;
using GameDevProject.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Interfaces
{
    public interface IAnimationManager
    {
        public Texture2D texture { get; set; }
        public SpriteAnimation animation { get; set; }

        public void Update(Vector2 direction);
    }
}
