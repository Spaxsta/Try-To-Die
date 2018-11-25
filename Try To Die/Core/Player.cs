using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Try_To_Die.Utils;

namespace Try_To_Die.Core
{
    public class Player : Entity
    {
        // All the players stats.
        readonly int level = 1;
        readonly int experience = 0;
        public Rectangle pos;


        public int Speed { get; }

        // A list of all attacks the player knows.

        public Player(Vector2 coords) : base("Sprites/man1", coords,
            ScreenManager.Instance.TileSize, ScreenManager.Instance.TileSize)
        {
            health = 100;
            speed = 10; 
            pos = new Rectangle(ScreenManager.Instance.Dimensions.Width / 2 - ScreenManager.Instance.TileSize, ScreenManager.Instance.Dimensions.Height / 2 - ScreenManager.Instance.TileSize, SpritePosition.Width, SpritePosition.Height);
        }

        public override void Update(Rectangle windowDimensions, GameTime gt, ContentManager content)
        {
            currentAnimation = IdleFront;
            if (SpritePosition.Left < 0)
            {
                MoveCommand.MoveRight(this, Math.Abs(0 - SpritePosition.Left));
                health = 0;
            }

            if (SpritePosition.Top < 0)
            {
                MoveCommand.MoveDown(this, Math.Abs(0 - SpritePosition.Top));
            }

            if (SpritePosition.Right > ScreenManager.Instance.Dimensions.Width)
            {
                MoveCommand.MoveLeft(this, Math.Abs(ScreenManager.Instance.Dimensions.Width - SpritePosition.Right));
            }

            if (SpritePosition.Bottom > ScreenManager.Instance.Dimensions.Height)
            {
                MoveCommand.MoveUp(this, Math.Abs(ScreenManager.Instance.Dimensions.Height - SpritePosition.Bottom));
            }


            LoadContent(content);
        }

    }
}