using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items.Artifacts
{
    [LegacyName("lootrelicKS")]
    public class KingSlimeArtifact : ModItem
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

			recipe = Recipe.Create(ItemID.SlimeHook);
			recipe.AddIngredient(Type, 3);
			recipe.Register();

			recipe = Recipe.Create(ItemID.SlimySaddle);
			recipe.AddIngredient(Type, 4);
			recipe.Register();

			recipe = Recipe.Create(ItemID.NinjaHood);
			recipe.AddIngredient(Type, 3);
			recipe.Register();
			recipe = Recipe.Create(ItemID.NinjaShirt);
			recipe.AddIngredient(Type, 3);
			recipe.Register();
			recipe = Recipe.Create(ItemID.NinjaPants);
			recipe.AddIngredient(Type, 3);
			recipe.Register();
		}
	}
}