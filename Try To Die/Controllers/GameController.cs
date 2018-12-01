using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Try_To_Die.Controllers;
using Try_To_Die.World;
using Microsoft.Xna.Framework.Audio;

namespace Try_To_Die.Controllers
{
    public class GameController : Controller
    {
        double speed = 10; //speed at which the player moves
        double timer = 0;
        double jumpTime = 0.4;
        SoundEffect jumpSound;
        Boolean moving = false;


        public override void Update(Entity entity, GameTime gameTime, List<Entity> sprites)
        {
            
            UseControllerInput(entity);
            UseKeyboardInputs(entity, gameTime, sprites);
            speed = entity.speed;
            if(!moving)
            {
                entity.speed = 10;
            }


            if(timer >= 0)
            {
                if (timer > jumpTime/2)
                {
                    if (CheckUpCollision(entity, sprites))
                    {
                        MoveCommand.MoveUp(entity, (int)speed);
                    }
                    else
                    {
                        timer = jumpTime / 2;
                    }
                } else
                {
                    if (CheckDownCollision(entity, sprites))
                    {
                        MoveCommand.MoveDown(entity, (int)speed);
                    }
                }
                timer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (CheckDownCollision(entity, sprites))
            {
                MoveCommand.MoveDown(entity, (int)speed);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        Boolean CheckLeftCollision(Entity player, List<Entity> sprites)
        {
            foreach(var s in sprites)
            {
                if(player.SpritePosition.Left < s.SpritePosition.Right && player.SpritePosition.Top < s.SpritePosition.Bottom - speed && player.SpritePosition.Right > s.SpritePosition.Left && player.SpritePosition.Bottom > s.SpritePosition.Top + speed)
                {
                    if (player.SpritePosition.Left > s.SpritePosition.Left)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        Boolean CheckRightCollision(Entity player, List<Entity> sprites)
        {
            foreach (var s in sprites)
            {
                if (player.SpritePosition.Left < s.SpritePosition.Right && player.SpritePosition.Top < s.SpritePosition.Bottom - speed && player.SpritePosition.Right > s.SpritePosition.Left && player.SpritePosition.Bottom > s.SpritePosition.Top + speed)
                {
                    if (player.SpritePosition.Right < s.SpritePosition.Right)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        Boolean CheckDownCollision(Entity player, List<Entity> sprites)
        {
            foreach (var s in sprites)
            {
                if (player.SpritePosition.Left < s.SpritePosition.Right - speed && player.SpritePosition.Top < s.SpritePosition.Bottom && player.SpritePosition.Right > s.SpritePosition.Left + speed && player.SpritePosition.Bottom > s.SpritePosition.Top)
                {
                    if (player.SpritePosition.Bottom < s.SpritePosition.Bottom)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        Boolean CheckUpCollision(Entity player, List<Entity> sprites)
        {
            foreach (var s in sprites)
            {
                if (player.SpritePosition.Left < s.SpritePosition.Right - speed && player.SpritePosition.Top < s.SpritePosition.Bottom + speed && player.SpritePosition.Right > s.SpritePosition.Left + speed && player.SpritePosition.Bottom > s.SpritePosition.Top)
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

        private void UseKeyboardInputs(Entity entity, GameTime gameTime, List<Entity> sprites)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D) && CheckRightCollision(entity, sprites))
            {
                MoveCommand.MoveRight(entity, (int)speed);
                moving = true;
                if(entity.speed < 20){
                    entity.speed+=0.4;
                }
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.A) && CheckLeftCollision(entity, sprites))
            {
                MoveCommand.MoveLeft(entity, (int)speed);
                moving = true;
                if(entity.speed < 20){
                    entity.speed+=0.4;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W) && timer <= 0)
            {
                entity.PlayJumpSound();
                timer = jumpTime;
                moving = true;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                //MoveCommand.MoveDown(entity, speed);
            }
            else{
                moving = false;
            }               
        }
    }
}
