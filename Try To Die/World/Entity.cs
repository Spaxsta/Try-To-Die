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

        public double speed {get; set;}

        public double health { get; set; }

        public Vector2 velocity = 0; //keeping speed for now so Devon's stuff doesn't break, will switch to velocity
        public float restitution = 1; //bounciness of an object, keeping it at 1 for now
        public float mass = 1;
        public float inv_mass = 1; //Physics Engine will use inverse of mass most of the time instead of mass so having this in here cause its easier

        public String Name { get; protected set; }

        public Rectangle SpritePosition { get; set; }


        // Default Constructor for entities.
        protected Entity(String name, Rectangle spritePos)
        {
            this.name = name;
            SpritePosition = spritePos;
            canMove = false;
            if(mass == 0) {
                inv_mass = 0;
            }else {
                inv_mass = 1 / mass;
            }
        }

        public virtual void PlayJumpSound(){
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