using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WombatQOL.Dusts
{
	public class junglefirefly : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
            dust.scale = 1;
            dust.noGravity = true;
            dust.velocity = Main.rand.NextVector2Circular(1f, 1f) * 1f;
        }

        public override bool Update(Dust dust)
        {
            if (Main.rand.NextBool(200))
            {
                dust.active = false;
            }
            else
            {
                dust.position += dust.velocity;

                dust.velocity *= 0.97f;
                dust.velocity += Main.rand.NextVector2Circular(1f, 1f) * 0.2f;

                Lighting.AddLight(dust.position, 161 / 255 * dust.scale * 0.1f, dust.scale * 0.1f, 0);
            }

            return false;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return Color.White;
        }
    }

    public class honeyfirefly : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.scale = 1;
            dust.noGravity = true;
            dust.velocity = Main.rand.NextVector2Circular(1f, 1f) * 1f;
        }

        public override bool Update(Dust dust)
        {
            if (Main.rand.NextBool(200))
            {
                dust.active = false;
            }
            else
            {
                dust.position += dust.velocity;

                dust.velocity *= 0.97f;
                dust.velocity += Main.rand.NextVector2Circular(1f, 1f) * 0.2f;

                Lighting.AddLight(dust.position, dust.scale * 0.1f, 194 / 255 * dust.scale * 0.1f, 0);
            }

            return false;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return Color.White;
        }
    }

    public class hallowfirefly : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.scale = 1;
            dust.noGravity = true;
            dust.velocity = Main.rand.NextVector2Circular(1f, 1f) * 1f;
        }

        public override bool Update(Dust dust)
        {
            if (Main.rand.NextBool(200))
            {
                dust.active = false;
            }
            else
            {
                dust.position += dust.velocity;

                dust.velocity *= 0.97f;
                dust.velocity += Main.rand.NextVector2Circular(1f, 1f) * 0.2f;

                Lighting.AddLight(dust.position, 168 / 255 * dust.scale * 0.1f, 168 / 255 * dust.scale * 0.1f, dust.scale * 0.1f);
            }

            return false;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return Color.White;
        }
    }
}