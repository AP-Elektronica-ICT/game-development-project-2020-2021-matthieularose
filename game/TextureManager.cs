using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject
{
    public class TextureManager
    {
        public Texture2D idleTextureR;
        public Texture2D idleTextureL;
        public Texture2D runTextureR;
        public Texture2D runTextureL;
        public Texture2D jumpTextureR;
        public Texture2D jumpTextureL;

        public Texture2D tileTexture;

        public List<Texture2D> backgroundTextures = new List<Texture2D>();

        private GraphicsDevice GraphicsDevice;

        public TextureManager(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
        }

        private void GetTextures()
        {
            //MGCB Editor doesn't work on latest version of MacOS
            string dir = "/Users/matthieu/School/2EA-Cloud/GameDev/game-development-project-2020-2021-matthieularose/game/Content/";

            //Player
            FileStream fileStream = new FileStream(dir + "sprites/idleRight.png", FileMode.Open);
            idleTextureR = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/idleLeft.png", FileMode.Open);
            idleTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/runRight.png", FileMode.Open);
            runTextureR = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/runLeft.png", FileMode.Open);
            runTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/jumpRight.png", FileMode.Open);
            jumpTextureR = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/jumpLeft.png", FileMode.Open);
            jumpTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/jumpLeft.png", FileMode.Open);
            jumpTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            //Tilesets
            fileStream = new FileStream(dir + "tilesets/tileset1.png", FileMode.Open);
            tileTexture = Texture2D.FromStream(GraphicsDevice, fileStream);

            //Parallax Backgrounds
            fileStream = new FileStream(dir + "backgrounds/plx-1.png", FileMode.Open);
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream = new FileStream(dir + "backgrounds/plx-2.png", FileMode.Open);
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream = new FileStream(dir + "backgrounds/plx-3.png", FileMode.Open);
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream = new FileStream(dir + "backgrounds/plx-4.png", FileMode.Open);
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream = new FileStream(dir + "backgrounds/plx-5.png", FileMode.Open);
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream.Dispose();
        }
    }
}
