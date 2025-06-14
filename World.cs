using Terraria;
using Terraria.ID;
using Terraria.WorldBuilding;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.IO;
using Terraria.DataStructures;
using WombatQOL.Walls;
using WombatQOL.Tiles;

namespace WombatQOL
{
	public class QOLWorld : ModSystem
	{
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            bool calamity = ModLoader.TryGetMod("CalamityMod", out Mod cal);
            bool fables = ModLoader.TryGetMod("CalamityFables", out Mod cal2);
            bool remnants = ModLoader.TryGetMod("Remnants", out Mod rem);

            if (ModContent.GetInstance<Worldgen>().LeafBushes)
            {
                InsertPass(tasks, new Bushes("Bushes", 1), FindIndex(tasks, calamity ? "Planetoids" : "Final Cleanup"));
            }
            if (ModContent.GetInstance<Worldgen>().HellCages)
            {
                InsertPass(tasks, new HellCages("Underworld Cages", 1), FindIndex(tasks, "Smooth World") + 1);
            }
            if (ModContent.GetInstance<Worldgen>().SpawnCampsite)
            {
                InsertPass(tasks, new SpawnCampsite("Spawn Campsite", 1), FindIndex(tasks, "Spawn Point") + (remnants ? 2 : 1));
            }
            if (!remnants)
            {
                if (ModContent.GetInstance<Worldgen>().DesertRocks && !fables)
                {
                    InsertPass(tasks, new DesertRocks("Desert Rocks", 1), FindIndex(tasks, "Full Desert") + 1);
                }
                if (ModContent.GetInstance<Worldgen>().LushJungle)
                {
                    InsertPass(tasks, new LushJungle("Lush Jungle", 1), FindIndex(tasks, "Muds Walls In Jungle") + 1);
                }

                //if (ModContent.GetInstance<P1>().SandCaves)
                //{
                //    InsertPass(tasks, FindIndex(tasks, "Sand Patches") + 1, new SandCaves1("Sand Caves 1", 1));
                //    InsertPass(tasks, FindIndex(tasks, "Jungle") + 1, new SandCaves2("Sand Caves 2", 1));
                //}
                if (ModContent.GetInstance<Worldgen>().WaterClay)
                {
                    RemovePass(tasks, FindIndex(tasks, "Clay"));
                    InsertPass(tasks, new Clay("Clay", 1), FindIndex(tasks, "Planting Trees"));
                }

                if (ModContent.GetInstance<Worldgen>().DungeonChains)
                {
                    InsertPass(tasks, new DungeonChains("Dungeon Chains", 1), FindIndex(tasks, "Dungeon") + 1);
                }
                if (ModContent.GetInstance<Worldgen>().DungeonStairs)
                {
                    InsertPass(tasks, new DungeonStairs("Dungeon Stairs", 1), FindIndex(tasks, "Dungeon") + 1);
                }
                if (ModContent.GetInstance<Worldgen>().TempleStairs)
                {
                    InsertPass(tasks, new TempleStairs("Temple Stairs", 1), FindIndex(tasks, "Jungle Temple") + 1);
                }
            }
            InsertPass(tasks, new DirtWallCleanup("Dirt Wall Cleanup", 1), FindIndex(tasks, "Dirt Wall Backgrounds") + 1);
        }
        public static void InsertPass(List<GenPass> tasks, GenPass item, int index, bool replace = false)
        {
            if (replace)
            {
                RemovePass(tasks, index);
            }
            if (index != -1)
            {
                tasks.Insert(index, item);
            }

            item.Name = "[W] " + item.Name;
        }

        public static void RemovePass(List<GenPass> tasks, int index)
        {
            if (index != -1)
            {
                tasks[index].Disable();
            }
        }

        public int FindIndex(List<GenPass> tasks, string value)
        {
            return tasks.FindIndex(genpass => genpass.Name.Equals(value));
        }

        public override void PostWorldGen()
        {
            if (ModContent.GetInstance<Worldgen>().RandomOpenDoors)
            {
                for (int j = 40; j < Main.maxTilesY - 40; j++)
                {
                    for (int i = 40; i < Main.maxTilesX - 40; i++)
                    {
                        Tile tile = Main.tile[i, j];
                        if (tile.HasTile)
                        {
                            if (tile.TileType == TileID.ClosedDoor && WGTools.Tile(i, j - 1).TileType != TileID.ClosedDoor && WorldGen.genRand.NextBool(3) && tile.TileFrameY != 11 * 18 * 3)
                            {
                                int direction = WorldGen.genRand.NextBool(2) ? -1 : 1;
                                if (WGTools.Tile(i + direction, j + 2).HasTile && Main.tileCut[WGTools.Tile(i + direction, j + 2).TileType])
                                {
                                    WorldGen.KillTile(i + direction, j + 2);
                                }
                                WorldGen.OpenDoor(i, j, direction);
                            }
                        }
                    }
                }
            }
            if (ModContent.GetInstance<Worldgen>().ChestItemShuffle)
            {
                for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
                {
                    if (Main.chest[chestIndex] != null)
                    {
                        Chest chest = Main.chest[chestIndex];
                        List<Item> items = new List<Item>();

                        for (int itemIndex = 0; itemIndex < Chest.maxItems; itemIndex++)
                        {
                            Item item = chest.item[itemIndex];
                            if (!item.IsAir)
                            {
                                items.Add(item.Clone());
                                item.TurnToAir();
                            }
                        }

                        while (items.Count > 0)
                        {
                            int itemIndex = WorldGen.genRand.Next(Chest.maxItems);
                            if (chest.item[itemIndex].IsAir)
                            {
                                chest.item[itemIndex] = items[0];
                                items.RemoveAt(0);
                            }
                        }
                    }
                }
            }

            if (ModLoader.TryGetMod("Remnants", out Mod rem))
            {
                for (int j = (int)Main.worldSurface; j < Main.maxTilesY - 40; j++)
                {
                    for (int i = 40; i < Main.maxTilesX - 40; i++)
                    {
                        Tile tile = Main.tile[i, j];
                        if (tile.HasTile && tile.TileType == ModContent.TileType<electriclight>() && WorldGen.genRand.NextBool(2))
                        {
                            tile.TileType = (ushort)ModContent.TileType<electriclightfaulty>();
                        }
                    }
                }
            }
        }
    }

    #region terrain
    public class DesertRocks : GenPass
    {
        public DesertRocks(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Adding desert rocks";

            #region desertrocks
            float transit1 = (int)Main.worldSurface - 50;
            float transit2 = (int)Main.worldSurface;

            for (int y = 40; y < Main.maxTilesY - 200; y++)
            {
                progress.Set((y - 40) / ((Main.maxTilesY - 200) - 40));

                for (int x = 400; x < Main.maxTilesX - 400; x++)
                {
                    if (WGTools.Tile(x, y).TileType == TileID.Sand)
                    {
                        WGTools.Tile(x, y).TileType = (ushort)ModContent.TileType<devtile>();
                    }
                }
            }

            Rectangle desert = GenVars.UndergroundDesertLocation;

            int structureCount = (int)(desert.Width * 0.8f) / 16;

            while (structureCount > 0)
            {
                int x = WorldGen.genRand.Next((int)(desert.X + desert.Width * 0.1f), (int)(desert.X + desert.Width * 0.9f));
                int y = (int)(Main.worldSurface * 0.4f);
                float offset = 0;
                int sizeMax = WorldGen.genRand.Next(1, 5) * 2 - 1;
                int height = WorldGen.genRand.Next(16, 24) + sizeMax;

                bool valid = false;

                while (!valid && y < Main.worldSurface)
                {
                    valid = true;
                    for (int i = x - (sizeMax + 1) / 2 - 1; i < x + (sizeMax + 1) / 2 + 1; i++)
                    {
                        if (!Framing.GetTileSafely(i, y + 1).HasTile)
                        {
                            valid = false;
                        }
                    }
                    y++;
                }

                valid = true;
                if (y < (int)Main.worldSurface * 0.4f)
                {
                    valid = false;
                }
                else if (WGTools.Tile(x, y + 1).TileType != ModContent.TileType<devtile>() && WGTools.Tile(x, y + 1).TileType != TileID.HardenedSand && WGTools.Tile(x, y + 1).TileType != TileID.Sandstone)
                {
                    valid = false;
                }
                if (valid)
                {
                    WorldGen.TileRunner(x, y, sizeMax + 1 * 4, 1, TileID.HardenedSand);
                    int size = sizeMax;
                    while (size > 1 && height > 0)
                    {
                        WGTools.Circle(x + offset, y, size, wall: WallID.Sandstone, xMultiplier: 0.5f, yMultiplier: 1, replace: false);
                        if (WorldGen.genRand.NextBool(4))
                        {
                            size--;
                            offset += WorldGen.genRand.Next(-1, 2) * 0.5f;
                        }
                        height--;
                        y--;
                    }

                    structureCount--;
                }
            }

            structureCount = (int)(desert.Width * 0.6f) / 12;

            while (structureCount > 0)
            {
                int x = WorldGen.genRand.Next((int)(desert.X + desert.Width * 0.2f), (int)(desert.X + desert.Width * 0.8f));
                int y = (int)(Main.worldSurface * 0.4f);
                float offset = 0;
                int sizeMax = WorldGen.genRand.Next(1, 3) * 2 - 1;
                int height = WorldGen.genRand.Next(4, 8) + sizeMax;

                bool valid = false;
                while (!valid && y < Main.worldSurface)
                {
                    valid = true;
                    for (int i = x - (sizeMax + 1) / 2 - 1; i < x + (sizeMax + 1) / 2 + 1; i++)
                    {
                        if (!Framing.GetTileSafely(i, y + 1).HasTile)
                        {
                            valid = false;
                        }
                    }
                    y++;
                }

                valid = true;
                if (y <= (int)Main.worldSurface * 0.4f)
                {
                    valid = false;
                }
                else if (WGTools.Tile(x, y + 1).TileType != ModContent.TileType<devtile>() && WGTools.Tile(x, y + 1).TileType != TileID.HardenedSand && WGTools.Tile(x, y + 1).TileType != TileID.Sandstone)
                {
                    valid = false;
                }
                if (valid)
                {
                    WorldGen.TileRunner(x, y, sizeMax + 1 * 4, 1, TileID.HardenedSand);
                    int size = sizeMax;
                    while (size > 1 && height > 0)
                    {
                        WGTools.Circle(x + offset, y, size, type: TileID.Sandstone, xMultiplier: 0.5f, yMultiplier: 1);
                        if (WorldGen.genRand.NextBool(4))
                        {
                            size--;
                            offset += WorldGen.genRand.Next(-1, 2) * 0.5f;
                        }
                        height--;
                        y--;
                    }

                    structureCount--;
                }
            }

            bool rem = ModLoader.TryGetMod("Remnants", out Mod mod);

            for (int y = 40; y < Main.maxTilesY - 200; y++)
            {
                for (int x = 400; x < Main.maxTilesX - 400; x++)
                {
                    if (Framing.GetTileSafely(x, y).TileType == ModContent.TileType<devtile>())
                    {
                        Framing.GetTileSafely(x, y).TileType = TileID.Sand;
                    }

                    if (!rem && WGTools.SurroundingTilesActive(x, y, true))
                    {
                        if (WGTools.Tile(x, y).WallType == 0)
                        {
                            if (Framing.GetTileSafely(x, y).TileType == TileID.Sand || Framing.GetTileSafely(x, y).TileType == TileID.HardenedSand)
                            {
                                WGTools.Tile(x, y).WallType = WallID.HardenedSand;
                            }
                            if (Framing.GetTileSafely(x, y).TileType == TileID.Ebonsand || Framing.GetTileSafely(x, y).TileType == TileID.CorruptHardenedSand)
                            {
                                WGTools.Tile(x, y).WallType = WallID.CorruptHardenedSand;
                            }
                            if (Framing.GetTileSafely(x, y).TileType == TileID.Crimsand || Framing.GetTileSafely(x, y).TileType == TileID.CrimsonHardenedSand)
                            {
                                WGTools.Tile(x, y).WallType = WallID.CrimsonHardenedSand;
                            }
                            if (Framing.GetTileSafely(x, y).TileType == TileID.Sandstone)
                            {
                                WGTools.Tile(x, y).WallType = WallID.Sandstone;
                            }
                        }
                    }
                    if (Framing.GetTileSafely(x, y).TileType == TileID.HardenedSand || Framing.GetTileSafely(x, y).TileType == TileID.CorruptHardenedSand || Framing.GetTileSafely(x, y).TileType == TileID.CrimsonHardenedSand)
                    {
                        if (Framing.GetTileSafely(x, y).WallType == WallID.DirtUnsafe)
                        {
                            WorldGen.KillWall(x, y);
                        }
                    }
                }
            }
            #endregion
        }
    }

    public class Bushes : GenPass
    {
        public Bushes(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Growing bushes";

            for (int y = 40; y < Main.worldSurface; y++)
            {
                for (int x = 40; x < Main.maxTilesX - 40; x++)
                {
                    if (Framing.GetTileSafely(x, y).HasTile && !WGTools.SurroundingTilesActive(x, y, true) && WorldGen.genRand.NextBool(10))
                    {
                        Tile tile = Framing.GetTileSafely(x, y);
                        if (tile.TileType == TileID.Grass || tile.TileType == TileID.JungleGrass || tile.TileType == TileID.CorruptGrass || tile.TileType == TileID.CrimsonGrass)
                        {
                            int count = 3;
                            while (count > 0)
                            {
                                int i = WorldGen.genRand.Next(x - 3, x + 4);
                                int j = WorldGen.genRand.Next(y - 3, y + 4);
                                if (Framing.GetTileSafely(i, j).HasTile && !WGTools.SurroundingTilesActive(i, j, true))
                                {
                                    tile = Framing.GetTileSafely(i, j);
                                    if (tile.TileType == TileID.Grass || tile.TileType == TileID.JungleGrass || tile.TileType == TileID.CorruptGrass || tile.TileType == TileID.CrimsonGrass)
                                    {
                                        int grass = WallID.GrassUnsafe;
                                        if (tile.TileType == TileID.JungleGrass)
                                        {
                                            grass = WallID.JungleUnsafe;
                                        }
                                        else if (tile.TileType == TileID.CorruptGrass)
                                        {
                                            grass = WallID.CorruptGrassUnsafe;
                                        }
                                        else if (tile.TileType == TileID.CrimsonGrass)
                                        {
                                            grass = WallID.CrimsonGrassUnsafe;
                                        }

                                        WGTools.Circle(i, j, WorldGen.genRand.NextFloat(0.5f, 3.5f), wall: grass, add: true, replace: false);

                                        count--;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public class LushJungle : GenPass
    {
        public LushJungle(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            for (int y = 40; y < Main.worldSurface + 10; y++)
            {
                //progress.Set(y / (int)Main.worldSurface / 2 + 0.5f);

                for (int x = 40; x < Main.maxTilesX - 40; x++)
                {
                    if (!WGTools.SurroundingTilesActive(x, y, true))
                    {
                        if (WGTools.Tile(x, y).HasTile && WGTools.Tile(x, y).TileType == TileID.Mud)
                        {
                            WGTools.Tile(x, y).TileType = TileID.JungleGrass;
                        }
                        if (WGTools.Tile(x, y).WallType == WallID.MudUnsafe)
                        {
                            WGTools.Tile(x, y).WallType = WallID.JungleUnsafe;
                        }
                    }
                }
            }
        }
    }

    public class SandCaves1 : GenPass
    {
        public SandCaves1(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Adding sand caves";

            for (int x = 40; x < Main.maxTilesX - 40; x++)
            {
                for (int y = (int)Main.worldSurface - WorldGen.genRand.Next(29, 32); y < Main.maxTilesY - 200; y++)
                {
                    if (Framing.GetTileSafely(x, y).TileType == TileID.Sand)
                    {
                        Framing.GetTileSafely(x, y).WallType = WallID.HardenedSand;
                    }
                }
            }
        }
    }

    public class SandCaves2 : GenPass
    {
        public SandCaves2(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Finalizing sand caves";

            for (int x = 40; x < Main.maxTilesX - 40; x++)
            {
                for (int y = (int)Main.worldSurface - WorldGen.genRand.Next(29, 32); y < Main.maxTilesY - 200; y++)
                {
                    if (Framing.GetTileSafely(x, y).TileType == TileID.Sand)
                    {
                        Framing.GetTileSafely(x, y).TileType = TileID.HardenedSand;
                    }

                    if (Framing.GetTileSafely(x, y).WallType == WallID.HardenedSand)
                    {
                        if (Framing.GetTileSafely(x, y).TileType == TileID.SnowBlock || Framing.GetTileSafely(x, y).TileType == TileID.IceBlock || Framing.GetTileSafely(x, y).TileType == TileID.Mud)
                        {
                            Framing.GetTileSafely(x, y).WallType = 0;
                        }
                    }
                }
            }
        }
    }

    public class Clay : GenPass
    {
        public Clay(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Adding clay";

            for (int y = 20; y < Main.maxTilesY - 200; y++)
            {
                for (int x = 20; x < Main.maxTilesX - 20; x++)
                {
                    if (Framing.GetTileSafely(x, y).HasTile && !Framing.GetTileSafely(x, y - 1).HasTile && Framing.GetTileSafely(x, y - 1).LiquidType == 0 && Framing.GetTileSafely(x, y - 1).LiquidAmount > 0)
                    {
                        int claydepth = 1;

                        while (Framing.GetTileSafely(x, y - claydepth).LiquidType == 0 && Framing.GetTileSafely(x, y - claydepth).LiquidAmount > 0)
                        {
                            claydepth++;
                        }
                        if (Framing.GetTileSafely(x, y).Slope != 0 || Framing.GetTileSafely(x, y).IsHalfBlock) claydepth++;

                        for (int y2 = y; y2 < y + claydepth; y2++)
                        {
                            Tile tile = Framing.GetTileSafely(x, y2);
                            if (tile.HasTile)
                            {
                                if (tile.TileType == TileID.Dirt || tile.TileType == TileID.ClayBlock || tile.TileType == TileID.Grass || tile.TileType == TileID.CorruptGrass || tile.TileType == TileID.CrimsonGrass)
                                {
                                    //WorldGen.TileRunner(x, y2, 2, 1, TileID.ClayBlock, ignoreTileType: TileID.Stone);
                                    tile.TileType = TileID.ClayBlock;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion

    #region structures
    public class HellCages : GenPass
    {
        public HellCages(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Hanging cages";

            int structureCount = (int)(Main.maxTilesX * 0.8f) / 100;
            while (structureCount > 0)
            {
                #region spawnconditions
                int structureX = WorldGen.genRand.Next((int)(Main.maxTilesX * 0.1f), (int)(Main.maxTilesX * 0.9f));
                int structureY = WorldGen.genRand.Next(Main.maxTilesY - 170, Main.maxTilesY - 140);

                bool valid = true;

                for (int j = -1; j <= 13; j++)
                {
                    for (int i = -3; i <= 3; i++)
                    {
                        if (WGTools.Tile(structureX + i, structureY + j).HasTile)
                        {
                            valid = false;
                            break;
                        }
                        else if (i >= -2 && i <= 2 && j <= 6 && WGTools.Tile(structureX + i, structureY + j).WallType != 0)
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (!valid)
                    {
                        break;
                    }
                }
                #endregion

                #region structure
                if (valid)
                {
                    WGTools.Rectangle(structureX - 2, structureY, structureX + 2, structureY + 6, TileID.IronBrick);
                    WGTools.Rectangle(structureX - 2, structureY + 1, structureX + 2, structureY + 5, TileID.Spikes, WallID.WroughtIronFence, liquid: 0);
                    WGTools.Rectangle(structureX - 1, structureY + 1, structureX + 1, structureY + 5, -1);
                    WGTools.Rectangle(structureX, structureY, structureX, structureY + 5, wall: WallID.IronBrick);
                    //WGTools.Tile(structureX, structureY).WallType = WallID.IronBrick;

                    WorldGen.Place3x2(structureX, structureY + 5, TileID.LargePiles, Main.rand.Next(7));

                    int y = structureY - 1;
                    while (!WGTools.Tile(structureX, y).HasTile)
                    {
                        WorldGen.PlaceTile(structureX, y, TileID.Chain);
                        y--;
                    }
                    WGTools.Rectangle(structureX - 1, y, structureX + 1, y, TileID.IronBrick);
                    WGTools.Tile(structureX, y).WallType = WallID.IronBrick;

                    structureCount--;
                }
                #endregion
            }
        }
    }


    public class DungeonChains : GenPass
    {
        public DungeonChains(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Hanging dungeon chains";

            int objects = Main.maxTilesX / 105;
            while (objects > 0)
            {
                int x = WorldGen.genRand.Next(GenVars.dMinX, GenVars.dMaxX);
                int y = WorldGen.genRand.Next((int)Main.worldSurface, GenVars.dMaxY);

                for (; !WGTools.Tile(x, y - 1).HasTile || WGTools.Tile(x, y).HasTile; y += WGTools.Tile(x, y).HasTile ? 1 : -1)
                {

                }

                if (WGTools.FullTile(x, y - 1) && Main.wallDungeon[Main.tile[x, y].WallType] && WGTools.Tile(x, y - 1).TileType != TileID.CrackedBlueDungeonBrick && WGTools.Tile(x, y - 1).TileType != TileID.CrackedGreenDungeonBrick && WGTools.Tile(x, y - 1).TileType != TileID.CrackedPinkDungeonBrick && WGTools.Tile(x, y - 1).TileType != TileID.BoneBlock)
                {
                    int length = 1;
                    for (int j = y + 1; !WGTools.Tile(x, j + 3).HasTile; j++)
                    {
                        length++;
                    }

                    if (length > 10)
                    {
                        length = WorldGen.genRand.Next(10, length + 1);

                        bool valid = true;

                        for (int j = y + 1; j <= y + length + 3; j++)
                            {
                                for (int i = x - 1; i <= x + 1; i++)
                                {
                                    if (i == x && WGTools.Tile(i, j).HasTile || WGTools.FullTile(i, j) || WGTools.Tile(i, j).HasTile && WGTools.Tile(i, j).TileType == TileID.Chain)
                                    {
                                        valid = false;
                                        break;
                                    }
                                }
                                if (!valid) { break; }
                            }

                        if (valid)
                        {
                            WGTools.Tile(x, y - 1).Slope = SlopeType.Solid;
                            for (int j = y; j < y + length; j++)
                            {
                                WorldGen.PlaceTile(x, j, TileID.Chain);
                            }
                            WorldGen.PlaceTile(x, y + length, TileID.BoneBlock);
                            objects--;
                        }
                    }
                }
            }
        }
    }

    public class DungeonStairs : GenPass
    {
        public DungeonStairs(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Placing dungeon stairs";

            for (int y = 40; y < Main.maxTilesY - 200; y++)
            {
                for (int x = 40; x < Main.maxTilesX - 40; x++)
                {
                    if (IsBrick(x, y + 1) && !Framing.GetTileSafely(x, y).HasTile && Main.wallDungeon[Framing.GetTileSafely(x, y).WallType])
                    {
                        bool left = false;
                        bool right = false;
                        if (IsBrick(x - 1, y) && !WGTools.FullTile(x - 1, y - 1))
                        {
                            left = true;
                        }
                        if (IsBrick(x + 1, y) && !WGTools.FullTile(x + 1, y - 1))
                        {
                            right = true;
                        }

                        if (IsBrick(x - 1, y) && IsBrick(x + 1, y))
                        {
                            WorldGen.PlaceTile(x, y, Framing.GetTileSafely(x, y + 1).TileType);
                        }
                        else if (left && !right || right && !left)
                        {
                            WorldGen.PlaceTile(x, y, TileID.Platforms, style: Framing.GetTileSafely(x, y + 1).TileType == TileID.GreenDungeonBrick ? 8 : Framing.GetTileSafely(x, y + 1).TileType == TileID.PinkDungeonBrick ? 7 : 6);

                            if (left && !right)
                            {
                                Framing.GetTileSafely(x, y).Slope = SlopeType.SlopeDownLeft;
                                Framing.GetTileSafely(x, y).TileFrameX = 18 * 10;
                            }
                            else if (right && !left)
                            {
                                Framing.GetTileSafely(x, y).Slope = SlopeType.SlopeDownRight;
                                Framing.GetTileSafely(x, y).TileFrameX = 18 * 8;
                            }
                        }
                    }
                }
            }
        }

        private bool IsBrick(int x, int y)
        {
            return (Framing.GetTileSafely(x, y).TileType == TileID.BlueDungeonBrick || Framing.GetTileSafely(x, y).TileType == TileID.GreenDungeonBrick || Framing.GetTileSafely(x, y).TileType == TileID.PinkDungeonBrick) && Framing.GetTileSafely(x, y).HasTile;
        }
    }

    public class TempleStairs : GenPass
    {
        public TempleStairs(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Placing temple stairs";

            for (int y = 40; y < Main.maxTilesY - 200; y++)
            {
                for (int x = 40; x < Main.maxTilesX - 40; x++)
                {
                    if (IsBrick(x, y + 1) && !Framing.GetTileSafely(x, y).HasTile && Framing.GetTileSafely(x, y).WallType == WallID.LihzahrdBrickUnsafe)
                    {
                        bool left = false;
                        bool right = false;
                        if (IsBrick(x - 1, y) && !WGTools.FullTile(x - 1, y - 1))
                        {
                            left = true;
                        }
                        if (IsBrick(x + 1, y) && !WGTools.FullTile(x + 1, y - 1))
                        {
                            right = true;
                        }

                        if (IsBrick(x - 1, y) && IsBrick(x + 1, y))
                        {
                            WorldGen.PlaceTile(x, y, TileID.LihzahrdBrick);
                        }
                        else if (left || right)
                        {
                            WorldGen.PlaceTile(x, y, TileID.Platforms, style: 33);

                            if (left && !right)
                            {
                                Framing.GetTileSafely(x, y).Slope = SlopeType.SlopeDownLeft;
                                Framing.GetTileSafely(x, y).TileFrameX = 18 * 10;
                            }
                            else if (right && !left)
                            {
                                Framing.GetTileSafely(x, y).Slope = SlopeType.SlopeDownRight;
                                Framing.GetTileSafely(x, y).TileFrameX = 18 * 8;
                            }
                        }
                    }
                }
            }
        }

        private bool IsBrick(int x, int y)
        {
            return Framing.GetTileSafely(x, y).TileType == TileID.LihzahrdBrick && Framing.GetTileSafely(x, y).HasTile;
        }
    }
    #endregion

    public class SpawnCampsite : GenPass
    {
        public SpawnCampsite(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            //PlaceObjectInArea(Main.spawnTileX - 5, Main.spawnTileY - 3, Main.spawnTileX + 5, Main.spawnTileY + 3, TileID.Campfire);
            PlaceObjectInArea(Main.spawnTileX - 5, Main.spawnTileY - 3, Main.spawnTileX + 5, Main.spawnTileY + 3, TileID.LargePiles2, style2: 26);
        }

        private void PlaceObjectInArea(int left, int top, int right, int bottom, int tile, int style2 = 0, int count = 1, int attemptLimit = 1000)
        {
            while (count > 0)
            {
                bool success = false;
                int attempts = 0;
                while (!success && attempts <= attemptLimit)
                {
                    attempts++;

                    int x = WorldGen.genRand.Next(left, right + 1);
                    int y = WorldGen.genRand.Next(top, bottom + 1);

                    if (Framing.GetTileSafely(x, y).TileType != tile)
                    {
                        WorldGen.PlaceObject(x, y, tile, style: style2, direction: WorldGen.genRand.NextBool(2) ? 1 : -1);
                    }
                    success = Framing.GetTileSafely(x, y).TileType == tile;
                    if (success)
                    {
                        count--;
                    }
                }
                if (attempts > attemptLimit)
                {
                    break;
                }
            }
        }
    }

    public class DirtWallCleanup : GenPass
    {
        public DirtWallCleanup(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            for (int y = 40; y < Main.worldSurface; y++)
            {
                //progress.Set(y / (int)Main.worldSurface / 2 + 0.5f);

                for (int x = 40; x < Main.maxTilesX - 40; x++)
                {
                    if (WGTools.Tile(x - 1, y).WallType == WallID.DirtUnsafe)
                    {
                        if (WGTools.Tile(x + 1, y).WallType == WallID.DirtUnsafe || WGTools.Tile(x + 2, y).WallType == WallID.DirtUnsafe || WGTools.Tile(x + 3, y).WallType == WallID.DirtUnsafe || WGTools.Tile(x + 4, y).WallType == WallID.DirtUnsafe)
                        {
                            WGTools.Tile(x, y).WallType = WallID.DirtUnsafe;
                        }
                    }
                }
            }
        }
    }

    public class WGTools : ModSystem
    {
        public static Tile Tile(float x, float y)
        {
            if (!WorldGen.InWorld((int)x, (int)y))
            {
                return Framing.GetTileSafely(1, 1);
            }
            return Framing.GetTileSafely((int)x, (int)y);
        }

        public static bool FullTile(float x, float y)
        {
            return Tile(x, y).HasTile && Main.tileSolid[Tile(x, y).TileType] && !Main.tileSolidTop[Tile(x, y).TileType] && Tile(x, y).Slope == SlopeType.Solid && !Tile(x, y).IsHalfBlock;
        }

        public static void Rectangle(int left, int top, int right, int bottom, int type = -2, int wall = -2, bool add = true, bool replace = true, int style = 0, int liquid = -1, int liquidType = -1)
        {
            for (int y = top; y <= bottom; y++)
            {
                for (int x = left; x <= right; x++)
                {
                    if (WorldGen.InWorld(x, y))
                    {
                        if (liquid != -1)
                        {
                            Framing.GetTileSafely(x, y).LiquidAmount = (byte)liquid;
                        }
                        if (liquidType != -1)
                        {
                            Framing.GetTileSafely(x, y).LiquidType = liquidType;
                        }

                        if (type == -1)
                        {
                            if (Framing.GetTileSafely(x, y).HasTile)
                            {
                                Framing.GetTileSafely(x, y).HasTile = false;
                            }
                        }
                        else if (type != -2)
                        {
                            //Framing.GetTileSafely(x, y).Slope = 0;
                            //Framing.GetTileSafely(x, y).IsHalfBlock = false;
                            if (replace && Framing.GetTileSafely(x, y).HasTile || add && !Framing.GetTileSafely(x, y).HasTile)
                            {
                                WorldGen.KillTile(x, y);
                                WorldGen.PlaceTile(x, y, type, style: style);
                            }
                        }

                        if (wall == -1)
                        {
                            Framing.GetTileSafely(x, y).WallType = 0;
                        }
                        else if (wall != -2)
                        {
                            if (replace && Framing.GetTileSafely(x, y).WallType != 0 || add && Framing.GetTileSafely(x, y).WallType == 0)
                            {
                                Framing.GetTileSafely(x, y).WallType = (ushort)wall;
                            }
                        }
                    }
                }
            }
        }

        public static void Circle(float x2, float y2, float radius, int type = -2, int wall = -2, float xMultiplier = 1f, float yMultiplier = 1f, bool add = true, bool replace = true, int liquid = -1, int liquidType = -1)
        {
            for (int y = (int)(y2 - radius * yMultiplier); y <= y2 + radius * yMultiplier; y++)
            {
                for (int x = (int)(x2 - radius * xMultiplier); x <= x2 + radius * xMultiplier; x++)
                {
                    if (Vector2.Distance(new Vector2(x2, y2), new Vector2((x - x2) / xMultiplier + x2, (y - y2) / yMultiplier + y2)) < radius && WorldGen.InWorld(x, y))
                    {
                        Tile tile = Main.tile[x, y];

                        if (liquid != -1)
                        {
                            tile.LiquidAmount = (byte)liquid;
                        }
                        if (liquidType != -1)
                        {
                            tile.LiquidType = liquidType;
                        }

                        if (type == -1)
                        {
                            if (tile.HasTile)
                            {
                                tile.HasTile = false;
                            }
                        }
                        else if (type != -2)
                        {
                            //tile.Slope = 0;
                            //tile.IsHalfBlock = false;
                            if (replace && tile.HasTile && tile.TileType != ModContent.TileType<devtile>() || add && !tile.HasTile)
                            {
                                tile.HasTile = false;
                                WorldGen.PlaceTile(x, y, type);
                            }
                        }

                        if (wall == -1)
                        {
                            tile.WallType = 0;
                        }
                        else if (wall != -2)
                        {
                            if (replace && tile.WallType != 0 || add && tile.WallType == 0)
                            {
                                tile.WallType = (ushort)wall;
                            }
                        }
                    }
                }
            }
        }

        public static bool SurroundingTilesActive(float x, float y, bool checkSolid = false)
        {
            if (Tile(x + 1, y).HasTile && Tile(x + 1, y + 1).HasTile && Tile(x, y + 1).HasTile && Tile(x - 1, y + 1).HasTile && Tile(x - 1, y).HasTile && Tile(x - 1, y - 1).HasTile && Tile(x, y - 1).HasTile && Tile(x + 1, y - 1).HasTile)
            {
                if (checkSolid)
                {
                    if (WGTools.FullTile(x + 1, y) && WGTools.FullTile(x + 1, y + 1) && WGTools.FullTile(x, y + 1) && WGTools.FullTile(x - 1, y + 1) && WGTools.FullTile(x - 1, y) && WGTools.FullTile(x - 1, y - 1) && WGTools.FullTile(x, y - 1) && WGTools.FullTile(x + 1, y - 1))
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            return false;
        }

        public static int AdjacentTiles(float x, float y, bool checkSolid = false)
        {
            int adjacentTiles = 0;
            if (checkSolid)
            {
                if (Tile(x + 1, y).HasTile && Main.tileSolid[Tile(x + 1, y).TileType] && Tile(x, y - 1).TileType != TileID.Platforms) { adjacentTiles++; }
                if (Tile(x - 1, y).HasTile && Main.tileSolid[Tile(x - 1, y).TileType] && Tile(x, y - 1).TileType != TileID.Platforms) { adjacentTiles++; }
                if (Tile(x, y + 1).HasTile && Main.tileSolid[Tile(x, y + 1).TileType] && Tile(x, y - 1).TileType != TileID.Platforms) { adjacentTiles++; }
                if (Tile(x, y - 1).HasTile && Main.tileSolid[Tile(x, y - 1).TileType] && Tile(x, y - 1).TileType != TileID.Platforms) { adjacentTiles++; }
            }
            else
            {
                if (Tile(x + 1, y).HasTile) { adjacentTiles++; }
                if (Tile(x - 1, y).HasTile) { adjacentTiles++; }
                if (Tile(x, y + 1).HasTile) { adjacentTiles++; }
                if (Tile(x, y - 1).HasTile) { adjacentTiles++; }
            }
            return adjacentTiles;
        }
    }
}