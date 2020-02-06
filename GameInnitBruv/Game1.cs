using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameInnitBruv
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D dvdLogo;
        Rectangle dvdRect;
        int xSpeed = 2, ySpeed = 2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true; //Lets us view our mouse cursor as it overlaps the game
            graphics.PreferredBackBufferWidth = 1366; //1366 pixels wide 
            graphics.PreferredBackBufferHeight = 768; //768 pixels tall
        }

        protected override void Initialize()
        {
            dvdRect = new Rectangle(100, 100, 50, 50); //Spawns logo at X=100 Y= 100
            base.Initialize();                         // with size of 50x50 pixels
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            dvdLogo = Content.Load<Texture2D>("dvdLogo");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (dvdRect.X < 0 || dvdRect.X + 40 > Window.ClientBounds.Width)
            {
                xSpeed *= -1;
            }

            if (dvdRect.Y < 0 || dvdRect.Y + 40 > Window.ClientBounds.Height)
            { //Note I have +40 here because dvdRect.Y & X are from the TOP LEFT of the .png
                ySpeed *=-1; //I want the right and bottom side to collide too, so I have to add on the width
            }                // and height of the Texture2D !

            dvdRect.X += xSpeed;
            dvdRect.Y += ySpeed;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(dvdLogo, dvdRect, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
