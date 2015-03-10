using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankScroller.Componentes
{
    static public class Camara
    {

        static private GraphicsDeviceManager graphics;
        /// <summary>
        /// Instância do graphics device
        /// </summary>
        static public GraphicsDeviceManager Graphics
        {
            set { graphics = value; }
        }
        

        static private float worldWidth;
        /// <summary>
        /// Largura do mundo
        /// </summary>
        static public float WorldWith
        {
            get { return worldWidth; }
            set { worldWidth = value; }
        }

        static private float ratio;

        static private Vector2 target;
        /// <summary>
        /// Coordenadas virtuais centrais da camara
        /// </summary>
        static public Vector2 Target
        {
            set { target = value; }
        }

        //Última largura em pixels que a janela teve
        static private int lastSeenPixelWidth = 0;

        static private void calcularRatio()
        {
            if (Camara.lastSeenPixelWidth != Camara.graphics.PreferredBackBufferWidth)
            {
                //Só fazemos a divisão (pesada) se os valores tiverem alterado
                Camara.ratio = Camara.graphics.PreferredBackBufferWidth / Camara.WorldWith;
                Camara.lastSeenPixelWidth = Camara.graphics.PreferredBackBufferWidth;
            }
        }

        /// <summary>
        /// Traduz coordenadas do mundo virtual para coordenadas em pixeis
        /// </summary>
        /// <param name="point">Coordenada no mundo virtual</param>
        /// <returns>Coordenada em pixeis</returns>
        static public Vector2 WorldPoint2Pixels(Vector2 point)
        {
            Camara.calcularRatio();
            Vector2 pixelPoint = new Vector2();

            //Calcular pixels em relação ao target da camara (centro)
            pixelPoint.X = (int)((point.X - target.X) * Camara.ratio + 0.5f);
            pixelPoint.Y = (int)((point.Y - target.Y) * Camara.ratio + 0.5f);

            //projetar pixeis calculados para o canto inferior esquerdo do ecrã
            pixelPoint.X += lastSeenPixelWidth / 2;
            pixelPoint.Y += Camara.graphics.PreferredBackBufferHeight / 2;

            //inverter coordenadas Y
            pixelPoint.Y = Camara.graphics.PreferredBackBufferHeight - pixelPoint.Y;

            return pixelPoint;
        }

        /// <summary>
        /// Dá o tamanho em pixels de um objeto do jogo
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        static public Rectangle WorldSize2PixelRectangle(Vector2 pos, Vector2 size)
        {
            Camara.calcularRatio();
            Vector2 pixelPos = WorldPoint2Pixels(pos);

            //Calcular tamanho em pixeis da sprite
            int pixelWidth = (int)((size.X * Camara.ratio) + 0.5f);
            int pixelHeight = (int)((size.Y * Camara.ratio) + 0.5f);

            //projetar para o centro da sprite
            pixelPos.X -= pixelWidth / 2;
            pixelPos.Y -= pixelHeight / 2;

            return new Rectangle((int)pixelPos.X, (int)pixelPos.Y, pixelWidth, pixelHeight);
        }

    }
}
