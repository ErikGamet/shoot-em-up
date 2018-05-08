using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace ShootEmUp
{
    public class Enemy
    {
        Texture2D enemyTexture;
        Rectangle enemyRectangle;
        Vector2 enemyPosition;
        Vector2 origin;
        Vector2 enemyVelocity;
        Vector2 patrolPoint = new Vector2(100,0);
        float speed = 2;
        Vector2 dir = new Vector2(1,0);
        float rotation = 0f;
        float distance;
        float oldDistance;

        public Enemy(Texture2D newTexture, Vector2 newposition, float newDistance)
        {
            enemyTexture = newTexture;
            enemyPosition = newposition;
            distance = newDistance;
            oldDistance = distance;
            patrolPoint.X = enemyPosition.X;
        }

        public void Update()
        {
            enemyPosition += dir*speed;
            Console.WriteLine(patrolPoint);
            origin = new Vector2(enemyTexture.Width / 0.8f, enemyTexture.Height / 0.8f);
            if (enemyPosition.X >= patrolPoint.X + distance)
            {
                dir = new Vector2(-1, 0);

            }
            else if (enemyPosition.X <= patrolPoint.X - distance)
            {
                dir = new Vector2(1, 0);

            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (enemyVelocity.X > 0)
                spriteBatch.Draw(enemyTexture, enemyPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.FlipHorizontally, 0f);
            else
                spriteBatch.Draw(enemyTexture, enemyPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
        }

    }
}