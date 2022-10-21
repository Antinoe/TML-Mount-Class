using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;
using MountClass.Items;
using MountClass.NPCs;
using MountClass.Projectiles; //This is here so that Screenshake works.

namespace MountClass.Mounts
{
	public partial class Mech1 : ModMount
	{
		public override void UseAbility(Player player, Vector2 mousePosition, bool toggleOn)
		{
			var mcp = player.GetModPlayer<MountClassPlayer>();
			//player.selectedItem = 11;
			//Main.mouseItem.type = ItemID.Gel;
			if (mcp.weaponSelected)
			{
				//player.inventory[58].type = ItemID.Handgun;
				player.inventory[58].type = ModContent.ItemType<Mech1Weaponry>();
				player.selectedItem = 58;
			}
			Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (mcp.selectTimer > 0)
            {
				mcp.selectTimer--;
            }
			if (mcp.mechUsageDelay > 0)
            {
				mcp.mechUsageDelay--;
            }
			if (mcp.rocketTimer > 0)
            {
				mcp.rocketTimer--;
			}
			if (mcp.grenadeTimer > 0)
            {
				mcp.grenadeTimer--;
			}
			if (mcp.machineGunTimer > 0)
            {
				mcp.machineGunTimer--;
			}
			if (mcp.heavyCannonTimer > 0)
            {
				mcp.heavyCannonTimer--;
			}

			if (mcp.rocketTimer == 180)
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
			if (mcp.rocketTimer == 120)
			{
				SoundEngine.PlaySound(Sounds.Mech.ChainLoopHeavy, player.position);
			}
			if (mcp.rocketTimer == 60)
			{
				SoundEngine.PlaySound(Sounds.Mech.ChainLoopHeavy, player.position);
			}
			if (mcp.rocketTimer == 1)
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
			if (mcp.grenadeTimer == 180)
			{
				SoundEngine.PlaySound(Sounds.Mech.ChainLoopLight, player.position);
			}
			if (mcp.grenadeTimer == 120)
			{
				SoundEngine.PlaySound(Sounds.Mech.ChainLoopLight, player.position);
			}
			if (mcp.grenadeTimer == 60)
			{
				SoundEngine.PlaySound(Sounds.Mech.ChainLoopLight, player.position);
			}
			if (mcp.grenadeTimer == 1)
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
			if (mcp.heavyCannonTimer == 80)
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
			if (mcp.heavyCannonTimer == 60)
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
			if (mcp.heavyCannonTimer == 50)
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
			if (!player.mouseInterface && mcp.mechUsageDelay <= 0)
			{
				if (Main.mouseLeft && mcp.weaponSelect <= 0)
				{
				}
				if (Main.mouseLeft && mcp.rocketTimer <= 0 && mcp.weaponSelect == 1)
				{
					Vector2 direction = (target - player.Center).SafeNormalize(Vector2.UnitX);
					if (mcp.mechUpgradeRocket)
					{
						int proj = Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, direction * 6f, ProjectileID.ClusterRocketI, 0, 3f, player.whoAmI);
						Main.projectile[proj].damage = MountClassConfig.Instance.mechUpgradedRocketDamage;
					}
					else
					{
						int proj = Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, direction * 6f, ProjectileID.RocketIII, 0, 3f, player.whoAmI);
						Main.projectile[proj].damage = MountClassConfig.Instance.mechRocketDamage;
					}
					mcp.rocketTimer = 241;
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
				if (Main.mouseLeft && mcp.grenadeTimer <= 0 && mcp.weaponSelect == 2)
				{
					Vector2 direction = (target - player.Center).SafeNormalize(Vector2.UnitX);
					int proj = Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, direction * 6f, ProjectileID.Grenade, 0, 3f, player.whoAmI);
					Main.projectile[proj].damage = MountClassConfig.Instance.mechGrenadeDamage;
					if (mcp.mechUpgradeGrenade)
					{
						//WIP Ammo Code that I gave up on.
						/*if (grenadeAmmo == 0)
						{
							grenadeAmmo = 3;
							mcp.grenadeTimer = 240;
						}
						else if (weapponDelay == 0)
						{
							grenadeAmmo--;
							weapponDelay = 10;
						}
						if (weapponDelay > 0)	{weapponDelay--;}*/
						mcp.grenadeTimer = 120;
					}
					else
					{
						mcp.grenadeTimer = 240;
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
				if (Main.mouseLeft && mcp.heavyCannonTimer <= 0 && mcp.weaponSelect == 3)
				{
					Vector2 direction = (target - player.Center).SafeNormalize(Vector2.UnitX);
					int proj = Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, direction * 6f, ProjectileID.BulletHighVelocity, 0, 3f, player.whoAmI);
					if (mcp.mechUpgradeHeavyCannon)
					{
						Main.projectile[proj].damage = MountClassConfig.Instance.mechUpgradedHeavyCannonDamage;
					}
					else
					{
						Main.projectile[proj].damage = MountClassConfig.Instance.mechHeavyCannonDamage;
					}
					mcp.heavyCannonTimer = 100;
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
				if (Main.mouseLeft && mcp.machineGunTimer <= 0 && mcp.weaponSelect == 4)
				{
					Vector2 direction = (target - player.Center).SafeNormalize(Vector2.UnitX);
					int proj = Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, direction * 6f, ProjectileID.Bullet, 0, 3f, player.whoAmI);
					int casing = Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, direction * -6f, ModContent.ProjectileType<GunCasing>(), 0, 0f, player.whoAmI);
					if (mcp.mechUpgradeGun)
					{
						//Using the Gatling.
						if (mcp.machineGunGatling)
						{
							Main.projectile[proj].damage = MountClassConfig.Instance.mechMachineGunDamage;
							mcp.machineGunTimer = 5;
							Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileWeak>(), 0, 0, player.whoAmI);
							if (MountClassConfigClient.Instance.enableVanillaSounds)
							{
								SoundEngine.PlaySound(SoundID.Item40, player.position);
							}
							else
							{
								SoundEngine.PlaySound(Sounds.Mech.GunFire, player.position);
							}
						}
						else
						{
							Main.projectile[proj].damage = MountClassConfig.Instance.mechUpgradedMachineGunDamage;
							mcp.machineGunTimer = 10;
							Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileModerate>(), 0, 0, player.whoAmI);
							if (MountClassConfigClient.Instance.enableVanillaSounds)
							{
								SoundEngine.PlaySound(SoundID.Item40, player.position);
							}
							else
							{
								SoundEngine.PlaySound(Sounds.Mech.GunUpgradedFire, player.position);
							}
						}
					}
					else
					{
						Main.projectile[proj].damage = MountClassConfig.Instance.mechMachineGunDamage;
						mcp.machineGunTimer = 10;
						Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileWeak>(), 0, 0, player.whoAmI);
						if (MountClassConfigClient.Instance.enableVanillaSounds)
						{
							SoundEngine.PlaySound(SoundID.Item40, player.position);
						}
						else
						{
							SoundEngine.PlaySound(Sounds.Mech.GunFire, player.position);
						}
					}
				}
				if (Main.mouseRight && mcp.mechUpgradeGun && mcp.selectTimer <= 0 && mcp.weaponSelect == 4)
				{
					if (!mcp.machineGunGatling)
					{
						mcp.machineGunGatling = true;
						mcp.selectTimer = 10;
					}
					else
					{
						mcp.machineGunGatling = false;
						mcp.selectTimer = 10;
					}
					if (MountClassConfigClient.Instance.enableVanillaSounds)
					{
						SoundEngine.PlaySound(SoundID.Item149, player.position);
					}
					else
					{
						SoundEngine.PlaySound(Sounds.Mech.SwitchGun, player.position);
					}
				}
				
				if (Main.netMode != NetmodeID.Server)
				{
					//Keybind Weapon Selection
					if (MountClass.SelectDisarmed.JustPressed)
					{
						mcp.weaponSelected = false;
						mcp.weaponSelect = 0;
					}
					if (MountClass.SelectGun.JustPressed && mcp.selectTimer <= 0)
					{
						mcp.weaponSelected = true;
						mcp.weaponSelect = 4;
						mcp.selectTimer = 60;
						if (MountClassConfigClient.Instance.enableVanillaSounds)
						{
							SoundEngine.PlaySound(SoundID.Item149, player.position);
						}
						else
						{
							SoundEngine.PlaySound(Sounds.Mech.SwitchGun, player.position);
						}
					}
					if (MountClass.SelectHeavyCannon.JustPressed && mcp.selectTimer <= 0)
					{
						mcp.weaponSelected = true;
						mcp.weaponSelect = 3;
						mcp.selectTimer = 60;
						if (MountClassConfigClient.Instance.enableVanillaSounds)
						{
							SoundEngine.PlaySound(SoundID.Item13, player.position);
						}
						else
						{
							SoundEngine.PlaySound(Sounds.Mech.SwitchHeavyCannon, player.position);
						}
					}
					if (MountClass.SelectGrenade.JustPressed && mcp.selectTimer <= 0)
					{
						mcp.weaponSelected = true;
						mcp.weaponSelect = 2;
						mcp.selectTimer = 60;
						if (MountClassConfigClient.Instance.enableVanillaSounds)
						{
							SoundEngine.PlaySound(SoundID.Item108, player.position);
						}
						else
						{
							SoundEngine.PlaySound(Sounds.Mech.SwitchGrenade, player.position);
						}
					}
					if (MountClass.SelectRocket.JustPressed && mcp.selectTimer <= 0)
					{
						mcp.weaponSelected = true;
						mcp.weaponSelect = 1;
						mcp.selectTimer = 60;
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