using Terraria;
using Terraria.ModLoader;

namespace WombatQOL
{
	public class WombatQOL : Mod
	{
        public override void Load()
        {
            On_Main.CalculateWaterStyle += On_Main_CalculateWaterStyle;
        }

        private int On_Main_CalculateWaterStyle(On_Main.orig_CalculateWaterStyle orig, bool ignoreFountains)
        {
            if (Main.bgStyle == 1 && ModContent.GetInstance<Client>().VileWater)
            {
                return ModContent.Find<ModWaterStyle>("WombatQOL/VileWater").Slot;
            }
            else
            {
                return orig.Invoke(ignoreFountains);
            }
        }
    }
}