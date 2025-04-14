using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Tiles
{
	public class concrete : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileBlendAll[Type] = true;

			Main.tileMerge[Type][TileID.Mud] = true;
			Main.tileMerge[TileID.Mud][Type] = true;
			//Main.tileMerge[Type][TileID.JungleGrass] = true;
			//Main.tileMerge[TileID.JungleGrass][Type] = true;

			TileID.Sets.CanBeClearedDuringOreRunner[Type] = false;

			DustType = DustID.Stone;
			HitSound = SoundID.Tink;

			AddMapEntry(new Color(109, 102, 99));
		}
	}
}
