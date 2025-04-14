using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Walls
{
	[LegacyName("machinewall")]
	public class IndustrialWall : ModWall
	{
		public override void SetStaticDefaults()		
		{
			Main.wallHouse[Type] = true;
			Main.wallLargeFrames[Type] = 2;

			DustType = DustID.Iron;

			AddMapEntry(new Color(53, 49, 53));
		}
	}
}
