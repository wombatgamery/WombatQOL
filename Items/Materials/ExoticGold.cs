using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Items.Materials
{
	public class ExoticGold : ModItem
	{
		public override void SetDefaults() 
		{
			//Item.CloneDefaults(ItemID.GoldBar);
			Item.width = 16 * 2;
			Item.height = 11 * 2;
			Item.maxStack = 99;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Orange;

			ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.GoldDust;
			//Item.createTile = -1;
		}

        public override void AddRecipes()
        {
			Recipe recipe;
			
			recipe = Recipe.Create(ItemID.GoldenBullet, 50);
            recipe.AddIngredient(ItemID.EmptyBullet, 50);
            recipe.AddIngredient(Type);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

			recipe = Recipe.Create(ItemID.FlaskofGold);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(Type, 5);
			recipe.AddTile(TileID.ImbuingStation);
			recipe.Register();

			recipe = Recipe.Create(ItemID.GoldenChair);
			recipe.AddIngredient(Type, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenTable);
			recipe.AddIngredient(Type, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenDoor);
			recipe.AddIngredient(Type, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenBookcase);
			recipe.AddIngredient(Type, 20);
			recipe.AddIngredient(ItemID.Book, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.GoldenLamp);
			recipe.AddIngredient(Type, 3);
			recipe.AddIngredient(ItemID.Torch);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenChandelier);
			recipe.AddIngredient(Type, 4);
			recipe.AddIngredient(ItemID.Torch, 4);
			recipe.AddIngredient(ItemID.Chain);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenLantern);
			recipe.AddIngredient(Type, 6);
			recipe.AddIngredient(ItemID.Torch);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenCandelabra);
			recipe.AddIngredient(Type, 5);
			recipe.AddIngredient(ItemID.Torch, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenCandle);
			recipe.AddIngredient(Type, 4);
			recipe.AddIngredient(ItemID.Torch);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.GoldenBed);
			recipe.AddIngredient(Type, 15);
			recipe.AddIngredient(ItemID.Silk, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenClock);
			recipe.AddIngredient(Type, 10);
			recipe.AddIngredient(ItemID.IronBar, 3);
			recipe.AddIngredient(ItemID.Glass, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenPiano);
			recipe.AddIngredient(Type, 15);
			recipe.AddIngredient(ItemID.Bone, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenDresser);
			recipe.AddIngredient(Type, 16);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenSofa);
			recipe.AddIngredient(Type, 5);
			recipe.AddIngredient(ItemID.Silk, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenBathtub);
			recipe.AddIngredient(Type, 14);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenSink);
			recipe.AddIngredient(Type, 6);
			recipe.AddIngredient(ItemID.WaterBucket);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenChest);
			recipe.AddIngredient(Type, 8);
			recipe.AddIngredient(ItemID.IronBar, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenPlatform, 2);
			recipe.AddIngredient(Type);
			recipe.Register();
			recipe = Recipe.Create(ItemID.GoldenWorkbench);
			recipe.AddIngredient(Type, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}