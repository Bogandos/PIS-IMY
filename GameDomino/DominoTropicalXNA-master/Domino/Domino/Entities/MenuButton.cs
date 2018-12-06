using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Domino.Entities
{
    class MenuButton
    {

        #region Fields

        Texture2D _image;          // Размер кнопки
        Vector2 _position;         // Позиция кнопки
        Rectangle _rectangle;      // Прямоугольник для пересечения

        Color color = new Color(255, 255, 255, 255);    // Цвет для заданного изображения

        public Vector2 size;      //Размер кнопки
            
        #endregion

        #region Properties
        
        #endregion

        #region Constructor

        public MenuButton(Texture2D nuevaImagen, GraphicsDevice graphics)
        {
            _image = nuevaImagen;

            //ScreenWidth = 1366, ScreenHeight = 768
            //ImagenWidth =  300, ImagenWidth  = 50

            size = new Vector2(graphics.Viewport.Width / 4.55f, graphics.Viewport.Height / 15.36f);
        }


        public MenuButton(Texture2D newImage, GraphicsDevice graphics, Vector2 position)
        {
            _image = newImage;

            //ScreenWidth = 1366, ScreenHeight = 768
            //ImagenWidth =  300, ImagenWidth  = 50

            size = new Vector2(graphics.Viewport.Width, graphics.Viewport.Height);
        }

        public MenuButton(Texture2D newImage, GraphicsDevice graphics, int h)
        {
            _image = newImage;

            //ScreenWidth = 1366, ScreenHeight = 768
            //ImagenWidth =  150, ImagenWidth  = 60

            size = new Vector2(graphics.Viewport.Width / 18.21f, graphics.Viewport.Height / 25.6f);

        }
        
        
        #endregion

        #region Methods/Functions

        bool clicked;
        public bool isClicked;
        public void Update(MouseState mouse)
        {


            _rectangle = new Rectangle((int)_position.X, (int)_position.Y, (int)size.X, (int)size.Y);
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(_rectangle))
            {
                if (color.A == 255) clicked = false;
                if (color.A == 0) clicked = true;
                if (clicked) color.A += 3; else color.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
            }
            else if (color.A < 255)
            {
                color.A += 3;
                isClicked = false;
            }
        }

        // Установить позицию элемента для отрисовки
        public void SetPosition(Vector2 newPosition)
        {
            _position = newPosition;
        }

        // Overload для установки положения элемента для отрисовки, а также масштаба
        public void SetPosition(Vector2 newPosition, Vector2 size)
        {
            _position = newPosition;
            this.size = size;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_image, _rectangle, color);
        }

        public void Draw(SpriteBatch spriteBatch, Color desiredColor)
        {
            spriteBatch.Draw(_image, _rectangle, desiredColor);
        }

        public void Draw(SpriteBatch spriteBatch, float depth)
        {
            spriteBatch.Draw(_image, _rectangle,null,Color.White,0f,Vector2.Zero,SpriteEffects.None, depth);
        }

        #endregion

    }   
}
