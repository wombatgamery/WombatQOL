using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items.Artifacts
{
    [LegacyName("lootrelicGolem")]
    public class GolemArtifact : ModItem
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

			recipe = Recipe.Create(ItemID.Picksaw);
			recipe.AddIngredient(Type, 4);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Stynger);
			recipe.AddIngredient(Type, 7);
			recipe.Register();

			recipe = Recipe.Create(ItemID.PossessedHatchet);
			recipe.AddIngredient(Type, 7);
			recipe.Register();

			recipe = Recipe.Create(ItemID.SunStone);
			recipe.AddIngredient(Type, 7);
			recipe.Register();

			recipe = Recipe.Create(ItemID.EyeoftheGolem);
			recipe.AddIngredient(Type, 7);
			recipe.Register();

			recipe = Recipe.Create(ItemID.HeatRay);
			recipe.AddIngredient(Type, 7);
			recipe.Register();

			recipe = Recipe.Create(ItemID.StaffofEarth);
			recipe.AddIngredient(Type, 7);
			recipe.Register();

			recipe = Recipe.Create(ItemID.GolemFist);
			recipe.AddIngredient(Type, 7);
			recipe.Register();

		}
	}
}