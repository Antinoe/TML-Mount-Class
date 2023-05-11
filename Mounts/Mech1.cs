using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using MountClass;
using MountClass.NPCs;
using MountClass.Projectiles;
using Terraria.Graphics.CameraModifiers;

namespace MountClass.Mounts
{
	public partial class Mech1 : ModMount
	{
		public override void SetStaticDefaults()
		{
            //MountData.buff = ModContent.BuffType<Mech1Mount>();
            MountData.heightBoost = 20;
			MountData.fallDamage = 0.0f;
			MountData.runSpeed = 1.2f;
			MountData.dashSpeed = 1.2f;
			MountData.flightTimeMax = 0;
			MountData.fatigueMax = 0;
			MountData.jumpSpeed = 3f;
			MountData.jumpHeight = 12;
			MountData.acceleration = 0.20f;
			MountData.blockExtraJumps = true;
			MountData.totalFrames = 4;
			MountData.constantJump = false;
			int[] array = new int[MountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 20;
			}
			MountData.playerYOffsets = array;
			MountData.xOffset = 15;
			MountData.bodyFrame = 3;
			MountData.yOffset = 7;
			MountData.playerHeadOffset = 22;
			MountData.standingFrameCount = 1;
			MountData.standingFrameDelay = 12;
			MountData.standingFrameStart = 0;
			MountData.runningFrameCount = 4;
			MountData.runningFrameDelay = 25;
			MountData.runningFrameStart = 0;
			MountData.flyingFrameCount = 0;
			MountData.flyingFrameDelay = 0;
			MountData.flyingFrameStart = 0;
			MountData.inAirFrameCount = 1;
			MountData.inAirFrameDelay = 12;
			MountData.inAirFrameStart = 1;
			MountData.idleFrameCount = 1;
			MountData.idleFrameDelay = 120;
			MountData.idleFrameStart = 0;
			MountData.idleFrameLoop = false;
			MountData.swimFrameCount = MountData.inAirFrameCount;
			MountData.swimFrameDelay = MountData.inAirFrameDelay;
			MountData.swimFrameStart = MountData.inAirFrameStart;
			if (Main.netMode != NetmodeID.Server)
			{
				MountData.textureWidth = MountData.backTexture.Width() + 20;
				MountData.textureHeight = MountData.backTexture.Height();
			}
		}

		public override void SetMount(Player player, ref bool skipDust)
		{
			var mcp = player.GetModPlayer<MountClassPlayer>();
			skipDust = true;
			mcp.mechUsageDelay = 20;
			if (mcp.mechWelcomeCooldown <= 0)
			{
				if (MountClassConfigClient.Instance.enableMechWelcome)
				{
					SoundEngine.PlaySound(Sounds.Mech.MechWelcome, player.position);
				}
				mcp.mechWelcomeCooldown = MountClassConfigClient.Instance.mechWelcomeCooldown;
			}
			if (MountClassConfigClient.Instance.enableVanillaSounds)
			{
				SoundEngine.PlaySound(SoundID.Dig, player.position);
			}
			else
			{
				SoundEngine.PlaySound(Sounds.Mech.MechEnter, player.position);
			}
		}

		public override void Dismount(Player player, ref bool skipDust)
		{
			var mcp = player.GetModPlayer<MountClassPlayer>();
			mcp.mechWelcomeCooldown = MountClassConfigClient.Instance.mechWelcomeCooldown;
			skipDust = true;
			if (MountClassConfigClient.Instance.enableVanillaSounds)
			{
				SoundEngine.PlaySound(SoundID.Dig, player.position);
			}
			else
			{
			}
			if (mcp.mechDestroyed)
			{
				mcp.mechDestroyed = false;
			}
			else
			{
				NPC.NewNPC(NPC.GetSource_None(), (int)player.position.X, (int)player.position.Y, ModContent.NPCType<Mech1NPC>());
			}
		}
		public override void UpdateEffects(Player player)
		{
			MountClassPlayer mcp = player.GetModPlayer<MountClassPlayer>();
			//player.delayUseItem = true;
			Terraria.GameInput.PlayerInput.LockVanillaMouseScroll("mech1");
			mcp.mechArmor += MountClassConfig.Instance.mechArmor;
			if (mcp.mechUpgradeArmor)
			{
				mcp.mechArmor += MountClassConfig.Instance.mechUpgradedArmor;
			}
			player.thorns += MountClassConfig.Instance.mechThorns;
			if (mcp.mechUpgradeThorns)
			{
				player.thorns += MountClassConfig.Instance.mechUpgradedThorns;
			}
			//mcp.stepping
			if (player.velocity.Y == 0)
			{
				if (player.velocity.X > 0 || player.velocity.X < 0)
				{
					//Thanks for showing me what check to use, GabeHasWon. -Antinous
					if (player.mount?._frame == 1 || player.mount?._frame == 3)
					{
						//I thank you for this, Nakano. This is one of the most important Coding-related things I learned this year. -Antinous
						if (!mcp.stepping)
						{
							mcp.stepping = true;
							PunchCameraModifier screenshake = new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1f, 6f, 20, 30f, FullName);
							Main.instance.CameraModifiers.Add(screenshake);
							if (MountClassConfigClient.Instance.enableVanillaSounds)
							{
								SoundEngine.PlaySound(SoundID.Item53, player.position);
							}
							else
							{
								SoundEngine.PlaySound(Sounds.Mech.MechStep, player.position);
							}
						}
					}
					else
					{
						mcp.stepping = false;
					}
				}
			}
			//mcp.jumping
			if (player.velocity.Y < 0 && player.controlJump)
			{
				if (!mcp.jumping)
				{
					mcp.jumping = true;
					if (MountClassConfigClient.Instance.enableVanillaSounds)
					{
					}
					else
					{
						SoundEngine.PlaySound(Sounds.Mech.MechJump, player.position);
					}
				}
			}
			else
			{
				mcp.jumping = false;
			}
			//mcp.landing
			if (player.velocity.Y == 0)
			{
				if (!mcp.landing)
				{
					mcp.landing = true;
					PunchCameraModifier screenshake = new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1f, 6f, 20, 75f, FullName);
					Main.instance.CameraModifiers.Add(screenshake);
					if (MountClassConfigClient.Instance.enableVanillaSounds)
					{
					}
					else
					{
						SoundEngine.PlaySound(Sounds.Mech.MechStep, player.position);
						SoundEngine.PlaySound(Sounds.Mech.MechStep, player.position);
					}
				}
			}
			else
			{
				mcp.landing = false;
			}
		}
		public override void UseAbility(Player player, Vector2 mousePosition, bool toggleOn)
		{
			var mcp = player.GetModPlayer<MountClassPlayer>();
			//player.selectedItem = 11;
			//Main.mouseItem.type = ItemID.Gel;
			if (mcp.weaponSelected)
			{
				//player.inventory[58].type = ItemID.Handgun;
				player.inventory[58].type = ModContent.ItemType<Items.Mech1Weaponry>();
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
					SoundEngine.PlaySound(Sounds.Mech.EjectHeavyCannon, player.position);
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
					PunchCameraModifier screenshake = new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1f, 6f, 20, 150f, FullName);
					Main.instance.CameraModifiers.Add(screenshake);
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
					PunchCameraModifier screenshake = new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1f, 6f, 20, 150f, FullName);
					Main.instance.CameraModifiers.Add(screenshake);
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
					PunchCameraModifier screenshake = new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1f, 6f, 20, 150f, FullName);
					Main.instance.CameraModifiers.Add(screenshake);
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
							PunchCameraModifier screenshake = new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1f, 6f, 20, 150f, FullName);
							Main.instance.CameraModifiers.Add(screenshake);
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
							PunchCameraModifier screenshake = new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1f, 6f, 20, 150f, FullName);
							Main.instance.CameraModifiers.Add(screenshake);
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
						PunchCameraModifier screenshake = new PunchCameraModifier(Main.LocalPlayer.Center, (Main.rand.NextFloat() * (MathHelper.TwoPi)).ToRotationVector2(), 1f, 6f, 20, 150f, FullName);
						Main.instance.CameraModifiers.Add(screenshake);
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