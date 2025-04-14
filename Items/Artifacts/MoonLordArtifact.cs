using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items.Artifacts
{
    [LegacyName("lootrelicML")]
    public class MoonLordArtifact : ModItem
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

			recipe = Recipe.Create(ItemID.Meowmere);
			recipe.AddIngredient(Type, 9);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Terrarian);
			recipe.AddIngredient(Type, 9);
			recipe.Register();

			recipe = Recipe.Create(ItemID.StarWrath);
			recipe.AddIngredient(Type, 9);
			recipe.Register();

			recipe = Recipe.Create(ItemID.SDMG);
			recipe.AddIngredient(Type, 9);
			recipe.Register();

			recipe = Recipe.Create(ItemID.LastPrism);
			recipe.AddIngredient(Type, 9);
			recipe.Register();

			recipe = Recipe.Create(ItemID.LunarFlareBook);
			recipe.AddIngredient(Type, 9);
			recipe.Register();

			recipe = Recipe.Create(ItemID.MoonlordTurretStaff);
			recipe.AddIngredient(Type, 9);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Celeb2);
			recipe.AddIngredient(Type, 9);
			recipe.Register();

			recipe = Recipe.Create(ItemID.RainbowCrystalStaff);
			recipe.AddIngredient(Type, 9);
			recipe.Register();
		}
	}
}