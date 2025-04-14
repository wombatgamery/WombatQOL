using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items
{
	public class electriclight : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Electric Light");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.DirtBlock);
			Item.width = 7;
			Item.height = 7;
			Item.maxStack = 999;
			Item.createTile = ModContent.TileType<Tiles.electriclight>();
		}

		public override void AddRecipes()
		{
            Recipe recipe;

            recipe = Recipe.Create(Type, 2);
            recipe.AddIngredient(ItemID.Glass);
            recipe.AddIngredient(ItemID.Wire, 2);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();
        }
	}

	public class electriclightfaulty : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Electric Light (Faulty)");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ModContent.ItemType<electriclight>());
			Item.createTile = ModContent.TileType<Tiles.electriclightfaulty>();
		}

		public override void AddRecipes()
		{
			Recipe recipe;

			recipe = Recipe.Create(Type);
			recipe.AddIngredient(ModContent.ItemType<electriclight>());
			recipe.Register();

			recipe = Recipe.Create(ModContent.ItemType<electriclight>());
			recipe.AddIngredient(Type);
			recipe.Register();
		}
	}
}