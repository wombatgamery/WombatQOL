using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Gores
{
    public class bulletcasing : ModGore
    {
        public override bool Update(Gore gore)
        {
            if (gore.velocity == Vector2.Zero)
            {
                gore.timeLeft = 0;
            }
            return true;
        }
    }
}