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

    class PhysicsEngine
    {
        public void Update(List<Entity> s)
        {
            for(int i=0; i<s.Count-1; i++)
            {
                Vector2 normal = new Vector2(0,0);
                Entity a = s[i];
                Entity b = s[i+1];
                if (CollisonDetect(a,b)){
                    ResolveCollision(a,b);
                }
}
            }


        }


        public Boolean CollisionDetect(Entity a, Entity b)
        {
            // Exit with no intersection if found separated along an axis
            if(a.SpritePosition.x + a.SpritePosition.Width < b.SpritePosition.x || a.SpritePosition.x > b.SpritePosition.x + b.SpritePosition.Height){
                return false;
            }
            if(a.SpritePosition.y + a.SpritePosition.Width < b.SpritePosition.y || a.SpritePosition.y > b.SpritePosition.y + b.SpritePosition.Height){
                return false;
            }
 
            // No separating axis found, therefor there is at least one overlapping axis
            return true;
        }

        public void ResolveCollision( Entity a, Entity b )
        {
          // Calculate relative velocity
          Vector2 rv = b.velocity - a.velocity;
 
          // Calculate relative velocity in terms of the normal direction
          float velAlongNormal = DotProduct( rv, normal );
 
          // Do not resolve if velocities are separating
          if(velAlongNormal > 0){
            return;
         }
            
          // Calculate restitution
          float e = min( a.restitution, b.restitution);
 
          // Calculate impulse scalar
          float j = -(1 + e) * velAlongNormal;
          j = j / (1 / a.mass + 1 / b.mass);
 
          // Apply impulse
          Vector2 impulse = j * normal;
          a.velocity -= 1 / a.mass * impulse;
          b.velocity += 1 / b.mass * impulse;
        }



        public float DotProduct(Vector2 a, Vector2 b){
            return a.X * b.X + a.Y + b.Y;
        }
}
