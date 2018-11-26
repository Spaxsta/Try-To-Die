
using Grimthole.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Try_To_Die.Controllers;
using Try_To_Die.Utils;

namespace Try_To_Die.Controllers
{
    public class GameController : Controller
    {
        int delta = 10; //speed at which the player moves
        double timer = 0;
        double jumpTime = 0.4;

        public override void Update(Entity entity, GameTime gameTime, List<ISprite> sprites)
        {
            UseControllerInput(entity);
            UseKeyboardInputs(entity, gameTime, sprites);
           
            if(timer >= 0)
            {
                if (timer > jumpTime/2)
                {
                    if (CheckUpCollision(entity, sprites))
                    {
                        MoveCommand.MoveUp(entity, delta);
                    }
                    else
                    {
                        timer = jumpTime / 2;
                    }
                } else
                {
                    if (CheckDownCollision(entity, sprites))
                    {
                        MoveCommand.MoveDown(entity, delta);
                    }
                }
                timer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (CheckDownCollision(entity, sprites))
            {
                MoveCommand.MoveDown(entity, delta);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        Boolean CheckLeftCollision(Entity player, List<ISprite> sprites)
        {
            foreach(var s in sprites)
            {
                if(player.SpritePosition.Left < s.SpritePosition.Right && player.SpritePosition.Top < s.SpritePosition.Bottom - delta && player.SpritePosition.Right > s.SpritePosition.Left && player.SpritePosition.Bottom > s.SpritePosition.Top + delta)
                {
                    if (player.SpritePosition.Left > s.SpritePosition.Left)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        Boolean CheckRightCollision(Entity player, List<ISprite> sprites)
        {
            foreach (var s in sprites)
            {
                if (player.SpritePosition.Left < s.SpritePosition.Right && player.SpritePosition.Top < s.SpritePosition.Bottom - delta && player.SpritePosition.Right > s.SpritePosition.Left && player.SpritePosition.Bottom > s.SpritePosition.Top + delta)
                {
                    if (player.SpritePosition.Right < s.SpritePosition.Right)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        Boolean CheckDownCollision(Entity player, List<ISprite> sprites)
        {
            foreach (var s in sprites)
            {
                if (player.SpritePosition.Left < s.SpritePosition.Right - delta && player.SpritePosition.Top < s.SpritePosition.Bottom && player.SpritePosition.Right > s.SpritePosition.Left + delta && player.SpritePosition.Bottom > s.SpritePosition.Top)
                {
                    if (player.SpritePosition.Bottom < s.SpritePosition.Bottom)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        Boolean CheckUpCollision(Entity player, List<ISprite> sprites)
        {
            foreach (var s in sprites)
            {
                if (player.SpritePosition.Left < s.SpritePosition.Right - delta && player.SpritePosition.Top < s.SpritePosition.Bottom + delta && player.SpritePosition.Right > s.SpritePosition.Left + delta && player.SpritePosition.Bottom > s.SpritePosition.Top)
                {
                    if (player.SpritePosition.Top > s.SpritePosition.Top)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void UseControllerInput(Entity entity)
        {
        }

        private void UseKeyboardInputs(Entity entity, GameTime gameTime, List<ISprite> sprites)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D) && CheckRightCollision(entity, sprites))
            {
                MoveCommand.MoveRight(entity, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && CheckLeftCollision(entity, sprites))
            {
                MoveCommand.MoveLeft(entity, delta);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && timer <= 0)
            {
                timer = jumpTime;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                //MoveCommand.MoveDown(entity, delta);
            }
        }
    }
}
