using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using WombatQOL.Tiles;

namespace WombatQOL.Items
{
	public class honeybrick : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Honey Brick");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.StoneBlock);
			Item.width = 7 * 2;
			Item.height = 11 * 2;
            Item.createTile = ModContent.TileType<Tiles.honeybrick>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(Type, 2);
			recipe.AddIngredient(ItemID.HoneyBlock);
			recipe.AddIngredient(ItemID.CrispyHoneyBlock);
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}