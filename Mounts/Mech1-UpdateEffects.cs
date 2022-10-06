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
				mcp.landing = false;
			}
		}
    }
}