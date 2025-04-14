using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items
{
	public class concretewall : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Concrete Wall");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.StoneWall);
			Item.width = 12;
			Item.height = 12;
            Item.createWall = ModContent.WallType<Walls.concretewall>();
		}

		public override void AddRecipes()
		{
			Recipe recipe;

			recipe = Recipe.Create(Type, 4);
			recipe.AddIngredient(ModContent.ItemType<concrete>());
			recipe.Register();

			recipe = Recipe.Create(ModContent.ItemType<concrete>());
			recipe.AddIngredient(Type, 4);
			recipe.Register();
		}
	}
}