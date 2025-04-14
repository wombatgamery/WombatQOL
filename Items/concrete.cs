using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using WombatQOL.Tiles;

namespace WombatQOL.Items
{
	public class concrete : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Concrete Slab");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.StoneBlock);
			Item.width = 8;
			Item.height = 8;
            Item.createTile = ModContent.TileType<Tiles.concrete>();
		}

		public override void AddRecipes()
		{
            Recipe recipe = Recipe.Create(Type, 6);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddIngredient(ItemID.ClayBlock);
            recipe.AddIngredient(ItemID.SandBlock);
            recipe.AddTile(TileID.Blendomatic);
            recipe.Register();
        }
	}
}