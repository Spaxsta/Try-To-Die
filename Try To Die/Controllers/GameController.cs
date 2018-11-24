
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

        public override void Update(Entity entity)
        {
            UseControllerInput(entity);
            UseKeyboardInputs(entity);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        public void UseControllerInput(Entity entity)
        {
        }

        private void UseKeyboardInputs(Entity entity)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                MoveCommand.MoveRight(entity, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                MoveCommand.MoveLeft(entity, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                MoveCommand.MoveUp(entity, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                MoveCommand.MoveDown(entity, delta);
            }
        }
    }
}
