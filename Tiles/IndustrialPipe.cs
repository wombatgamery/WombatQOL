using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Tiles
{
	[LegacyName("copperpipe")]
	public class IndustrialPipe : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			TileID.Sets.DrawsWalls[Type] = true;
			TileID.Sets.CanBeClearedDuringGeneration[Type] = false;
			TileID.Sets.CanBeClearedDuringOreRunner[Type] = false;

			DustType = DustID.Copper;
			HitSound = SoundID.Item52;

			AddMapEntry(new Color(134, 131, 153));
		}
	}
}
