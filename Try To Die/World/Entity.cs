using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Try_To_Die.World
{
    /// <summary>
    /// An Entity is any Sprite that is 'alive.'
    /// </summary>
    public abstract class Entity 
    {
        protected String name;

        public Texture2D texture;

        public String Name { get; protected set; }

        public Rectangle SpritePosition { get; set; }


        // Default Constructor for entities.
        protected Entity(String name, Vector2 coords, int width, int height)
        {
            this.name = name;
            SpritePosition = new Rectangle((int)coords.X, (int)coords.Y, width, height);
        }

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(Rectangle windowDimensions, GameTime gt, ContentManager content);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, SpritePosition, Color.White);
            spriteBatch.End();
        }
    }
}