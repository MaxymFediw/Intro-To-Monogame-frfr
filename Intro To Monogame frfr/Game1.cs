using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Intro_To_Monogame_frfr
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Random generator, positionY, positionX;

        Rectangle window;

        Texture2D backgroundTexture;

        Rectangle shipRect;

        Texture2D shipTexture;

        SpriteFont titleFont;

        List<Texture2D> shipTextures;

        float textOpacity;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.Window.Title = "Content Scaling and Text";

            generator = new Random();

            

            window = new Rectangle(0, 0, 800, 500); //        x, y, width, height

            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            shipRect = new Rectangle(generator.Next(0, window.Width - 75), generator.Next(0, window.Height - 100), 75, 100);

            shipTextures = new List<Texture2D>();

            textOpacity = 0f;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            backgroundTexture = Content.Load<Texture2D>("Images/space_background");

            for (int i = 1; i <= 5; i++)
            shipTextures.Add(Content.Load<Texture2D>("Images/enterprise_" + i));

            shipTexture = shipTextures[generator.Next(shipTextures.Count)];

            

            titleFont = Content.Load<SpriteFont>("Fonts/TitleFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            textOpacity += .0005f;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            
            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundTexture, window, Color.White);
            //_spriteBatch.Draw(shipTexture, shipRect, Color.White * 0.5f); //the 0.5 makes the image more transparent.

            _spriteBatch.Draw(shipTexture, shipRect, null, Color.White, 1f, Vector2.Zero, SpriteEffects.FlipVertically, 1f);
                                                                     // ^^Thats how much its rotated in radions 
            _spriteBatch.DrawString(titleFont, "Space", new Vector2(300, 10), Color.Yellow * textOpacity);



            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
