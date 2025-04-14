using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using WombatQOL.Gores;

namespace WombatQOL
{
	public class QOLItem : GlobalItem
	{
		//public override void HoldItem(Item item, Player player)
		//{
  //          if (ModContent.GetInstance<P2>().BulletCasings && player.itemAnimation == player.itemAnimationMax - 1 && !ModLoader.TryGetMod("TerrariaOverhaul", out Mod mod))
  //          {
  //              if (item.useAmmo == AmmoID.Bullet)
  //              {
  //                  int goreCount = 1;
  //                  if (item.type == ItemID.Boomstick || item.type == ItemID.Shotgun)
  //                  {
  //                      goreCount = 3;
  //                  }
  //                  if (item.type == ItemID.TacticalShotgun)
  //                  {
  //                      goreCount = 6;
  //                  }

  //                  Vector2 mouseDistance = Main.MouseWorld - player.Center;
  //                  Vector2 dustDirection = -mouseDistance.SafeNormalize(Vector2.UnitX);
  //                  for (int i = 0; i < goreCount; i++)
  //                  {
  //                      Gore.NewGore(player.GetSource_ItemUse(item), player.Center - dustDirection * 10, dustDirection * 2 + player.velocity, ModContent.GoreType<bulletcasing>(), 1);
  //                  }
  //              }
  //          }
  //      }
	}

	public class BetterRecipes : ModSystem
	{
		public override void PostAddRecipes()
		{
			Recipe recipe;

			if (ModContent.GetInstance<Server>().DyeMixing)
			{
                #region dye
                DyeCombine(ItemID.YellowDye, ItemID.RedDye, ItemID.GreenDye); // primary and secondary colours
				DyeCombine(ItemID.CyanDye, ItemID.GreenDye, ItemID.BlueDye);
				DyeCombine(ItemID.VioletDye, ItemID.RedDye, ItemID.BlueDye);

				DyeCombine(ItemID.BrownDye, ItemID.RedDye, ItemID.GreenDye, ItemID.BlueDye);
				DyeCombine(ItemID.BrownDye, ItemID.YellowDye, ItemID.CyanDye, ItemID.VioletDye);

				//////////////////////////////////////////////////////////

				DyeCombine(ItemID.OrangeDye, ItemID.RedDye, ItemID.YellowDye); // basic combinations
				DyeCombine(ItemID.LimeDye, ItemID.YellowDye, ItemID.GreenDye);
				DyeCombine(ItemID.TealDye, ItemID.GreenDye, ItemID.CyanDye);
				DyeCombine(ItemID.SkyBlueDye, ItemID.CyanDye, ItemID.BlueDye);
				DyeCombine(ItemID.PurpleDye, ItemID.BlueDye, ItemID.VioletDye);
				DyeCombine(ItemID.PinkDye, ItemID.VioletDye, ItemID.RedDye);

                DyeCombine(ItemID.VioletDye, ItemID.PurpleDye, ItemID.PinkDye);




                DyeCombine(ItemID.YellowPaint, ItemID.RedPaint, ItemID.GreenPaint); // primary and secondary colours
				DyeCombine(ItemID.CyanPaint, ItemID.GreenPaint, ItemID.BluePaint);
				DyeCombine(ItemID.VioletPaint, ItemID.RedPaint, ItemID.BluePaint);

				DyeCombine(ItemID.BrownPaint, ItemID.RedPaint, ItemID.GreenPaint, ItemID.BluePaint);
				DyeCombine(ItemID.BrownPaint, ItemID.YellowPaint, ItemID.CyanPaint, ItemID.VioletPaint);

				//////////////////////////////////////////////////////////

				DyeCombine(ItemID.OrangePaint, ItemID.RedPaint, ItemID.YellowPaint); // basic combinations
				DyeCombine(ItemID.LimePaint, ItemID.YellowPaint, ItemID.GreenPaint);
				DyeCombine(ItemID.TealPaint, ItemID.GreenPaint, ItemID.CyanPaint);
				DyeCombine(ItemID.SkyBluePaint, ItemID.CyanPaint, ItemID.BluePaint);
				DyeCombine(ItemID.PurplePaint, ItemID.BluePaint, ItemID.VioletPaint);
				DyeCombine(ItemID.VioletPaint, ItemID.PurplePaint, ItemID.PinkPaint);
				DyeCombine(ItemID.PinkPaint, ItemID.VioletPaint, ItemID.RedPaint);
                #endregion
            }

            if (ModContent.GetInstance<Server>().EasyWings)
            {
				DisableRecipes(ItemID.HarpyWings);
				recipe = Recipe.Create(ItemID.HarpyWings);
				recipe.AddIngredient(ItemID.Feather, 50);
				recipe.AddIngredient(ItemID.SoulofFlight, 20);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();

				//DisableRecipes(ItemID.BoneWings);
				//recipe = Recipe.Create(ItemID.HarpyWings);
				//recipe.AddIngredient(ItemID.Bone, 40);
				//recipe.AddIngredient(ItemID.SoulofFlight, 20);
				//recipe.AddTile(TileID.MythrilAnvil);
				//recipe.Register();

				//DisableRecipes(ItemID.SpookyWings);
				//recipe = Recipe.Create(ItemID.HarpyWings);
				//recipe.AddIngredient(ItemID.SpookyWood, 200);
				//recipe.AddIngredient(ItemID.SoulofFlight, 20);
				//recipe.AddTile(TileID.MythrilAnvil);
				//recipe.Register();
			}

			if (ModContent.GetInstance<Server>().SpectrePaintUpgrade)
			{
				DisableRecipes(ItemID.SpectrePaintbrush);
				DisableRecipes(ItemID.SpectrePaintRoller);
				DisableRecipes(ItemID.SpectrePaintScraper);

				recipe = Recipe.Create(ItemID.SpectrePaintbrush);
				recipe.AddIngredient(ItemID.Paintbrush);
				recipe.AddIngredient(ItemID.SpectreBar, 6);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
				recipe = Recipe.Create(ItemID.SpectrePaintRoller);
				recipe.AddIngredient(ItemID.PaintRoller);
				recipe.AddIngredient(ItemID.SpectreBar, 6);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
				recipe = Recipe.Create(ItemID.SpectrePaintScraper);
				recipe.AddIngredient(ItemID.PaintScraper);
				recipe.AddIngredient(ItemID.SpectreBar, 6);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
		}

		private void DisableRecipes(int item)
		{
			for (int index = 0; index < Main.recipe.Length; index++)
			{
				if (Main.recipe[index] != null && Main.recipe[index].TryGetResult(item, out Item result))
				{
					Main.recipe[index].DisableRecipe();
				}
			}
		}

		private void DyeCombine(int result, int ingredient1, int ingredient2, int ingredient3 = -1)
		{
			Recipe recipe = Recipe.Create(result, ingredient3 != -1 ? 3 : 2);
			recipe.AddIngredient(ingredient1);
			recipe.AddIngredient(ingredient2);
			if (ingredient3 != -1) { recipe.AddIngredient(ingredient3); }

			recipe.AddTile(TileID.DyeVat);
			recipe.Register();
		}
	}
}