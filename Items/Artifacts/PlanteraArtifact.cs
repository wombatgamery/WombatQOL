using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items.Artifacts
{
    [LegacyName("lootrelicPlantera")]
    public class PlanteraArtifact : ModItem
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

			recipe = Recipe.Create(ItemID.GrenadeLauncher);
			recipe.AddIngredient(Type, 7);
			recipe.Register();

			recipe = Recipe.Create(ItemID.VenusMagnum);
			recipe.AddIngredient(Type, 7);
			recipe.Register();

			recipe = Recipe.Create(ItemID.NettleBurst);
			recipe.AddIngredient(Type, 7);
			recipe.Register();

			recipe = Recipe.Create(ItemID.LeafBlower);
			recipe.AddIngredient(Type, 7);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Seedler);
			recipe.AddIngredient(Type, 7);
			recipe.Register();

			recipe = Recipe.Create(ItemID.FlowerPow);
			recipe.AddIngredient(Type, 7);
			recipe.Register();

			recipe = Recipe.Create(ItemID.WaspGun);
			recipe.AddIngredient(Type, 7);
			recipe.Register();

			recipe = Recipe.Create(ItemID.PygmyStaff);
			recipe.AddIngredient(Type, 4);
			recipe.Register();

			recipe = Recipe.Create(ItemID.TheAxe);
			recipe.AddIngredient(Type, 50);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ThornHook);
			recipe.AddIngredient(Type, 10);
			recipe.Register();
		}
	}
}