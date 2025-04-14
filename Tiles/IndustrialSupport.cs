using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace WombatQOL.Tiles
{
	[LegacyName("machinebeam")]
	public class IndustrialSupport : ModTile
	{
		public override void SetStaticDefaults()
		{
			//Main.tileFrameImportant[Type] = true;
			Main.tileBlockLight[Type] = false;
			Main.tileLavaDeath[Type] = false;
			Main.tileMerge[Type][ModContent.TileType<IndustrialPipe>()] = true;

			TileID.Sets.DisableSmartCursor[Type] = true;
			TileID.Sets.IsBeam[Type] = true;

			DustType = DustID.Iron;
			HitSound = SoundID.Tink;

			AddMapEntry(new Color(68, 64, 68));
		}

        public override void PlaceInWorld(int i, int j, Item item)
        {
			Tile tile = Main.tile[i, j];

			tile.TileFrameX = (short)(Main.rand.Next(3) * 18);
		}

  //      public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
		//{
		//	Tile tile = Main.tile[i, j];

		//	if (!Main.tile[i, j - 1].HasTile || Main.tile[i, j - 1].TileType != Type)//!Main.tile[i, j - 1].HasTile || !Main.tileSolid[Main.tile[i, j - 1].TileType] && Main.tile[i, j - 1].TileType != Type)
		//	{
		//		tile.TileFrameY = 0;
		//	}
		//	else if (!Main.tile[i, j + 1].HasTile || Main.tile[i, j + 1].TileType != Type)
		//	{
		//		tile.TileFrameY = 36;
		//	}
		//	else
		//	{
		//		tile.TileFrameY = 18;
		//	}

		//	return false;
		//}
	}
}