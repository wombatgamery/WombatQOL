using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items.Artifacts
{
	[LegacyName("lootrelicDF")]
	public class DukeFishronArtifact : ModItem
	{
		public override void SetDefaults() 
		{
            Item.width = 18;
            Item.height = 20;
            Item.maxStack = 99;
            Item.value = 0;
            Item.rare = -12;
        }

		public override void AddRecipes()
		{
			Recipe recipe;

			recipe = Recipe.Create(ItemID.Flairon);
			recipe.AddIngredient(Type, 5);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Tsunami);
			recipe.AddIngredient(Type, 5);
			recipe.Register();

			recipe = Recipe.Create(ItemID.RazorbladeTyphoon);
			recipe.AddIngredient(Type, 5);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BubbleGun);
			recipe.AddIngredient(Type, 5);
			recipe.Register();

			recipe = Recipe.Create(ItemID.TempestStaff);
			recipe.AddIngredient(Type, 5);
			recipe.Register();

			recipe = Recipe.Create(ItemID.FishronWings);
			recipe.AddIngredient(Type, 10);
			recipe.Register();
		}
	}
}