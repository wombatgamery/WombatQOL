using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items.Artifacts
{
    [LegacyName("lootrelicSkeletron")]
    public class SkeletronArtifact : ModItem
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

			recipe = Recipe.Create(ItemID.SkeletronHand);
			recipe.AddIngredient(Type, 8);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BookofSkulls);
			recipe.AddIngredient(Type, 9);
			recipe.Register();
		}
	}
}