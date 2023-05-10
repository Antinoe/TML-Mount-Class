using Terraria;
using Terraria.ModLoader;

namespace MountClass.Projectiles
{
	public class ScreenshakeProjectileVeryWeak : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Melee;
			Projectile.damage = 0;
			Projectile.width = 2;
			Projectile.height = 2;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 10;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}
		public override void AI()
        {
			Player target = Main.player[Projectile.owner];
			target.GetModPlayer<MountClassPlayer>().screenShakeTimerWeak = 5;
		}
	}
}
