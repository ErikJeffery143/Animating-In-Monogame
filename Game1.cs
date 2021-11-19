using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Animating_In_Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Random generator = new Random();
        List<Color> colours = new List<Color>();
        Color backgroundColor;

        int randomY;
        int randomX;

        //Grey
        Texture2D tribblegreyTexture;
        Rectangle tribblegreyRect;
        Vector2 tribblegreySpeed;
        //Cream
        Texture2D tribblecreamTexture;
        Rectangle tribblecreamRect;
        Vector2 tribblecreamSpeed;
        //Brown
        Texture2D tribblebrownTexture;
        Rectangle tribblebrownRect;
        Vector2 tribblebrownSpeed;
        //Orange
        Texture2D tribbleorangeTexture;
        Rectangle tribbleorangeRect;
        Vector2 tribbleorangeSpeed;

        




        public Game1()
        {
            //COLOUR LIST
            colours.Add(Color.CornflowerBlue);
            colours.Add(Color.Firebrick);
            colours.Add(Color.LimeGreen);
            colours.Add(Color.HotPink);
            colours.Add(Color.LightCyan);
            colours.Add(Color.MediumPurple);
            colours.Add(Color.Gold);
            colours.Add(Color.Transparent);
            colours.Add(Color.DarkKhaki);
            colours.Add(Color.DarkTurquoise);
            colours.Add(Color.Salmon);
            colours.Add(Color.Chartreuse);
            colours.Add(Color.Aquamarine);
            colours.Add(Color.Crimson);
            colours.Add(Color.White);
            colours.Add(Color.Red);
            colours.Add(Color.Fuchsia);
            colours.Add(Color.DarkOliveGreen);
            colours.Add(Color.DarkOrchid);
            colours.Add(Color.DodgerBlue);
            colours.Add(Color.Goldenrod);
            colours.Add(Color.MonoGameOrange);
            // randomly picks a color from the list
            backgroundColor = colours[generator.Next(colours.Count)];

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            randomX = generator.Next(0, _graphics.PreferredBackBufferWidth);
            randomY = generator.Next(0, _graphics.PreferredBackBufferHeight);



            tribblegreyRect = new Rectangle(300, 10, 100, 100);
            tribblegreySpeed = new Vector2(10, 1);

            tribblecreamRect = new Rectangle(randomX, randomY, 100, 100);
            tribblecreamSpeed = new Vector2(20, 0);

            randomX = generator.Next(0, _graphics.PreferredBackBufferWidth-100);
            randomY = generator.Next(0, _graphics.PreferredBackBufferHeight-80);
            tribbleorangeRect = new Rectangle(randomX, randomY, 100, 100);
            tribbleorangeSpeed = new Vector2(0, 20);

            tribblebrownRect = new Rectangle(0, 0, 100, 100);
            tribblebrownSpeed = new Vector2(10, 10);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            tribbleorangeTexture = Content.Load <Texture2D>("tribbleOrange");

            tribblecreamTexture = Content.Load<Texture2D>("tribbleCream");

            tribblegreyTexture = Content.Load<Texture2D>("tribbleGrey");

            tribblebrownTexture = Content.Load<Texture2D>("tribbleBrown");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //GREY
            tribblegreyRect.X += (int)tribblegreySpeed.X;
            if (tribblegreyRect.Right >= _graphics.PreferredBackBufferWidth || tribblegreyRect.Left <= 0)
                tribblegreySpeed.X *= -1;

            tribblegreyRect.Y += (int)tribblegreySpeed.Y;
            if (tribblegreyRect.Bottom > _graphics.PreferredBackBufferHeight || tribblegreyRect.Top < 0)
                tribblegreySpeed.Y *= -1 ;

            tribblegreyRect.X += (int)tribblegreySpeed.X;
            if (tribblegreyRect.Right >= _graphics.PreferredBackBufferWidth || tribblegreyRect.Left <= 0)
                backgroundColor = colours[generator.Next(colours.Count)];

            tribblegreyRect.Y += (int)tribblegreySpeed.Y;
            if (tribblegreyRect.Bottom > _graphics.PreferredBackBufferHeight || tribblegreyRect.Top < 0)
                backgroundColor = colours[generator.Next(colours.Count)];

            //CREAM

            tribblecreamRect.X += (int)tribblecreamSpeed.X;
            if (tribblecreamRect.Right > 900)
            {
                randomY = generator.Next(0, _graphics.PreferredBackBufferHeight);
                tribblecreamRect = new Rectangle(-100, randomY, 100, 100);

            }


            //ORANGE
            tribbleorangeRect.X += (int)tribbleorangeSpeed.X;
            if (tribbleorangeRect.Right >= _graphics.PreferredBackBufferWidth || tribbleorangeRect.Left <= 0)
                tribbleorangeSpeed.X *= -1;

            tribbleorangeRect.Y += (int)tribbleorangeSpeed.Y;
            if (tribbleorangeRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleorangeRect.Top < 0)
                tribbleorangeSpeed.Y *= -1;

            //BROWN
            tribblebrownRect.X += (int)tribblebrownSpeed.X;
            if (tribblebrownRect.Right >= _graphics.PreferredBackBufferWidth || tribblebrownRect.Left <= 0)
                tribblebrownSpeed.X *= -1;

            tribblebrownRect.Y += (int)tribblebrownSpeed.Y;
            if (tribblebrownRect.Bottom > _graphics.PreferredBackBufferHeight || tribblebrownRect.Top < 0)
                tribblebrownSpeed.Y *= -1;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);

            _spriteBatch.Begin();

            _spriteBatch.Draw(tribblegreyTexture, tribblegreyRect, Color.White);

            _spriteBatch.Draw(tribblecreamTexture, tribblecreamRect, Color.White);

            _spriteBatch.Draw(tribbleorangeTexture, tribbleorangeRect, Color.White);

            _spriteBatch.Draw(tribblebrownTexture, tribblebrownRect, Color.White);

            


            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
