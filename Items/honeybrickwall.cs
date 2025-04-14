using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items
{
	public class honeybrickwall : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Honey Brick Wall");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.StoneWall);
			Item.width = 13 * 2;
			Item.height = 13 * 2;
            Item.createWall = ModContent.WallType<Walls.honeybrickwall>();
		}

		public override void AddRecipes()
		{
			Recipe recipe;

			recipe = Recipe.Create(Type, 4);
			recipe.AddIngredient(ModContent.ItemType<honeybrick>());
			recipe.Register();

			recipe = Recipe.Create(ModContent.ItemType<honeybrick>());
			recipe.AddIngredient(Type, 4);
			recipe.Register();
		}
	}
}