
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_Lesson_3___Animation_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D greyTribbleTexture, brownTribbleTexture, creamTribbleTexture, orangeTribbleTexture;
        Rectangle greyTribbleRect, creamTribbleRect, brownTribbleRect, orangeTribbleRect;
        Vector2 greyTribbleSpeed, creamTribbleSpeed, brownTribbleSpeed, orangeTribbleSpeed;

        Random generator = new Random();

       

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.Window.Title = "Animation with tribbles";
            _graphics.PreferredBackBufferWidth = 1000; // Sets the width of the window
            _graphics.PreferredBackBufferHeight = 600; // Sets the height of the window
            _graphics.ApplyChanges(); // Applies the new dimensions

            greyTribbleRect = new Rectangle(generator.Next(0,901), generator.Next(0, 501), 100, 100);
            greyTribbleSpeed = new Vector2(4, 4);

            creamTribbleRect = new Rectangle(generator.Next(0, 901), generator.Next(0, 501), 100, 100);
            creamTribbleSpeed = new Vector2(0, 10);

            brownTribbleRect = new Rectangle(generator.Next(0, 901), generator.Next(0, 501), 100, 100);
            brownTribbleSpeed = new Vector2(2, 10);

            orangeTribbleRect = new Rectangle(generator.Next(0, 901), generator.Next(0, 501), 100, 100);
            orangeTribbleSpeed = new Vector2(10, 0);

            base.Initialize();
           
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            greyTribbleTexture = Content.Load<Texture2D>("tribbleGrey");
            brownTribbleTexture = Content.Load<Texture2D>("tribbleBrown");
            creamTribbleTexture = Content.Load<Texture2D>("tribbleCream");
            orangeTribbleTexture = Content.Load<Texture2D>("tribbleOrange");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            greyTribbleRect.X += (int)greyTribbleSpeed.X;
            greyTribbleRect.Y += (int)greyTribbleSpeed.Y;

            creamTribbleRect.X += (int)creamTribbleSpeed.X;
            creamTribbleRect.Y += (int)creamTribbleSpeed.Y;

            orangeTribbleRect.X += (int)orangeTribbleSpeed.X;
            orangeTribbleRect.Y += (int)orangeTribbleSpeed.Y;

            brownTribbleRect.X += (int)brownTribbleSpeed.X;
            brownTribbleRect.Y += (int)brownTribbleSpeed.Y;

            //Grey tribble walks off of the page, ends up on the opposite side.
            if (greyTribbleRect.Right > _graphics.PreferredBackBufferWidth + 120)
            {
                greyTribbleRect.X = -100;
            }
            if (greyTribbleRect.Bottom > _graphics.PreferredBackBufferHeight + 120)
            {
                greyTribbleRect.Y = -100;
            }

            if (greyTribbleRect.Left < -100)
            {
                greyTribbleRect.X = 1000;
            }
            if (greyTribbleRect.Top < -100)
            {
                greyTribbleRect.Y = 600;
            }




            if (brownTribbleRect.Right > _graphics.PreferredBackBufferWidth || brownTribbleRect.Left < 0)
            {
                brownTribbleSpeed.X *= -1;
            }
            if (brownTribbleRect.Bottom > _graphics.PreferredBackBufferHeight || brownTribbleRect.Top < 0)
            {
                brownTribbleSpeed.Y *= -1;
            }

            if (orangeTribbleRect.Right > _graphics.PreferredBackBufferWidth || orangeTribbleRect.Left < 0)
            {
                orangeTribbleSpeed.X *= -1;
            }
            if (orangeTribbleRect.Bottom > _graphics.PreferredBackBufferHeight || orangeTribbleRect.Top < 0)
            {
                orangeTribbleSpeed.Y *= -1;
            }

            if (creamTribbleRect.Right > _graphics.PreferredBackBufferWidth || creamTribbleRect.Left < 0)
            {
                creamTribbleSpeed.X *= -1;
            }
            if (creamTribbleRect.Bottom > _graphics.PreferredBackBufferHeight || creamTribbleRect.Top < 0)
            {
                creamTribbleSpeed.Y *= -1;
            }


            if (greyTribbleRect.Intersects(brownTribbleRect))
            {
                brownTribbleSpeed.X *= -1;
                brownTribbleSpeed.Y *= -1;

                greyTribbleSpeed.X *= -1;
                greyTribbleSpeed.Y *= -1;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.Draw(greyTribbleTexture, greyTribbleRect, Color.White);
            _spriteBatch.Draw(brownTribbleTexture, brownTribbleRect, Color.White);
            _spriteBatch.Draw(creamTribbleTexture, creamTribbleRect, Color.White);
            _spriteBatch.Draw(orangeTribbleTexture, orangeTribbleRect, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}