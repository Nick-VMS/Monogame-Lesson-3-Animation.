﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Lesson_3___Animation_
{
    internal class Tribble
{
        private Texture2D _texture;
        private Rectangle _rectangle;
        private Vector2 _speed;

        public Tribble(Texture2D texture, Rectangle rect, Vector2 speed)
        {
            _texture = texture;
            _rectangle = rect;
            _speed = speed;
        }
        public Texture2D Texture
        {
            get { return _texture; }
        }
        public Rectangle Bounds
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }
        public void Move()
        {
            _rectangle.Offset(_speed);
        }
    }
}
