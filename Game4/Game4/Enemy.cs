using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShootEmUp
{
    public class Enemy
    {
        Rectangle enemyRectangle;
        Texture2D enemyRexture;
        Vector2 scale;
        Vector2 offset;
        Color enemyColor;

        float speed;

        private int enemyHealth;

        public void AI()
        {
            throw new System.NotImplementedException();
        }
    }
}