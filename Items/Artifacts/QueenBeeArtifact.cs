using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items.Artifacts
{
    [LegacyName("lootrelicQB")]
    public class QueenBeeArtifact : ModItem
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

			recipe = Recipe.Create(ItemID.BeeKeeper);
			recipe.AddIngredient(Type, 3);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BeesKnees);
			recipe.AddIngredient(Type, 3);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BeeGun);
			recipe.AddIngredient(Type, 3);
			recipe.Register();

			recipe = Recipe.Create(ItemID.HoneyedGoggles);
			recipe.AddIngredient(Type, 20);
			recipe.Register();

			recipe = Recipe.Create(ItemID.HoneyComb);
			recipe.AddIngredient(Type, 3);
			recipe.Register();
		}
	}
}