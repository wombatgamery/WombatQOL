using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items
{
    [LegacyName("machinewall")]
    public class IndustrialWall : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Machine Wall");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.StoneWall);
			Item.width = 12;
			Item.height = 12;
            Item.createWall = ModContent.WallType<Walls.IndustrialWall>();
		}

		public override void AddRecipes()
		{
			Recipe recipe;

			recipe = Recipe.Create(Type, 4);
			recipe.AddIngredient(ModContent.ItemType<IndustrialPanel>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

			recipe = Recipe.Create(ModContent.ItemType<IndustrialPanel>());
			recipe.AddIngredient(Type, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}