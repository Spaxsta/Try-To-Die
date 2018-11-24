
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

        public override void Update(Entity entity, GameTime gameTime)
        {
            UseControllerInput(entity);
            UseKeyboardInputs(entity, gameTime);
            if(timer >= 0)
            {
                if (timer > jumpTime/2)
                {
                    MoveCommand.MoveUp(entity, delta);
                    
                } else
                {
                    MoveCommand.MoveDown(entity, delta);
                }
                timer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        public void UseControllerInput(Entity entity)
        {
        }

        private void UseKeyboardInputs(Entity entity, GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                MoveCommand.MoveRight(entity, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
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
