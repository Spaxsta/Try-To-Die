using System;
using System.Collections;
using System.Collections.Generic;
using Try_To_Die.Application;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Try_To_Die.Controllers;
using Try_To_Die.World;

namespace Try_To_Die.Screens
{
    public class LevelScreen : GameScreen
    {
        Player player;
        Controller controller;
        List<Entity> sprites = new List<Entity>();

        public override void LoadContent()
        {
            base.LoadContent();
            player = new Player(new Rectangle(500, 500, 50, 50));

            Platform platform = new Platform("Platform", new Rectangle(700, 800, 100, 30));
            Platform platform2 = new Platform("Platform", new Rectangle(600, 900, 100, 30));
            Platform platform3 = new Platform("Platform", new Rectangle(550, 700, 100, 30));
            sprites.Add(platform);
            sprites.Add(platform2);
            sprites.Add(platform3);
            player.LoadContent(Content);
            foreach (var s in sprites)
            {
                s.LoadContent(Content);
            }
            controller = new GameController();

           
        }

        public override void Update(GameTime gameTime)
        {
            controller.Update(player, gameTime, sprites);

            player.Update(ScreenManager.Instance.Dimensions, gameTime, Content);

            if(player.health <= 0)
            {
                ScreenManager.Instance.ChangeScreen(new TitleScreen());
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            foreach (var s in sprites)
            {
                s.Draw(spriteBatch);
            }
            controller.Draw(spriteBatch);
        }
    }
}