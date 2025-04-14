using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WombatQOL.Tiles;

namespace WombatQOL.Items
{
	[LegacyName("machineplatform")]
	public class IndustrialPlatform : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.WoodPlatform);
			Item.width = 12;
			Item.height = 12;
			Item.createTile = ModContent.TileType<Tiles.IndustrialPlatform>();
		}

		public override void AddRecipes()
		{
			Recipe recipe;

			recipe = Recipe.Create(Type, 2);
			recipe.AddIngredient(ModContent.ItemType<IndustrialPanel>());
			recipe.Register();

			recipe = Recipe.Create(ModContent.ItemType<IndustrialPanel>());
			recipe.AddIngredient(Type, 2);
			recipe.Register();
		}
	}
}