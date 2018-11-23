using System;

using Try_To_Die.Utils;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Try_To_Die.Screens;

namespace Try_To_Die.Screens
{
    public class TitleScreen : GameScreen
    { 
        Texture2D BackGround;
        Rectangle BackGroundPos;

        public override void LoadContent()
        {
            base.LoadContent();


            Point topLeftPosition = new Point(0, 0);

            Point heightAndWidth = new Point(ScreenManager.Instance.Dimensions.Width, ScreenManager.Instance.Dimensions.Height);

            // The rectangle that the logo fills.
            BackGroundPos = new Rectangle(
                topLeftPosition,
                heightAndWidth);

            BackGround = Content.Load<Texture2D>("Menu/BackGround");
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(BackGround, BackGroundPos, Color.White);
            spriteBatch.End();
        }
    }
}