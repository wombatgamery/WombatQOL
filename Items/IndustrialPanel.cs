using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using WombatQOL.Tiles;

namespace WombatQOL.Items
{
    [LegacyName("machinepanel")]
    public class IndustrialPanel : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Machine Panel");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.StoneBlock);
			Item.createTile = ModContent.TileType<Tiles.IndustrialPanel>();
		}

		public override void AddRecipes()
		{
			Recipe recipe;

			recipe = Recipe.Create(Type, 10);
			recipe.AddIngredient(ItemID.IronBar);
            recipe.AddIngredient(ItemID.Wire, 2);
            recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();

            recipe = Recipe.Create(Type, 10);
            recipe.AddIngredient(ItemID.LeadBar);
            recipe.AddIngredient(ItemID.Wire, 2);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();
        }
	}
}