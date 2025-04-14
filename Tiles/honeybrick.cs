using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Tiles
{
	public class honeybrick : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLargeFrames[Type] = 2;

			Main.tileMerge[Type][TileID.Hive] = true;
			Main.tileMerge[TileID.Hive][Type] = true;

			TileID.Sets.CanBeClearedDuringOreRunner[Type] = false;

			DustType = DustID.Hive;
			HitSound = SoundID.Tink;

			AddMapEntry(new Color(237, 105, 0));
		}

  //      public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
  //      {
		//	Texture2D texture = ModContent.Request<Texture2D>("WombatQOL/Tiles/honeybrick-draw").Value;
		//	Vector2 zero = Main.drawToScreen ? Vector2.Zero : new(Main.offScreenRange);
		//	Rectangle frame = new(0, 0, 16, 16);

		//	if (Main.tile[i, j - 1].TileType != Type)
		//	{
		//		frame.X += 16 * 2;
		//	}

		//	if (i % 2 == 1)
		//	{
		//		frame.X += 16;
		//	}
		//	if (j % 2 == 1)
		//	{
		//		frame.Y += 16;
		//	}

		//	if (!WorldGen.SolidTile(i - 1, j))
		//	{
		//		frame.X += 2;
		//		frame.Width -= 2;
		//	}
		//	if (!WorldGen.SolidTile(i + 1, j))
		//	{
		//		frame.Width -= 2;
		//	}
		//	if (!WorldGen.SolidTile(i, j - 1))
		//	{
		//		frame.Y += 2;
		//		frame.Height -= 2;
		//	}
		//	if (!WorldGen.SolidTile(i, j + 1))
		//	{
		//		frame.Height -= 2;
		//	}

		//	//if (Main.tile[i, j - 1].WallType != Type)
		//	//{
		//	//	frame.Y -= 16;
		//	//}
		//	//if (Main.tile[i, j + 1].WallType != Type)
		//	//{
		//	//	frame.Y += 16;
		//	//}

		//	Main.spriteBatch.Draw(texture, new Vector2((i * 16) - (int)Main.screenPosition.X, (j * 16) - (int)Main.screenPosition.Y) + zero, frame, Lighting.GetColor(i, j), 0f, Vector2.Zero, 1f, 0, 0f);
		//}
    }
}
