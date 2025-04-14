using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items.Artifacts
{
    [LegacyName("lootrelicWOF")]
    public class WallOfFleshArtifact : ModItem
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

			recipe = Recipe.Create(ItemID.BreakerBlade);
			recipe.AddIngredient(Type, 4);
			recipe.Register();
			recipe = Recipe.Create(ItemID.ClockworkAssaultRifle);
			recipe.AddIngredient(Type, 4);
			recipe.Register();
			recipe = Recipe.Create(ItemID.LaserRifle);
			recipe.AddIngredient(Type, 4);
			recipe.Register();
			recipe = Recipe.Create(ItemID.FireWhip);
			recipe.AddIngredient(Type, 4);
			recipe.Register();

			recipe = Recipe.Create(ItemID.WarriorEmblem);
			recipe.AddIngredient(Type, 4);
			recipe.Register();
			recipe = Recipe.Create(ItemID.RangerEmblem);
			recipe.AddIngredient(Type, 4);
			recipe.Register();
			recipe = Recipe.Create(ItemID.SorcererEmblem);
			recipe.AddIngredient(Type, 4);
			recipe.Register();
			recipe = Recipe.Create(ItemID.SummonerEmblem);
			recipe.AddIngredient(Type, 4);
			recipe.Register();
		}
	}
}