using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Walls
{
	public class MetalRailing : ModWall
	{
		public override void SetStaticDefaults()		
		{
			Main.wallHouse[Type] = true;
			Main.wallLight[Type] = true;

			DustType = DustID.Iron;
			HitSound = SoundID.Tink;

			AddMapEntry(new Color(72, 66, 74));
		}
	}
}
