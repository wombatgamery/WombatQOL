using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace WombatQOL.Tiles
{
	public class electriclight : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileLavaDeath[Type] = false;

			TileID.Sets.FramesOnKillWall[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.StyleTorch);
			TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.AnchorWall = true;
			TileObjectData.addTile(Type);

			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Light");
			AddMapEntry(new Color(255, 248, 179), name);

			DustType = DustID.Iron;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Main.tile[i, j];
			if (tile.TileFrameX < 18)
			{
				r = (float)(204f / 255f);
				g = (float)(204f / 255f);
				b = (float)(255f / 255f);
			}
		}

		public override void HitWire(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			if (tile.TileFrameX < 18)
			{
				tile.TileFrameX = 18;
			}
			else tile.TileFrameX = 0;
		}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}
			if (tile.TileFrameX == 0)
			{
				Main.spriteBatch.Draw(ModContent.Request<Texture2D>("WombatQOL/Tiles/electriclight").Value, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY + 18, 16, 16), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			}
		}
	}

	public class electriclightfaulty : ModTile
	{
        public override void SetStaticDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileLavaDeath[Type] = false;

			TileID.Sets.FramesOnKillWall[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.StyleTorch);
			TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.AnchorWall = true;
			TileObjectData.addTile(Type);

			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Light");
			AddMapEntry(new Color(255, 248, 179), name);

			DustType = DustID.Iron;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Main.tile[i, j];
			float light = WorldGen.genRand.NextFloat(0.4f, 0.5f);
			if (tile.TileFrameX < 18)
			{
				r = (float)(204f / 255f) * light;
				g = (float)(204f / 255f) * light;
				b = (float)(255f / 255f) * light;
			}
		}

		//public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
		//{
		//	Tile tile = Main.tile[i, j];

		//	if (tile.WallType == 0)
		//	{
		//		WorldGen.KillTile(i, j);
		//	}

		//	return false;
		//}

		public override void HitWire(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			if (tile.TileFrameX < 18)
			{
				tile.TileFrameX = 18;
			}
			else tile.TileFrameX = 0;
		}

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            if (tile.TileFrameX == 0)
            {
				int brightness = Main.rand.Next(0, 255);

                Main.spriteBatch.Draw(ModContent.Request<Texture2D>("WombatQOL/Tiles/electriclight").Value, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY + 18, 16, 16), new Color(100, 100, 100, Main.rand.Next(0, 255)), 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);

                if (Main.rand.NextBool(10))
                {
                    Dust dust = Dust.NewDustDirect(new Vector2(i, j) * 16, 16, 16, DustID.Electric, Scale: Main.rand.NextFloat(0.5f, 1));
                    dust.velocity = Main.rand.NextVector2Circular(2, 2);
                }
            }
        }
    }
}