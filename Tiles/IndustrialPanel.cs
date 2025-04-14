using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Tiles
{
	[LegacyName("machinepanel")]
	public class IndustrialPanel : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			Main.tileMerge[Type][TileID.IronBrick] = true;
			Main.tileMerge[TileID.IronBrick][Type] = true;

			TileID.Sets.CanBeClearedDuringGeneration[Type] = false;
			TileID.Sets.CanBeClearedDuringOreRunner[Type] = false;

			DustType = DustID.Iron;
			HitSound = SoundID.Tink;

			AddMapEntry(new Color(124, 101, 98));
		}
	}

	//public class metalpanel : ModTile
	//{
	//	public override void SetStaticDefaults()
	//	{
	//		Main.tileSolid[Type] = true;
	//		Main.tileBlockLight[Type] = true;
	//		Main.tileMerge[Type][ModContent.TileType<machinerypanel>()] = true;

	//		ItemDrop = Mod.Find<ModItem>("metalpanel").Type;

	//		DustType = DustID.Torch;
	//		HitSound = SoundID.Tink;

	//		AddMapEntry(new Color(89, 80, 75));
	//	}
	//}
}
