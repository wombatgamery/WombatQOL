using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WombatQOL.Tiles.Furniture;

namespace WombatQOL.Items.Furniture
{
	public class IndustrialDoor : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.WoodenDoor);
			Item.createTile = ModContent.TileType <IndustrialDoorClosed>();
		}

		public override void AddRecipes()
		{
			Recipe recipe;

			recipe = Recipe.Create(Type);
			recipe.AddIngredient(ModContent.ItemType<IndustrialPanel>(), 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}