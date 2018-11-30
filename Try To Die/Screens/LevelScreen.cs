﻿using System;
using System.Collections;
using System.Collections.Generic;
using Try_To_Die.Player;
using Try_To_Die.Application;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Try_To_Die.Controllers;
using Try_To_Die.WOrld;

namespace Try_To_Die.Screens
{
    public class LevelScreen : GameScreen
    {
        Player player;
        Platform platform;
        Platform platform2;
        Controller controller;
        List<ISprite> sprites = new List<ISprite>();

        public override void LoadContent()
        {
            base.LoadContent();
            player = new Player(new Vector2(500, 500));

            platform = new Platform(new Rectangle(700, 800, 200, 100));
            platform2 = new Platform(new Rectangle(600, 900, 100, 100));
            sprites.Add(platform);
            sprites.Add(platform2);
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