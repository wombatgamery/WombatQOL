using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using WombatQOL.Tiles;

namespace WombatQOL.Items
{
    [LegacyName("copperpipe")]
    public class IndustrialPipe : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.StoneBlock);
            Item.createTile = ModContent.TileType<Tiles.IndustrialPipe>();
		}

		public override void AddRecipes()
		{
            Recipe recipe = Recipe.Create(Type, 5);
            recipe.AddIngredient(ItemID.SilverBar);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();

            recipe = Recipe.Create(Type, 5);
            recipe.AddIngredient(ItemID.TungstenBar);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();
        }
	}
}