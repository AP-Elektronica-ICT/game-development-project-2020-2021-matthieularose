using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Animation
{
    public class SpriteAnimation
    {
        public AnimationFrame currentFrame { get; set; }
        private List<AnimationFrame> frames;

        private int counter = 0;
        private double frameMovement = 0;

        private int fps = 12;

        public SpriteAnimation(int imgWidth, int imgHeight, int spriteCount)
        {
            frames = GetFrames(imgWidth, imgHeight, spriteCount);
        }
        
        public List<AnimationFrame> GetFrames(int imgWidth, int imgHeight, int frameCount)
        {
            List<AnimationFrame> framesToReturn = new List<AnimationFrame>();
            int frameWidth = imgWidth / frameCount;

            for (int w = 0; w < imgWidth; w += frameWidth)
            {
                framesToReturn.Add(new AnimationFrame(new Rectangle(w, 0, frameWidth, imgHeight)));
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
