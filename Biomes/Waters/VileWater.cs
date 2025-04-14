using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Biomes.Waters
{
    public class VileWater : ModWaterStyle
    {
        public override int ChooseWaterfallStyle() => ModContent.Find<ModWaterfallStyle>("WombatQOL/VileWaterfall").Slot;

        public override int GetSplashDust() => DustID.Poisoned;

        public override Asset<Texture2D> GetRainTexture() => ModContent.Request<Texture2D>("WombatQOL/Biomes/Waters/VileRain");

        public override byte GetRainVariant() => (byte)Main.rand.Next(3);

        public override int GetDropletGore() => ModContent.GoreType<VileDroplet>();

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 0.9f;
            g = 1f;
            b = 0.8f;
        }
    }
}