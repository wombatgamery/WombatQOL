using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Tiles
{
	public class devtile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			TileID.Sets.CanBeClearedDuringOreRunner[Type] = false;

			AddMapEntry(new Color(255, 255, 255));
		}
	}
}
