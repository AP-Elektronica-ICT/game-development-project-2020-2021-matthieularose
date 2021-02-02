using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Background
{
    public class ParallaxBackground
    {
        public List<Background> backgrounds = new List<Background>();
        public List<Texture2D> backgroundTextures = new List<Texture2D>();

        public ParallaxBackground(List<Texture2D> textures)
        {
            backgroundTextures = textures;
        }

        public void Initialize()
        {
            for (int i = 0; i < backgroundTextures.Count; i++)
            {
                //TODO: Maak Parallax
                for (int j = 0; j < 8000; j += 800)
                {
                    backgrounds.Add(new Background(new Vector2(j, 0), backgroundTextures[i]));
                }

                //for (int j = 0; j < i + 1; i++)
                //{
                //    backgrounds.Add(new Background(new Vector2(j * 800, 0), backgroundTextures[i]));
                //}
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Background background in backgrounds)
            {
                background.Draw(spriteBatch);
            }
        }
    }
}
