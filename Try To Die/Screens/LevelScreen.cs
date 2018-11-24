using System;
using System.Collections;
using System.Collections.Generic;
using Try_To_Die.Utils;
using Try_To_Die.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Try_To_Die.Controllers;

namespace Try_To_Die.Screens
{
    public class LevelScreen : GameScreen
    {
        Player player;
        Controller controller;
        public override void LoadContent()
        {
            base.LoadContent();
            player = new Player(new Vector2(500, 500));
            player.LoadContent(Content);
            controller = new GameController();
        }

        public override void Update(GameTime gameTime)
        {
            controller.Update(player, gameTime);

            player.Update(ScreenManager.Instance.Dimensions, gameTime, Content);

            if(player.health <= 0)
            {
                ScreenManager.Instance.ChangeScreen(new TitleScreen());
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            controller.Draw(spriteBatch);
        }
    }
}