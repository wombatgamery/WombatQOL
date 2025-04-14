using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace WombatQOL.Tiles
{
    [LegacyName("ritualcandle")]
    public class CeremonialCandle : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;

			TileID.Sets.DisableSmartCursor[Type] = true;

			TileObjectData.newTile.FullCopyFrom(TileID.LavaLamp);
			TileObjectData.newTile.Height = 1;
			TileObjectData.newTile.Origin = new Point16(0, 0);
            TileObjectData.newTile.CoordinateHeights = new int[]{ 18 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.RandomStyleRange = 6;
			TileObjectData.newTile.StyleWrapLimit = 6;
			TileObjectData.newTile.WaterDeath = true;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.addTile(Type);

			AddMapEntry(new Color(255, 248, 214), Language.GetText("ItemName.Candle"));

			RegisterItemDrop(ModContent.ItemType<Items.CeremonialCandle>());
			DustType = DustID.Hive;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			if (Main.tile[i, j].TileFrameY == 0)
			{
				float mult = Main.rand.NextFloat(0.85f, 1f);
                r = (float)(255f / 255f) / 1.5f * mult;
                g = (float)(153f / 255f) / 1.5f * mult;
                b = (float)(50f / 255f) / 1.5f * mult;
            }
		}

        public override void HitWire(int i, int j)
        {
            Main.tile[i, j].TileFrameY = (short)(Main.tile[i, j].TileFrameY == 0 ? 20 : 0);
        }

        public override bool RightClick(int i, int j)
        {
			Main.tile[i, j].TileFrameY = (short)(Main.tile[i, j].TileFrameY == 0 ? 20 : 0);
            SoundEngine.PlaySound(SoundID.Mech, new Vector2(i * 16, j * 16));

            return true;
        }

        public override void MouseOver(int i, int j)
        {
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
			player.cursorItemIconID = ModContent.ItemType<Items.CeremonialCandle>();
		}

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];

            if (tile.TileFrameY == 0)
            {
                Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
                if (Main.drawToScreen)
                {
                    zero = Vector2.Zero;
                }
                //Main.spriteBatch.Draw(ModContent.Request<Texture2D>("WombatQOL/Tiles/ritualcandle").Value, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 + 2 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY + 18, 16, 16), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);


                ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i);
                Color color = new Color(100, 100, 100, 0);
                int offsetY = -4;
                for (int k = 0; k < 7; k++)
                {
                    float x = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                    float y = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
                    Main.spriteBatch.Draw(ModContent.Request<Texture2D>(Texture).Value, new Vector2((float)(i * 16 - (int)Main.screenPosition.X) + x, (float)(j * 16 - (int)Main.screenPosition.Y + offsetY) + y) + zero, new Rectangle(tile.TileFrameX, 40, 16, 18), color, 0f, default(Vector2), 1f, i % 2 == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
                }
            }
		}
	}
}