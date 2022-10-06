using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using MountClass.NPCs;
using MountClass.Projectiles; //This is here so that Screenshake works.

namespace MountClass.Mounts
{
	public partial class Mech1 : ModMount
	{
		public override void UseAbility(Player player, Vector2 mousePosition, bool toggleOn)
		{
			//if (MountData.abilityCooldown <= 10)
			MountClassPlayer mcp = player.GetModPlayer<MountClassPlayer>();
			Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (rocketTimer > 0)
            {
				rocketTimer--;
			}
			if (rocketTimer == 180)
			{
				if (MountClassConfigClient.Instance.enableVanillaSounds)
				{
					SoundEngine.PlaySound(SoundID.Item108, player.position);
				}
				else
				{
					SoundEngine.PlaySound(Sounds.Mech.RocketReload1, player.position);
					SoundEngine.PlaySound(Sounds.Mech.Overheat, player.position);
					//SoundEngine.PlaySound(Sounds.Mech.ChainLoopHeavy, player.position);
				}
			}
			if (rocketTimer == 120)
			{
				SoundEngine.PlaySound(Sounds.Mech.ChainLoopHeavy, player.position);
			}
			if (rocketTimer == 60)
			{
				SoundEngine.PlaySound(Sounds.Mech.ChainLoopHeavy, player.position);
			}
			if (rocketTimer == 1)
			{
				if (MountClassConfigClient.Instance.enableVanillaSounds)
				{
					SoundEngine.PlaySound(SoundID.Item108, player.position);
				}
				else
				{
					SoundEngine.PlaySound(Sounds.Mech.RocketReload2, player.position);
				}
			}
			if (grenadeTimer > 0)
            {
				grenadeTimer--;
			}
			if (grenadeTimer == 180)
			{
				SoundEngine.PlaySound(Sounds.Mech.ChainLoopLight, player.position);
			}
			if (grenadeTimer == 120)
			{
				SoundEngine.PlaySound(Sounds.Mech.ChainLoopLight, player.position);
			}
			if (grenadeTimer == 60)
			{
				SoundEngine.PlaySound(Sounds.Mech.ChainLoopLight, player.position);
			}
			if (grenadeTimer == 1)
			{
				if (MountClassConfigClient.Instance.enableVanillaSounds)
				{
					SoundEngine.PlaySound(SoundID.Item108, player.position);
				}
				else
				{
					SoundEngine.PlaySound(Sounds.Mech.GrenadeReload1, player.position);
				}
			}
			if (gunTimer > 0)
            {
				gunTimer--;
			}
			if (heavyCannonTimer > 0)
            {
				heavyCannonTimer--;
			}
			if (heavyCannonTimer == 80)
			{
				Vector2 direction = (target - player.Center).SafeNormalize(Vector2.UnitX);
				int casing = Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, direction * -6f, ModContent.ProjectileType<HeavyCannonCasing>(), 0, 0f, player.whoAmI);
				if (MountClassConfigClient.Instance.enableVanillaSounds)
				{
					SoundEngine.PlaySound(SoundID.Item108, player.position);
				}
				else
				{
					SoundEngine.PlaySound(Sounds.Mech.HeavyCannonReload1, player.position);
				}
			}
			if (heavyCannonTimer == 60)
			{
				if (MountClassConfigClient.Instance.enableVanillaSounds)
				{
					SoundEngine.PlaySound(SoundID.Item108, player.position);
				}
				else
				{
					SoundEngine.PlaySound(Sounds.Mech.ChainLoopHeavy, player.position);
					SoundEngine.PlaySound(Sounds.Mech.ChainLoopLight, player.position);
				}
			}
			if (heavyCannonTimer == 50)
			{
				if (MountClassConfigClient.Instance.enableVanillaSounds)
				{
					SoundEngine.PlaySound(SoundID.Item108, player.position);
				}
				else
				{
					SoundEngine.PlaySound(Sounds.Mech.HeavyCannonReload2, player.position);
				}
			}
			if (selectTimer > 0)
            {
				selectTimer--;
            }
			if (mechUsageDelay > 0)
            {
				mechUsageDelay--;
            }
			if (!player.mouseInterface && mechUsageDelay <= 0)
			{
				if (Main.mouseLeft && weaponSelect <= 0)
				{
				}
				if (Main.mouseLeft && rocketTimer <= 0 && weaponSelect == 1)
				{
					Vector2 direction = (target - player.Center).SafeNormalize(Vector2.UnitX);
					if (mcp.upgradeRocket)
					{
						int proj = Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, direction * 6f, ProjectileID.ClusterRocketI, 0, 3f, player.whoAmI);
						Main.projectile[proj].damage = MountClassConfig.Instance.weaponUpgradedRocketDamage;
					}
					else
					{
						int proj = Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, direction * 6f, ProjectileID.RocketIII, 0, 3f, player.whoAmI);
						Main.projectile[proj].damage = MountClassConfig.Instance.weaponRocketDamage;
					}
					rocketTimer = 241;
					if (MountClassConfigClient.Instance.enableVanillaSounds)
					{
						SoundEngine.PlaySound(SoundID.Item11, player.position);
					}
					else
					{
						SoundEngine.PlaySound(Sounds.Mech.RocketFire, player.position);
					}
					Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileModerate>(), 0, 0, player.whoAmI);
				}
				if (Main.mouseLeft && grenadeTimer <= 0 && weaponSelect == 2)
				{
					Vector2 direction = (target - player.Center).SafeNormalize(Vector2.UnitX);
					int proj = Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, direction * 6f, ProjectileID.Grenade, 0, 3f, player.whoAmI);
					Main.projectile[proj].damage = MountClassConfig.Instance.weaponGrenadeDamage;
					if (mcp.upgradeGrenade)
					{
						//WIP Ammo Code that I gave up on.
						/*if (grenadeAmmo == 0)
						{
							grenadeAmmo = 3;
							grenadeTimer = 240;
						}
						else if (weapponDelay == 0)
						{
							grenadeAmmo--;
							weapponDelay = 10;
						}
						if (weapponDelay > 0)	{weapponDelay--;}*/
						grenadeTimer = 120;
					}
					else
					{
						grenadeTimer = 240;
					}
					if (MountClassConfigClient.Instance.enableVanillaSounds)
					{
						SoundEngine.PlaySound(SoundID.Item61, player.position);
					}
					else
					{
						SoundEngine.PlaySound(Sounds.Mech.GrenadeFire, player.position);
					}
					Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileModerate>(), 0, 0, player.whoAmI);
				}
				if (Main.mouseLeft && heavyCannonTimer <= 0 && weaponSelect == 3)
				{
					Vector2 direction = (target - player.Center).SafeNormalize(Vector2.UnitX);
					int proj = Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, direction * 6f, ProjectileID.BulletHighVelocity, 0, 3f, player.whoAmI);
					if (mcp.upgradeHeavyCannon)
					{
						Main.projectile[proj].damage = MountClassConfig.Instance.weaponUpgradedHeavyCannonDamage;
					}
					else
					{
						Main.projectile[proj].damage = MountClassConfig.Instance.weaponHeavyCannonDamage;
					}
					heavyCannonTimer = 100;
					if (MountClassConfigClient.Instance.enableVanillaSounds)
					{
						SoundEngine.PlaySound(SoundID.Item40, player.position);
					}
					else
					{
						SoundEngine.PlaySound(Sounds.Mech.HeavyCannonFire, player.position);
					}
					Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileStrong>(), 0, 0, player.whoAmI);
				}
				if (Main.mouseLeft && gunTimer <= 0 && weaponSelect == 4)
				{
					Vector2 direction = (target - player.Center).SafeNormalize(Vector2.UnitX);
					int proj = Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, direction * 6f, ProjectileID.Bullet, 0, 3f, player.whoAmI);
					int casing = Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, direction * -6f, ModContent.ProjectileType<GunCasing>(), 0, 0f, player.whoAmI);
					if (mcp.upgradeGun)
					{
						Main.projectile[proj].damage = MountClassConfig.Instance.weaponUpgradedMachineGunDamage;
						if (MountClassConfigClient.Instance.enableVanillaSounds)
						{
							SoundEngine.PlaySound(SoundID.Item40, player.position);
						}
						else
						{
							SoundEngine.PlaySound(Sounds.Mech.GunUpgradedFire, player.position);
						}
						Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileModerate>(), 0, 0, player.whoAmI);
					}
					else
					{
						Main.projectile[proj].damage = MountClassConfig.Instance.weaponMachineGunDamage;
						if (MountClassConfigClient.Instance.enableVanillaSounds)
						{
							SoundEngine.PlaySound(SoundID.Item40, player.position);
						}
						else
						{
							SoundEngine.PlaySound(Sounds.Mech.GunFire, player.position);
						}
						Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileWeak>(), 0, 0, player.whoAmI);
					}
					gunTimer = 10;
				}
				
				if (Main.netMode != NetmodeID.Server)
				{
					//Keybind Weapon Selection
					if (MountClass.SelectDisarmed.JustPressed)
					{
						weaponSelect = 0;
						//Main.NewText("No Weapon selected");
					}
					if (MountClass.SelectGun.JustPressed)
					{
						weaponSelect = 4;
						//Main.NewText("Machine Gun selected");
						if (MountClassConfigClient.Instance.enableVanillaSounds)
						{
							SoundEngine.PlaySound(SoundID.Item149, player.position);
						}
						else
						{
							SoundEngine.PlaySound(Sounds.Mech.SwitchGun, player.position);
						}
					}
					if (MountClass.SelectHeavyCannon.JustPressed)
					{
						weaponSelect = 3;
						//Main.NewText("Heavy Cannon selected");
						if (MountClassConfigClient.Instance.enableVanillaSounds)
						{
							SoundEngine.PlaySound(SoundID.Item13, player.position);
						}
						else
						{
							SoundEngine.PlaySound(Sounds.Mech.SwitchHeavyCannon, player.position);
						}
					}
					if (MountClass.SelectGrenade.JustPressed)
					{
						weaponSelect = 2;
						//Main.NewText("Grenade Launcher selected");
						if (MountClassConfigClient.Instance.enableVanillaSounds)
						{
							SoundEngine.PlaySound(SoundID.Item108, player.position);
						}
						else
						{
							SoundEngine.PlaySound(Sounds.Mech.SwitchGrenade, player.position);
						}
					}
					if (MountClass.SelectRocket.JustPressed)
					{
						weaponSelect = 1;
						//Main.NewText("Rocket Launcher selected");
						if (MountClassConfigClient.Instance.enableVanillaSounds)
						{
							SoundEngine.PlaySound(SoundID.Item13, player.position);
						}
						else
						{
							SoundEngine.PlaySound(Sounds.Mech.SwitchRocket, player.position);
						}
					}
				}
			}
		}
    }
}