using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items
{
    [LegacyName("ritualcandle")]
    public class CeremonialCandle : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Book);
			Item.width = 16;
			Item.height = 16;
			Item.createTile = ModContent.TileType<Tiles.CeremonialCandle>();
		}

		public override void AddRecipes()
		{
            Recipe recipe;

            recipe = Recipe.Create(Type, 3);
            recipe.AddIngredient(ItemID.BeeWax);
            recipe.AddIngredient(ItemID.Gel);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
	}
}