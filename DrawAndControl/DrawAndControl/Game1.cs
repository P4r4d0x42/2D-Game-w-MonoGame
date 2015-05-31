#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace DrawAndControl
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch mSpriteBatch;

        private Texture2D mJPGImage;  // The UWB-JPG
        private Vector2 mJPGPosition;  // Top-Left pixel pos of mJPGImage

        private Texture2D mPNGImage; // PNG
        private Vector2 mPNGPosition;  // Top-Left most pixel of mPNG
        

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            mJPGPosition = new Vector2(10f, 10f);
            mPNGPosition = new Vector2(100f, 100f);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            mSpriteBatch = new SpriteBatch(GraphicsDevice);

            mJPGImage = Content.Load<Texture2D>("UWB-JPG");
            mPNGImage = Content.Load<Texture2D>("UWB-PNG");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            #region Game Controller
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update the image positions with left/right thumbsticks
            mJPGPosition += GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
            mPNGPosition += GamePad.GetState(PlayerIndex.One).ThumbSticks.Right;
            #endregion

            #region Keyboard
            // Allows the game to exit
            if(Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // Update the image position with Arrow Keys
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                mJPGPosition.X --;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                mJPGPosition.X++;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                mJPGPosition.Y--;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                mJPGPosition.Y++;


            // Update the png image with wasd
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                mPNGPosition.X--;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                mPNGPosition.X++;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                mPNGPosition.Y--;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                mPNGPosition.Y++;
            
            #endregion

            #region Mouse
            // Poll mouse state
            MouseState mMouseState = Mouse.GetState();

            // If left mouse button is pressed move jpg to location click
            if (mMouseState.LeftButton == ButtonState.Pressed)
            {
                mJPGPosition = new Vector2(mMouseState.X, mMouseState.Y);
            }

            // Same deal but with png
            if (mMouseState.RightButton == ButtonState.Pressed)
            {
                mPNGPosition = new Vector2(mMouseState.X, mMouseState.Y);
            }

            #endregion

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            mSpriteBatch.Begin(); // Init drawing support

            // Draw images
            mSpriteBatch.Draw(mJPGImage,mJPGPosition,Color.White);
            mSpriteBatch.Draw(mPNGImage,mPNGPosition,Color.White);

            mSpriteBatch.End(); // Inform graphics system we are done drawing

            base.Draw(gameTime);
        }
    }
}
