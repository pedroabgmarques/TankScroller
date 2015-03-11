using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankScroller.Componentes
{
    public class Cena
    {
        private SpriteBatch spriteBatch;
        /// <summary>
        /// SpriteBatch desta cena
        /// </summary>
        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }
        
        private List<Sprite> sprites;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="spriteBatch">Instância de spriteBatch</param>
        public Cena(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            this.sprites = new List<Sprite>();
        }

        /// <summary>
        /// Inserir sprites na lista
        /// </summary>
        /// <param name="sprite">Sprite a acrescentar à lista</param>
        public void AddSprite(Sprite sprite)
        {
            this.sprites.Add(sprite);
            sprite.SetCena(this);
        }

        /// <summary>
        /// Atualiza todas as sprites desta cena
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public void Update(GameTime gameTime)
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.Update(gameTime);
            }
        }

        /// <summary>
        /// Desenha todas as sprites desta cena
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public void Draw(GameTime gameTime)
        {
            if (sprites.Count > 0)
            {
                spriteBatch.Begin();
                foreach (Sprite sprite in sprites)
                {
                    sprite.Draw(gameTime);
                }
                spriteBatch.End();
            }
        }
    }
}
