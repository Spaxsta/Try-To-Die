using System;

using Try_To_Die.Application;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Try_To_Die.Screens;
using Microsoft.Xna.Framework.Input;

namespace Try_To_Die.Screens
{
    public class TitleScreen : GameScreen
    {
        Texture2D BackGround;
        Rectangle BackGroundPos;
        Rectangle play = new Rectangle(500, 400, 500, 200);

        public override void LoadContent()
        {
            base.LoadContent();


            Point topLeftPosition = new Point(0, 0);

            Point heightAndWidth = new Point(
                ScreenManager.Instance.Dimensions.Width,
                ScreenManager.Instance.Dimensions.Height);

            // The rectangle that the logo fills.
            BackGroundPos = new Rectangle(
                topLeftPosition,
                heightAndWidth);

            BackGround = Content.Load<Texture2D>("Menu/BackGround");
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseClick = Mouse.GetState();
            if (Mouse.GetState().X > play.Left && Mouse.GetState().X < play.Right && Mouse.GetState().Y > play.Top 
                && Mouse.GetState().Y < play.Bottom)
            {
                if (mouseClick.LeftButton == ButtonState.Pressed)
                {
                    ScreenManager.Instance.ChangeScreen(new SplashScreen());
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(BackGround, BackGroundPos, Color.White);
            spriteBatch.End();
        }
    }
}