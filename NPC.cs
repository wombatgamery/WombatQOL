using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using WombatQOL.Gores;
using Terraria.GameContent.ItemDropRules;
using System.Collections.Generic;
using WombatQOL.Items.Artifacts;
using System.Linq;
using WombatQOL.Items.Materials;
using Terraria.GameContent.Bestiary;

namespace WombatQOL
{
	public class QOLNPC : GlobalNPC
	{
		public override void SetDefaults(NPC npc)
		{
			if (ModContent.GetInstance<Gameplay>().SafeBoundNPCs && (npc.type == NPCID.BoundGoblin || npc.type == NPCID.BoundMechanic || npc.type == NPCID.BoundWizard || npc.type == NPCID.WebbedStylist || npc.type == NPCID.BartenderUnconscious))
			{
				npc.dontTakeDamageFromHostiles = true;
			}
			else if (ModContent.GetInstance<Gameplay>().SafeCritters && npc.damage == 0 && npc.lifeMax <= 10 && npc.value == 0)
			{
				npc.dontTakeDamageFromHostiles = true;
			}
		}

		public override void PostAI(NPC npc)
		{
			if (ModContent.GetInstance<Visuals>().GraniteEnemyGlow)
			{
				if (npc.type == NPCID.GraniteGolem || npc.type == NPCID.GraniteFlyer)
				{
					Lighting.AddLight(npc.position, (13f / 255f), (114f / 255f), (182f / 255f));
				}
			}
		}

   //     public override void SetBestiary(NPC npc, BestiaryDatabase database, BestiaryEntry bestiaryEntry)
   //     {
   //         if (npc.IsShimmerVariant || npc.type == NPCID.Shimmerfly || npc.type == NPCID.ShimmerSlime)
   //         {
   //             bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {

			//	new ModBiomeBestiaryInfoElement(ModContent.GetInstance<WombatQOL>(), "Shimmer", "WombatQOL/Biomes/ShimmerIcon", "Terraria/Images/MapBG16", Color.White)
			//});
			//}
   //     }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (ModContent.GetInstance<Gameplay>().GlowingMushrooms)
			{
				if (npc.type == NPCID.GiantFungiBulb)
				{
					npcLoot.Add(ItemDropRule.Common(ItemID.GlowingMushroom, 1, 6, 12));
				}
				else if (npc.type == NPCID.AnomuraFungus || npc.type == NPCID.MushiLadybug || npc.type == NPCID.FungiBulb || npc.type == NPCID.FungoFish || npc.type == NPCID.ZombieMushroom || npc.type == NPCID.ZombieMushroomHat)
				{
					npcLoot.Add(ItemDropRule.Common(ItemID.GlowingMushroom, 1, 4, 8));
				}
				else if (npc.type == NPCID.SporeBat || npc.type == NPCID.SporeSkeleton)
				{
					npcLoot.Add(ItemDropRule.Common(ItemID.GlowingMushroom, 1, 2, 4));
				}
			}

			if (npc.type == NPCID.Harpy)
			{
				if (ModContent.GetInstance<Gameplay>().SoulsOfFlight)
                {
					npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsHardmode(), ItemID.SoulofFlight, 2));
				}
			}

			if (ModContent.GetInstance<Gameplay>().EasyWings)
			{
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GiantHarpyFeather);
				//npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.BoneFeather);
				//npcLoot.RemoveWhere(rule => rule is Drop drop && drop.itemId == ItemID.SpookyTwig);
			}

			if (npc.type == NPCID.KingSlime && ModContent.GetInstance<Gameplay>().KingSlimeKatana)
			{
				npcLoot.Add(ItemDropRule.Common(ItemID.Katana));
			}

			if (NPCID.Sets.BelongsToInvasionPirate[npc.type] && ModContent.GetInstance<Gameplay>().ExoticGold)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ExoticGold>(), npc.type == NPCID.PirateCaptain || npc.type == NPCID.PirateShip ? 1 : 4, npc.type == NPCID.PirateShip ? 10 : 1, npc.type == NPCID.PirateShip ? 10 : 1));

				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenChair);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenToilet);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenDoor);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenTable);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenBed);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenLamp);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenBookcase);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenChandelier);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenLantern);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenCandelabra);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenCandle);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenClock);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenPiano);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenDresser);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenSofa);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenBathtub);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenSink);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenChest);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenPlatform);
				npcLoot.RemoveWhere(rule => rule is CommonDrop drop && drop.itemId == ItemID.GoldenWorkbench);
			}


			if (ModContent.GetInstance<Gameplay>().BossArtifacts)
            {
				if (npc.type == NPCID.KingSlime)
				{
					npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<KingSlimeArtifact>()));
				}
				if (npc.type == NPCID.QueenBee)
				{
					npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<QueenBeeArtifact>()));
				}
				if (npc.type == NPCID.SkeletronHead)
				{
					npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<SkeletronArtifact>()));
				}
				if (npc.type == NPCID.WallofFlesh)
				{
					npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<WallOfFleshArtifact>()));
				}
				if (npc.type == NPCID.Plantera)
				{
					npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<PlanteraArtifact>()));
				}
				if (npc.type == NPCID.Golem)
				{
					npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<GolemArtifact>()));
				}
				if (npc.type == NPCID.DukeFishron)
				{
					npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<DukeFishronArtifact>()));
				}
				if (npc.type == NPCID.MoonLordCore)
				{
					npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<MoonLordArtifact>()));
				}
			}
		}

        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.Merchant && ModContent.GetInstance<Gameplay>().ExoticGold)
            {
				if (shop.TryGetEntry(ItemID.GoldDust, out NPCShop.Entry entry))
				{
					entry.Disable();
				}
			}
        }

        public static bool InFrontOfWall(int wallType)
		{
			Player player = Main.LocalPlayer;
			return Main.tile[(int)player.Center.X / 16, (int)player.Center.Y / 16].WallType == wallType;
		}
	}
}