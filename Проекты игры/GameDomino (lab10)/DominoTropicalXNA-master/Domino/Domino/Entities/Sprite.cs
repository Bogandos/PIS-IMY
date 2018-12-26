using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Domino.Entities
{
    public class Sprite
    {
        #region Переменные

        // Нарисовать спрайт
        Texture2D _image;

        // Данные о коллизиях
        int _collision;

        // Данные перемещения
        protected Vector2 _speed;
        protected Vector2 _position;
        //MouseState PreviousMouseState;

        #endregion

        #region Свойства


        public Texture2D Image
        {
            get { return _image; }
            set { _image = value; }
        }
        

        public int Collision
        {
            get { return _collision; }
            set { _collision = value; }
        }

        public Vector2 Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        #endregion

        #region Конструкторы

        public Sprite()
         
        { }

        public Sprite(Texture2D Image,
            int Collision, Vector2 Speed,
            Vector2 Position)
        {
            this.Image = Image;
            this.Collision = Collision;
            this.Speed = Speed;
            this.Position = Position;
           
        }
        
        #endregion

        #region Функции

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
            
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Нарисовать спрайт
            spriteBatch.Draw(Image,
                Position, null,
                Color.White, 0, Vector2.Zero,
                .07f, SpriteEffects.None, 1);
        }

        #endregion

        #region События
        
        #endregion

    }
}
