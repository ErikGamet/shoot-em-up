using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShootEmUp
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
<<<<<<< HEAD

=======
>>>>>>> 1d3dedbdff1b4bfcfe099c9f7e13e9de3bfd306a

        Texture2D shipTexture;
        Rectangle shipRectangle;
        Vector2 moveDir;
        Vector2 position;
        Vector2 scale;
        Vector2 offset;
        float speed;
        private int field;

<<<<<<< HEAD
=======
        enum GameState
        {
            MainMenu,
           // Option,
            Playing,
        }
        GameState currentGameState = GameState.MainMenu;

        int screenWidth = 800, screenHeight = 600;

        cButton btnPlay;
>>>>>>> 1d3dedbdff1b4bfcfe099c9f7e13e9de3bfd306a

        public Game1()
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
            base.Initialize();
            IsMouseVisible = true;
            position = new Vector2(100, 100);
            moveDir = Vector2.Zero;
<<<<<<< HEAD
            speed = 1000;
            scale = new Vector2(1, 1);

            offset = (shipTexture.Bounds.Size.ToVector2() / 2.0f) * scale;
            
=======
            speed = 10000000;
            scale = new Vector2(0.25f , 0.25f);
            offset = (shipTexture.Bounds.Size.ToVector2() / 2.0f) * scale;
            shipRectangle = new Rectangle((position - offset).ToPoint(), (shipTexture.Bounds.Size.ToVector2() * scale).ToPoint());         
>>>>>>> 1d3dedbdff1b4bfcfe099c9f7e13e9de3bfd306a
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            IsMouseVisible = true;

            btnPlay = new cButton(Content.Load<Texture2D>("startButton"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(350, 300));
            shipTexture = Content.Load<Texture2D>("SpaceShip");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            MouseState mouse = Mouse.GetState();
            switch(currentGameState)
            {
                case GameState.MainMenu:
                    if (btnPlay.isClicked == true)
                    {
                        IsMouseVisible = false;
                        currentGameState = GameState.Playing;
                    }
                    btnPlay.Update(mouse);
                    break;

                case GameState.Playing:
                    float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                    MouseState mousestate = Mouse.GetState();
                    Vector2 mousePos = mousestate.Position.ToVector2();
                    moveDir = mousePos - position;
                    float pixelsToMove = speed * deltaTime;
                    if (moveDir != Vector2.Zero)
                    {
                        moveDir.Normalize();

                        if (Vector2.Distance(position, mousePos) < pixelsToMove)
                        {
                            position = mousePos;
                        }
                        else
                        {
                            position += moveDir * pixelsToMove;
                        }
                        shipRectangle.Location = (position - offset).ToPoint();
                    }
                    break;
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

            spriteBatch.Begin();
<<<<<<< HEAD
            spriteBatch.Draw(shipTexture, position, null, Color.White, 0, offset, scale, SpriteEffects.None, 0);
=======
            switch (currentGameState)
            {
                case GameState.MainMenu:
                    btnPlay.Draw(spriteBatch);
                    break;

                case GameState.Playing:
                    spriteBatch.Draw(shipTexture, position, null, Color.White, 0, offset, scale, SpriteEffects.None, 0);
                    break;
            }
>>>>>>> 1d3dedbdff1b4bfcfe099c9f7e13e9de3bfd306a
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
