using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Interfaces
{
    public interface IGameObject : ICollision
    {
        public Vector2 Position { get; set; }
    }
}
