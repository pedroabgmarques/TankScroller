using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankScroller.Componentes
{
    class Sprite
    {
        private Texture2D image;
        private Vector2 position;
        private Vector2 size;
        private float rotation;

        /// <summary>
        /// Construtor de sprite
        /// </summary>
        /// <param name="content">Content manager</param>
        /// <param name="assetName">Nome do asset a carregar</param>
        public Sprite(ContentManager content, String assetName)
        {
            this.rotation = 0f;
            this.size = new Vector2(1, 1);
            this.position = Vector2.Zero;
            this.image = content.Load<Texture2D>(assetName);
        }

        /// <summary>
        /// Desenha a sprite no ecrã
        /// </summary>
        /// <param name="spriteBatch">Instância de spriteBatch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle pos = Camara.WorldSize2PixelRectangle(this.position, this.size);
            spriteBatch.Draw(this.image, pos, Color.White);
        }
    }
}
