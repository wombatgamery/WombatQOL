using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items
{
    [LegacyName("machinebeam")]
    public class IndustrialSupport : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.WoodenBeam);
			Item.maxStack = 999;
			Item.createTile = ModContent.TileType<Tiles.IndustrialSupport>();
		}

		public override void AddRecipes()
        {
			Recipe recipe;

			recipe = Recipe.Create(Type, 2);
			recipe.AddIngredient(ModContent.ItemType<IndustrialPanel>());
			recipe.AddTile(TileID.Sawmill);
			recipe.Register();
		}
	}
}