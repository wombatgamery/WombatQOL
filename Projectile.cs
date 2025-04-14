using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using WombatQOL.Gores;
using Terraria.DataStructures;
using System.Linq;
using WombatQOL.Projectiles;

namespace WombatQOL
{
    public class QOLProjectile : GlobalProjectile
	{
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (ModContent.GetInstance<Client>().LaserFlashes)
            {
                int type = -1;

                if (projectile.type == ProjectileID.GreenLaser)
                {
                    type = ModContent.ProjectileType<greenlaser>();
                }
                else if (projectile.type == ProjectileID.EyeLaser || projectile.type == ProjectileID.PurpleLaser)
                {
                    type = ModContent.ProjectileType<eyelaser>();
                }
                else if (projectile.type == ProjectileID.PinkLaser || projectile.type == ProjectileID.MiniRetinaLaser)
                {
                    type = ModContent.ProjectileType<pinklaser>();
                }
                else if (projectile.type == ProjectileID.DeathLaser)
                {
                    type = ModContent.ProjectileType<deathlaser>();
                }
                else if (projectile.type == ProjectileID.LaserMachinegunLaser || projectile.type == ProjectileID.ZapinatorLaser)
                {
                    type = ModContent.ProjectileType<martianlaser>();
                }
                else if (projectile.type == ProjectileID.NebulaLaser)
                {
                    type = ModContent.ProjectileType<nebulalaser>();
                }

                if (type != -1)
                {
                    int distance = 8;

                    if (projectile.owner != -1)
                    {
                        distance = Main.player[projectile.owner].HeldItem.width - 8;
                    }
                    int projIndex = Projectile.NewProjectile(projectile.GetSource_FromAI(), projectile.Center + Vector2.Normalize(projectile.velocity) * distance, projectile.velocity * projectile.extraUpdates / 2, type, 0, 0);
                }
            }

            if (!ModLoader.TryGetMod("TerrariaOverhaul", out _))
            {
                int[] bullets = new int[16];
                bullets[0] = ProjectileID.Bullet;
                bullets[1] = ProjectileID.CrystalBullet;
                bullets[2] = ProjectileID.CursedBullet;
                bullets[3] = ProjectileID.ChlorophyteBullet;
                bullets[4] = ProjectileID.BulletSnowman;
                bullets[5] = ProjectileID.BulletDeadeye;
                bullets[6] = ProjectileID.BulletHighVelocity;
                bullets[7] = ProjectileID.IchorBullet;
                bullets[8] = ProjectileID.VenomBullet;
                bullets[9] = ProjectileID.PartyBullet;
                bullets[10] = ProjectileID.NanoBullet;
                bullets[11] = ProjectileID.ExplosiveBullet;
                bullets[12] = ProjectileID.GoldenBullet;
                bullets[13] = ProjectileID.SniperBullet;
                bullets[14] = ProjectileID.VortexLaser;
                bullets[15] = ProjectileID.MoonlordBullet;

                if (bullets.Contains(projectile.type) || projectile.type >= ProjectileID.Count && projectile.aiStyle == 1 && projectile.DamageType == DamageClass.Ranged)
                {
                    if (ModContent.GetInstance<Client>().BulletCasings)
                    {
                        int goreIndex = Gore.NewGore(projectile.GetSource_FromAI(), projectile.Center, -Vector2.Normalize(projectile.velocity) * 2, ModContent.GoreType<bulletcasing>(), 1);
                        Main.gore[goreIndex].rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
                    }
                    if (ModContent.GetInstance<Client>().BulletFlashes)
                    {
                        int distance = 16;

                        if (projectile.owner != -1)
                        {
                            distance = Main.player[projectile.owner].HeldItem.width - 8;
                        }
                        int projIndex = Projectile.NewProjectile(projectile.GetSource_FromAI(), projectile.Center + Vector2.Normalize(projectile.velocity) * distance, projectile.velocity * projectile.extraUpdates / 2, ModContent.ProjectileType<muzzleflash>(), 0, 0);
                        Main.projectile[projIndex].rotation = projectile.velocity.ToRotation();
                    }
                }
            }
        }

        public override void Kill(Projectile projectile, int timeLeft)
        {
            if (ModContent.GetInstance<Client>().Screenshake)
            {
                if (projectile.type == ProjectileID.Grenade || projectile.type == ProjectileID.StickyGrenade || projectile.type == ProjectileID.BouncyGrenade || projectile.type == ProjectileID.Beenade || projectile.type == ProjectileID.ExplosiveBullet)
                {
                    QOLPlayer.ScreenShake(projectile.position, 1);
                }
                if (projectile.type == ProjectileID.Bomb || projectile.type == ProjectileID.StickyBomb || projectile.type == ProjectileID.BouncyBomb || projectile.type == ProjectileID.BombFish || projectile.type == ProjectileID.BombSkeletronPrime || projectile.type == ProjectileID.RocketI || projectile.type == ProjectileID.RocketII || projectile.type == ProjectileID.GrenadeI || projectile.type == ProjectileID.GrenadeII || projectile.type == ProjectileID.RocketSnowmanI || projectile.type == ProjectileID.RocketSnowmanII || projectile.type == ProjectileID.RocketSkeleton)
                {
                    QOLPlayer.ScreenShake(projectile.position, 2);
                }
                if (projectile.type == ProjectileID.Dynamite || projectile.type == ProjectileID.StickyDynamite || projectile.type == ProjectileID.BouncyDynamite || projectile.type == ProjectileID.RocketIII || projectile.type == ProjectileID.RocketIV || projectile.type == ProjectileID.GrenadeIII || projectile.type == ProjectileID.GrenadeIV || projectile.type == ProjectileID.RocketSnowmanIII || projectile.type == ProjectileID.RocketSnowmanIV)
                {
                    QOLPlayer.ScreenShake(projectile.position, 3);
                }
                if (projectile.type == ProjectileID.Explosives)
                {
                    QOLPlayer.ScreenShake(projectile.position, 4);
                }

                if (projectile.type == ProjectileID.Meteor3 || projectile.type == ProjectileID.NebulaBlaze1 || projectile.type == ProjectileID.Meteor1 || projectile.type == ProjectileID.Meteor2 || projectile.type == ProjectileID.Meteor3)
                {
                    QOLPlayer.ScreenShake(projectile.position, 1);
                }
                if (projectile.type == ProjectileID.NebulaBlaze2 || projectile.type == ProjectileID.NebulaArcanum)
                {
                    QOLPlayer.ScreenShake(projectile.position, 2);
                }
            }
        }
    }
}