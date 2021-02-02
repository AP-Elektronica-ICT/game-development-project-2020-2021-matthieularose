using System;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Animation
{
    public class PlayerAnimationManager : IAnimationManager
    {
        public Texture2D texture { get; set; }
        public SpriteAnimation animation { get; set; }

        private bool facesRight = true;

        Texture2D idleTextureR;
        Texture2D idleTextureL;
        Texture2D runTextureR;
        Texture2D runTextureL;
        Texture2D jumpTextureR;
        Texture2D jumpTextureL;

        SpriteAnimation idleAnimation = new SpriteAnimation(456, 68, 12);
        SpriteAnimation runAnimation = new SpriteAnimation(336, 66, 8);
        SpriteAnimation jumpAnimation = new SpriteAnimation(34, 68, 1);


        public PlayerAnimationManager(Texture2D idleR, Texture2D idleL, Texture2D runR, Texture2D runL, Texture2D jumpR, Texture2D jumpL)
        {
            idleTextureR = idleR;
            idleTextureL = idleL;
            runTextureR = runR;
            runTextureL = runL;
            jumpTextureR = jumpR;
            jumpTextureL = jumpL;
        }

        public void Update(Vector2 direction)
        {
            if (direction.X > 0)
            {
                facesRight = true;
                if (direction.Y > 0)
                {
                    texture = jumpTextureR;
                    animation = jumpAnimation;
                }
                else if (direction.Y < 0)
                {
                    texture = jumpTextureR;
                    animation = jumpAnimation;
                }
                else
                {
                    texture = runTextureR;
                    animation = runAnimation;
                }
            }
            else if (direction.X < 0)
            {
                facesRight = false;
                if (direction.Y > 0)
                {
                    texture = jumpTextureL;
                    animation = jumpAnimation;
                }
                else if (direction.Y < 0)
                {
                    texture = jumpTextureL;
                    animation = jumpAnimation;
                }
                else
                {
                    texture = runTextureL;
                    animation = runAnimation;
                }
            }
            else
            {
                if (facesRight)
                {
                    if (direction.Y > 0)
                    {
                        texture = jumpTextureR;
                        animation = jumpAnimation;
                    }
                    else if (direction.Y < 0)
                    {
                        texture = jumpTextureR;
                        animation = jumpAnimation;
                    }
                    else
                    {
                        texture = idleTextureR;
                        animation = idleAnimation;
                    }
                }
                else
                {
                    if (direction.Y > 0)
                    {
                        texture = jumpTextureL;
                        animation = jumpAnimation;
                    }
                    else if (direction.Y < 0)
                    {
                        texture = jumpTextureL;
                        animation = jumpAnimation;
                    }
                    else
                    {
                        texture = idleTextureL;
                        animation = idleAnimation;
                    }
                }
            }
        }
    }
}
