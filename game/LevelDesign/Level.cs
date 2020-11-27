using System;
using System.Collections.Generic;
using GameDevProject.GameObjects.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.LevelDesign
{
    public class Level
    {
        //ScreenRes: 800px * 480px (800/32 = 25 & 480/32 = 15)
        public Texture2D texture;
        public List<Rectangle> tileTypes = new List<Rectangle>();

        public byte[,] tileArray = new Byte[,]
        {
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {2,2,3,0,1,2 },
            {5,5,6,0,4,5 },
        };

        private Tile[,] tArray = new Tile[4, 6];

        private ContentManager content;

        public Level(ContentManager content, Texture2D text)
        {
            this.content = content;
            texture = text;
            GetTileSprites(96, 96, 32, 32);
            //InitializeContent();
        }

        private void InitializeContent()
        {
            //texture = content.Load<Texture2D>("");
        }


        public void CreateWorld()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    //if (tileArray[x, y] != 0)
                    //{
                        tArray[x, y] = new Tile(texture, new Vector2(y * 32, x * 32), tileTypes[tileArray[x, y]]);
                    //}
                }
            }
        }

        public void DrawWorld(SpriteBatch spritebatch)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (tArray[x, y] != null)
                    {
                        tArray[x, y].Draw(spritebatch);
                    }
                }
            }

        }

        //Temporarily
        public void GetTileSprites(int imgWidth, int imgHeight, int tileWidth, int tileHeight)
        {
            tileTypes.Add(new Rectangle()); //0 = Empty
            for (int h = 0; h < imgHeight; h += tileHeight)
            {
                for (int w = 0; w < imgWidth; w += tileWidth)
                {
                    tileTypes.Add(new Rectangle(w, h, tileWidth, tileHeight));
                }
            }
        }
    }
}
