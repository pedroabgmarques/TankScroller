using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankScroller.Componentes
{
    public class Tank : Sprite
    {
        private Sprite turret;

        public Tank(ContentManager content) : base(content, "tank_body")
        {
            this.turret = new Sprite(content, "tank_turret");
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            turret.Draw(gameTime);
        }

        public override void SetCena(Cena cena)
        {
            this.cena = cena;
            turret.SetCena(cena);
        }
    }
}
