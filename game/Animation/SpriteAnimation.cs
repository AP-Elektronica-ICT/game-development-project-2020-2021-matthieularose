using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Animation
{
    //Animation was already namespace (folder) => SpriteAnimation = class name
    public class SpriteAnimation
    {
        public AnimationFrame currentFrame { get; set; }
        private List<AnimationFrame> frames;

        private int counter = 0;
        private double frameMovement = 0;

        private int fps = 10;

        public SpriteAnimation(int imgWidth, int imgHeight, int spriteCount)
        {
            frames = GetFrames(imgWidth, imgHeight, spriteCount);
        }
        
        public List<AnimationFrame> GetFrames(int imgWidth, int imgHeight, int frameCount)
        {
            List<AnimationFrame> framesToReturn = new List<AnimationFrame>();

            int frameCounter = 0;
            int frameWidth = imgWidth / 5;
            int rows = frameCount / 5;
            if (frameCount % 5 != 0) rows++;
            int frameHeight = imgHeight / rows;

            for (int h = 0; h < imgHeight; h += frameHeight)
            {
                for (int w = 0; w < imgWidth; w += frameWidth)
                {
                    framesToReturn.Add(new AnimationFrame(new Rectangle(w, h, frameWidth, frameHeight)));
                    frameCounter++;

                    if (frameCounter >= frameCount) return framesToReturn;
                }
            }

            return framesToReturn;
        }
        
        public void Update(GameTime gameTime)
        {
            currentFrame = frames[counter];
            frameMovement += currentFrame.sourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;

            if (frameMovement >= currentFrame.sourceRectangle.Width / fps)
            {
                counter++;
                frameMovement = 0;
            }

            if (counter >= frames.Count) counter = 0;
        }
    }
}
