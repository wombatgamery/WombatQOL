using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Walls
{
	public class spikybars : ModWall
	{
		public override void SetStaticDefaults()		
		{
			Main.wallHouse[Type] = false;
			Main.wallLight[Type] = true;

			DustType = DustID.Iron;
		}
	}
}
