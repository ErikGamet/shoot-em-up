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


        Texture2D shipTexture;
        Rectangle shipRectangle;
        Vector2 moveDir;
        Vector2 position;
        Vector2 scale;
        Vector2 offset;
        Color shipColor;
        float speed;
        private int field;
        KeyboardState prevKeyboardState;
        Enemy enemy;

        enum GameState
        {
            MainMenu,
            Pause,
            Playing,
        }
        GameState currentGameState = GameState.MainMenu;

        int screenWidth = 800, screenHeight = 600;

        cButton btnPlay;
        cButton btnExit;
        cButton btnResume;

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
            speed = 10000000000 ;
            scale = new Vector2(0.25f, 0.25f);
             
            offset = (shipTexture.Bounds.Size.ToVector2() / 2.0f) * scale;

            shipRectangle = new Rectangle((position - offset).ToPoint(), (shipTexture.Bounds.Size.ToVector2() * scale).ToPoint());
            prevKeyboardState = Keyboard.GetState();
            enemy = new Enemy(Content.Load<Texture2D>("EnemyShip"), new Vector2(1000, 700), 100);

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

            btnPlay = new cButton(Content.Load<Texture2D>("playButton"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(graphics.GraphicsDevice.Viewport.Width * 0.5f, 200));
            btnExit = new cButton(Content.Load<Texture2D>("exitButton"), graphics.GraphicsDevice);
            btnExit.setPosition(new Vector2(graphics.GraphicsDevice.Viewport.Width * 0.5f, 300));
            btnResume = new cButton(Content.Load<Texture2D>("playButton"), graphics.GraphicsDevice);
            btnResume.setPosition(new Vector2(graphics.GraphicsDevice.Viewport.Width * 0.5f, 200));

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
            KeyboardState keyboardState = Keyboard.GetState();
            switch(currentGameState)
            {
                case GameState.MainMenu:
                    if (btnPlay.isClicked == true)
                    {
                        IsMouseVisible = false;
                        currentGameState = GameState.Playing;
                    }
                    btnPlay.Update(mouse);
                    btnExit.Update(mouse);
                    if (btnExit.isClicked == true)
                    {
                        Exit();
                    }
                    break;
                case GameState.Pause:
                    btnResume.Update(mouse);
                    btnExit.Update(mouse);
                    if (prevKeyboardState.IsKeyUp(Keys.Escape) && keyboardState.IsKeyDown(Keys.Escape))
                    {
                        currentGameState = GameState.Playing;
                        IsMouseVisible = false;
                    }
                    if (btnResume.isClicked == true)
                    {
                        currentGameState = GameState.Playing;
                        IsMouseVisible = false;
                    }
                    if  (btnExit.isClicked == true)
                    {
                        Exit();
                    }
                    break;

                case GameState.Playing:
                    enemy.Update();
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
                    if(prevKeyboardState.IsKeyUp(Keys.Escape)&& keyboardState.IsKeyDown(Keys.Escape))
                    {
                        currentGameState = GameState.Pause;
                        IsMouseVisible = true;

                    }

                    break;
            }

            prevKeyboardState = keyboardState;
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
            spriteBatch.Begin();
            switch (currentGameState)
            {
                case GameState.MainMenu:
                    btnPlay.Draw(spriteBatch);
                    btnExit.Draw(spriteBatch);
                    break;

                case GameState.Pause:
                    spriteBatch.Draw(shipTexture, position, null, Color.White, 0, offset, scale, SpriteEffects.None, 0);
                    enemy.Draw(spriteBatch);
                    btnResume.Draw(spriteBatch);
                    btnExit.Draw(spriteBatch);
                    break;

                case GameState.Playing:
                    spriteBatch.Draw(shipTexture, position, null, Color.White, 0, offset, scale, SpriteEffects.None, 0);
                    enemy.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
