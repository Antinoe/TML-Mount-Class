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
		public override void UpdateEffects(Player player)
		{
			MountClassPlayer mcp = player.GetModPlayer<MountClassPlayer>();
			//player.delayUseItem = true;
			player.endurance += MountClassConfig.Instance.mechEndurance;
			if (mcp.upgradeArmor)
			{
				player.endurance += MountClassConfig.Instance.mechUpgradedEndurance;
			}
			player.thorns += MountClassConfig.Instance.mechThorns;
			if (mcp.upgradeThorns)
			{
				player.thorns += MountClassConfig.Instance.mechUpgradedThorns;
			}
			//Stepping
			if (player.velocity.Y == 0)
			{
				if (player.velocity.X > 0 || player.velocity.X < 0)
				{
					//Thanks for showing me what check to use, GabeHasWon. -Antinous
					if (player.mount?._frame == 1 || player.mount?._frame == 3)
					{
						//I thank you for this, Nakano. This is one of the most important Coding-related things I learned this year. -Antinous
						if (!stepping)
						{
							stepping = true;
							Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileModerate>(), 0, 0, player.whoAmI);
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
						stepping = false;
					}
				}
			}
			//Jumping
			if (player.velocity.Y < 0 && player.controlJump)
			{
				if (!jumping)
				{
					jumping = true;
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
				jumping = false;
			}
			//Landing
			if (player.velocity.Y == 0)
			{
				if (!landing)
				{
					landing = true;
					Projectile.NewProjectile(Projectile.GetSource_None(), player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileModerate>(), 0, 0, player.whoAmI);
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
				landing = false;
			}
		}
    }
}