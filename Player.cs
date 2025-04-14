using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using WombatQOL.Gores;

namespace WombatQOL
{
	public class QOLPlayer : ModPlayer
	{
		public static float shakeIntensity = 0;
		public static void ScreenShake(Vector2 position, float intensity)
		{
			shakeIntensity += MathHelper.Clamp(intensity - (Vector2.Distance(position, Main.LocalPlayer.Center) / (64 * 16)), 0, 1000) * 5;
		}

		public override void ModifyScreenPosition()
		{
			//if (player.HeldItem.createTile != -1 || player.HeldItem.createWall != -1 || player.HeldItem.type == ItemID.RodofDiscord)
			//{
			//	lerpPosition *= 0.96f;
			//}
			//else
			//{
			//	lerpPosition += (Main.MouseWorld - player.position) / 300;
			//	lerpPosition *= 0.98f;
			//}

			//         Main.screenPosition += lerpPosition;
			//         Main.screenPosition -= player.velocity;

			if (shakeIntensity > 0)
			{
				Main.screenPosition += new Vector2(Main.rand.NextFloat(shakeIntensity), Main.rand.NextFloat(shakeIntensity));
				shakeIntensity *= 0.85f;
				if (shakeIntensity < 0.1f)
				{
					shakeIntensity = 0;
				}
			}
		}
	}

	//public class CorruptionWater : ModBiome
 //   {
 //       public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("WombatQOL/VileWater");

	//	public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

 //       public override bool IsBiomeActive(Player player)
 //       {
	//		return ModContent.GetInstance<Client>().VileWater && Main.bgStyle == 1;
 //       }
 //   }
}