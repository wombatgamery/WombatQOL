using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Walls
{
	public class honeybrickwall : ModWall
	{
		public override void SetStaticDefaults()		
		{
			Main.wallHouse[Type] = true;
			Main.wallBlend[Type] = 1;
			Main.wallLargeFrames[Type] = 2;

			DustType = DustID.Hive;

			AddMapEntry(new Color(100, 51, 27));
		}
	}

	public class honeybrickwallunsafe : ModWall
	{
		public override string Texture => "WombatQOL/Walls/honeybrickwall";

		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = false;
			Main.wallBlend[Type] = 1;
			Main.wallLargeFrames[Type] = 2;

			DustType = DustID.Hive;

			AddMapEntry(new Color(100, 51, 27));
		}

        public override void KillWall(int i, int j, ref bool fail)
        {
			fail = true;
        }

        public override bool CanExplode(int i, int j)
        {
			return false;
        }
    }
}
