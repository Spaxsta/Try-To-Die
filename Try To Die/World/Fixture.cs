using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;


namespace Try_To_Die.World
{
    public abstract class Fixture : Entity
    {
        protected Fixture(String name, Vector2 coords, int width, int height) : base(name, coords, width, height)
        {
            this.name = name;
            SpritePosition = new Rectangle((int)coords.X, (int)coords.Y, width, height);
        }
    }
}