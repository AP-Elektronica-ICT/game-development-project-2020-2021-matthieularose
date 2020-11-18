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
        
        public void Update()
        {
            currentFrame = frames[counter];
            counter++;

            if (counter >= frames.Count) counter = 0;
        }
    }
}
