﻿using System;
using System.Collections.Generic;
using GameDevProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public enum TileType { Floor, Wall}

namespace GameDevProject.GameObjects.World
{
    public class Tile : GameObject
    {
        public Texture2D texture { get; set; }
        public Rectangle TextureRectangle { get; set; }

        public override Vector2 Position { get; set; }
        public override Rectangle CollisionRectangle { get; set; }

        public TileType tileType { get; set; }

        public Tile(Texture2D text, Vector2 pos, Rectangle rectangle, TileType type)
        {
            texture = text;
            Position = pos;
            TextureRectangle = rectangle;
            CollisionRectangle = new Rectangle((int)pos.X, (int)pos.Y, 32, 32);
            tileType = type;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (TextureRectangle != null) spriteBatch.Draw(texture, Position, TextureRectangle, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
