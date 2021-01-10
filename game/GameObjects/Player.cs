using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using GameDevProject.Interfaces;
using GameDevProject.Animation;
using GameDevProject.Commands;
using GameDevProject.Collision;
using GameDevProject.Physics;
using System.Collections.Generic;
using GameDevProject.GameObjects.World;

namespace GameDevProject.GameObjects
{
    public class Player : IGameObject, ITransform, ICollision
    {
        Texture2D texture;
        SpriteAnimation animation;

        public bool isTouchingGround = true;
        public bool touchChange = true;

        public IAnimationManager animationManager;
        private IReadInput inputReader;
        private IMoveCommand runCommand = new RunCommand();
        private IMoveCommand jumpCommand = new JumpCommand();

        public Collider collider;

        private Gravity gravity = new Gravity();

        public Vector2 position { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        public Vector2 runVelocity = new Vector2(4, 0);
        public Vector2 jumpVelocity = new Vector2(0, 10);
        public Vector2 gravVelocity = new Vector2(0, 10);
        public Vector2 gravVelocityPointer = new Vector2(0, 10);

        Vector2 grav = new Vector2(0, 9.81f);

        float elapsedTime;
        //DateTime startTime;
        //TimeSpan timer;
        //float time;

        List<Tile> Tiles;
        CollisionDetector collisionDetector = new CollisionDetector();
        Tile floorTile;

        public Player(IReadInput reader, List<Tile> tiles)
        {
            inputReader = reader;

            position = new Vector2(300, 200);

            //collisionManager = new CollisionManager(this, level.tiles);

            CollisionRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 64);

            Tiles = tiles;

            //collider = new Collider(this);
        }

        public void Update(GameTime gameTime)
        {
            

            elapsedTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 100;

            

            //timer = startTime - DateTime.Now;

            var direction = inputReader.ReadInput();

            //if (direction.X != 0) runCommand.Execute(this, direction);
            //if (direction.Y != 0 && isTouchingGround)
            //{
            //    jumpCommand.Execute(this, direction, gameTime);
            //    isTouchingGround = false;
            //}

            //gravity.Pull(this, gameTime);


            //if (direction != new Vector2(0,0))
            //{
                Vector2 nextPosition = position;
                if (direction.X != 0)
                {
                    nextPosition += (direction * runVelocity);

                    //position += direction * runVelocity;
                }
                if (direction.Y != 0) //<
                {
                    nextPosition += (direction * jumpVelocity);

                    //position += direction * jumpVelocity;
                    //isTouchingGround = false;
                }

            gravVelocity += grav * elapsedTime;
            nextPosition += gravVelocity * elapsedTime;


            if (GetCollidingTiles(new Rectangle((int)nextPosition.X, (int)nextPosition.Y, 32, 64)).Count > 0)
                {
                    //collider.OnCollisionEnter();
                    if (floorTile != null) position = new Vector2(nextPosition.X, floorTile.position.Y - 64);
                    gravVelocity = gravVelocityPointer;
                    elapsedTime = 0;
                }
                else
                {
                    position = nextPosition;
                    direction = new Vector2(0, -1);
                }

            CollisionRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 64);
            //}

            //time = (float)timer.TotalSeconds;
            //time = 0.1f;
            //if (!isTouchingGround)
            //{
            //    gravVelocity += grav * elapsedTime;
            //    position += gravVelocity * elapsedTime;
            //}

            //gravVelocity += grav * elapsedTime;
            //position += gravVelocity * elapsedTime;

            //Debug.WriteLine(position);


            //if (isTouchingGround)
            //{
            //    //startTime = DateTime.Now;
            //    gravVelocity = new Vector2(0, 10);
            //    elapsedTime = 0;
            //    //touchChange = !touchChange;
            //}

            //if (!isTouchingGround)
            //{
            //    gravVelocity += grav * elapsedTime;
            //    position += gravVelocity * elapsedTime;
            //}

            animationManager.Update(direction);
            texture = animationManager.texture;
            animation = animationManager.animation;

            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null && animation != null) spriteBatch.Draw(texture, position, animation.currentFrame.sourceRectangle, Color.White);
        }

        public List<Tile> GetCollidingTiles(Rectangle NextCollisionRectangle)
        {
            List<Tile> tiles = new List<Tile>();

            foreach (Tile tile in Tiles)
            {
                if (collisionDetector.collision(NextCollisionRectangle, tile.CollisionRectangle))
                {
                    tiles.Add(tile);
                    if (tile.position.Y > position.Y) floorTile = tile;
                }
            }
            return tiles;
        }
    }
}
