using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace WombatQOL.Projectiles
{
    public class greenlaser : ModProjectile
    {
        public override void SetDefaults()
        {
            Main.projFrames[Type] = 4;

            Projectile.width = 20;
            Projectile.height = 20;

            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.damage = 0;

            Projectile.aiStyle = -1;

            Projectile.frameCounter = -1;
        }
        public override void AI()
        {
            if (++Projectile.frameCounter >= 2)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame > Main.projFrames[Type] - 1)
                {
                    Projectile.Kill();
                }
            }
        }

        public override void PostDraw(Color lightColor)
        {
            Vector2 position = Projectile.position - Main.screenPosition;
            Rectangle rect = new Rectangle(0, Projectile.frame * Projectile.height, Projectile.width, Projectile.height);
            Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, position, rect, Color.White, Projectile.rotation, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            overPlayers.Add(index);
        }
    }
}