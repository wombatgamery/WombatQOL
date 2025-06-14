using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace WombatQOL
{
	public class Worldgen : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Header("Terrain")]

		[DefaultValue(true)]
		public bool LeafBushes;

		[DefaultValue(true)]
        [BackgroundColor(100, 100, 150)]
        public bool DesertRocks;

        //[Label("Better Spider Caves")]
        //[DefaultValue(true)]
        //[Tooltip("Spider caves get a complete redesign to liven up the world.\nThis config will have no effect with Remnants Mod enabled, as it already includes this feature.")]
        //public bool SpiderNests;
        //[Label("Leaf Bushes")]
        //[Tooltip("Leaf bushes will generate on any grass type, adding more life and depth to the environment.\nThis config will have no effect with Remnants Mod enabled, as it already includes this feature.")]

        //[Label("Water Clay")]
        //[Tooltip("Clay will generate under bodies of water instead of in random veins, adding more strategy to mining as well as some aesthetic.\nPREVENTS CATTAILS, AND THEREFORE DRAGONFLIES, FROM SPAWNING.")]
        [DefaultValue(false)]
        [BackgroundColor(150, 100, 125)]
        public bool WaterClay;

        [DefaultValue(true)]
        [BackgroundColor(100, 100, 150)]
        public bool LushJungle;

        [Header("Structure")]

		[DefaultValue(true)]
		public bool HellCages;

		////[Label("Sand Caves")]
		//[DefaultValue(true)]
		////[Tooltip("Underground sand patches are remodelled into sand cave minibiomes, adding greater variety to the world.\nThis config will have no effect with Remnants Mod enabled, as it already includes this feature.")]
		//public bool SandCaves;

		//[Header("Structure Generation")]

		//[Label("Dungeon Chains")]
		//[Tooltip("Hanging chains will generate in high places in The Dungeon, making it more interesting to traverse.\nThis config will have no effect with Remnants Mod enabled, as it already includes this feature.")]
		[DefaultValue(true)]
        [BackgroundColor(100, 100, 150)]
        public bool DungeonChains;

		//[Label("Dungeon Stairs")]
		//[Tooltip("Sloped platforms will generate where appropriate in The Dungeon, giving it a more coherent design.\nThis config will have no effect with Remnants Mod enabled, as it already includes this feature.")]
		[DefaultValue(true)]
        [BackgroundColor(100, 100, 150)]
        public bool DungeonStairs;

		//[Label("Temple Stairs")]
		//[Tooltip("Sloped platforms will generate where appropriate in The Lihzahrd Temple, giving it a more coherent design.\nThis config will have no effect with Remnants Mod enabled, as it already includes this feature.")]
		[DefaultValue(true)]
        [BackgroundColor(100, 100, 150)]
        public bool TempleStairs;

        [DefaultValue(true)]
        public bool ChestItemShuffle;

        [DefaultValue(true)]
        public bool RandomOpenDoors;

        [DefaultValue(true)]
        public bool SpawnCampsite;
	}
	public class Gameplay : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Header("Content")]

		[DefaultValue(true)]
        [BackgroundColor(90, 160, 140)]
        [ReloadRequired]
        public bool BossArtifacts;

		[DefaultValue(true)]
        [BackgroundColor(90, 160, 140)]
        [ReloadRequired]
        public bool ExoticGold;

		[Header("Functional")]

		[DefaultValue(true)]
        [ReloadRequired]
        public bool SafeCritters;

		[DefaultValue(true)]
        [ReloadRequired]
        public bool SafeBoundNPCs;

		[DefaultValue(true)]
        [ReloadRequired]
        public bool TilePickup;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool RareMeteorite;

        [Header("Crafting")]

		[DefaultValue(true)]
        [ReloadRequired]
        public bool DyeMixing;

		[DefaultValue(true)]
        [ReloadRequired]
        public bool EasyWings;

		[DefaultValue(true)]
        [ReloadRequired]
        public bool SpectrePaintUpgrade;

		[DefaultValue(true)]
        [ReloadRequired]
        public bool HoneyDispenser;

		[Header("Drops")]

		[DefaultValue(true)]
        [ReloadRequired]
        [BackgroundColor(90, 160, 140)]
        public bool GlowingMushrooms;

		[DefaultValue(true)]
        [ReloadRequired]
        public bool SoulsOfFlight;

		[DefaultValue(true)]
        [ReloadRequired]
        public bool KingSlimeKatana;
    }

    public class Visuals : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("Effects")]

        [DefaultValue(true)]
        [BackgroundColor(100, 100, 150)]
        public bool BulletFlashes;

        [DefaultValue(true)]
        public bool LaserFlashes;

        [DefaultValue(true)]
        [BackgroundColor(100, 100, 150)]
        public bool BulletCasings;

        [DefaultValue(true)]
        public bool JungleFireflies;

        [DefaultValue(true)]
        public bool HallowFireflies;

        [DefaultValue(true)]
        public bool VileWater;

        //[Label("Explosion Screenshake")]
        [DefaultValue(true)]
        //[Tooltip("Explosions will cause screenshake, the intensity generally depends on the explosive power. \nDOESN'T APPLY TO ANY MODDED CONTENT.")]
        [BackgroundColor(150, 150, 125)]
        public bool Screenshake;

        //[Label("Snow and Dirt Merge")]
        [DefaultValue(true)]
        //[Tooltip("Enables the unused dirt merge textures for snow blocks.")]
        [ReloadRequired]
        public bool SnowDirtMerge;

        [Header("Lighting")]

        //[Label("Hellstone Glow")]
        [DefaultValue(true)]
        //[Tooltip("Hellstone, its bricks and natural lava walls will have a red glow.\nThis config will have no effect with Remnants Mod enabled, as it already includes this feature.")]
        public bool GlowingHellstone;

        //[Label("Ambient Light In Lava Layer")]
        [DefaultValue(true)]
        //[Tooltip("The lava background near the underworld (assuming backgrounds are on) will have a red ambient light. \nAFFECTS SUBWORLDS, WHICH MAY BE UNWANTED.")]
        [BackgroundColor(150, 150, 125)]
        public bool GlowingLavaBG;

        [DefaultValue(true)]
        public bool GraniteEnemyGlow;
    }
}