﻿#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Textured_Primitives.GraphicsSupport;

#endregion

namespace Textured_Primitives
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        // Variables that begin with the letter s (for example, sStaticVariable) indicate that they are static.
        static public SpriteBatch sSpriteBatch;         // Drawing support
        static public ContentManager sContent;          // Loading textures
        static public GraphicsDeviceManager sGraphics;  // Current display size

        // Prefer window size
        const int kWindowWidth = 1000;
        const int kWindowHeight = 700;

        const int kNumObjects = 4;
        // Work with the TexturedPrimitive class
        TexturedPrimitive[] mGraphicsObjects; // An array of objects
        int mCurrentIndex = 0;


        public Game1()
            : base()
        {
            sGraphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

                    // Set preferred window size
            sGraphics.PreferredBackBufferWidth = kWindowWidth;
            sGraphics.PreferredBackBufferHeight = kWindowHeight;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            sSpriteBatch = new SpriteBatch(GraphicsDevice);

            // Create the primitives
            mGraphicsObjects = new TexturedPrimitive[kNumObjects];
            mGraphicsObjects[0] = new TexturedPrimitive("UWB-JPG",              // Image file name
                                                        new Vector2(10,10),     // Position to draw
                                                        new Vector2(30,30));    // Size to draw
            mGraphicsObjects[1] = new TexturedPrimitive("UWB-JPG", new Vector2(200, 200), new Vector2(100, 100));
            mGraphicsObjects[2] = new TexturedPrimitive("UWB-JPG", new Vector2(50, 10), new Vector2(30, 30));
            mGraphicsObjects[3] = new TexturedPrimitive("UWB-JPG", new Vector2(50, 200), new Vector2(100, 100));
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
            // Allows game to exit. F1 should also work due to mapping in InputWrapper class
            if (InputWrapper.Buttons.Back == ButtonState.Pressed)
                Exit();

            // "A" to toggle to full-screen mode ("k" on keyboard)
            if (InputWrapper.Buttons.A == ButtonState.Pressed)
            {
                if (!sGraphics.IsFullScreen)
                {
                    sGraphics.IsFullScreen = true;
                    sGraphics.ApplyChanges();
                }
            }

            // "B" toggles back to window mode ("L" on keyboard)
            if (InputWrapper.Buttons.B == ButtonState.Pressed)
            {
                if (sGraphics.IsFullScreen)
                {
                    sGraphics.IsFullScreen = false;
                    sGraphics.ApplyChanges();
                }
            }

           

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
