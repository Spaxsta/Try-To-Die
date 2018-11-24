using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Try_To_Die.Utils;

namespace Try_To_Die.Controllers
{
    public abstract class Controller
    {
        public abstract void Update(Entity entity);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}