﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankScroller.Componentes
{
    public class Sprite
    {
        private Texture2D image;
        protected Vector2 position;
        private Vector2 size;
        private float rotation;
        protected Cena cena;

        /// <summary>
        /// Construtor de sprite
        /// </summary>
        /// <param name="content">Content manager</param>
        /// <param name="assetName">Nome do asset a carregar</param>
        public Sprite(ContentManager content, String assetName)
        {
            this.rotation = 0f;
            this.position = Vector2.Zero;
            this.image = content.Load<Texture2D>(assetName);
            this.size = new Vector2(1f, (float)image.Height / (float)image.Width);
        }

        public virtual void Scale(float scale)
        {
            this.size *= scale;
        }

        public Sprite Scl(float scale)
        {
            this.Scale(scale);
            return this;
        }

        /// <summary>
        /// Seta a cena a que este sprite pertence
        /// </summary>
        /// <param name="cena">Cena</param>
        public virtual void SetCena(Cena cena)
        {
            this.cena = cena;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Desenha a sprite no ecrã
        /// </summary>
        /// <param name="spriteBatch">Instância de spriteBatch</param>
        public virtual void Draw(GameTime gameTime)
        {
            Rectangle pos = Camara.WorldSize2PixelRectangle(this.position, this.size);
            cena.SpriteBatch.Draw(this.image, pos, null, Color.White,
                this.rotation, new Vector2(image.Width / 2, image.Height / 2), SpriteEffects.None, 0);
        }

        public virtual void SetRotation(float r)
        {
            this.rotation = r;
        }

        public void Dispose()
        {
            this.image.Dispose();
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public Sprite At(Vector2 p)
        {
            this.SetPosition(p);
            return this;
        }
    }
}
