using System; //For Math functions to work.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Audio;
using Terraria.GameContent;
using ReLogic.Utilities;
using MountClass.Mounts;
using Terraria.GameInput; //This allows the ``ProcessTriggers`` Method to work.

namespace MountClass
{
    public class MountClassPlayer : ModPlayer
    {
        public int screenShakeTimerVeryWeak;
        public int screenShakeTimerWeak;
        public int screenShakeTimerModerate;
        public int screenShakeTimerStrong;
		public bool mechUpgradeGun;
		public bool mechUpgradeGrenade;
		public bool mechUpgradeRocket;
		public bool mechUpgradeHeavyCannon;
		public float mechArmor;
		public bool mechUpgradeArmor;
		public bool mechUpgradeThorns;
		public bool mechDestroyed;
		public bool mechEnergyShield = false;
		public int mechEnergyShieldTimer;
		public int mechWelcomeCooldown = MountClassConfigClient.Instance.mechWelcomeCooldown;
		public SlotId? EnergyShieldLoopSound;
		
		//Mount-specific fields.
		public int rocketTimer;
		public int grenadeTimer;
		public int grenadeAmmo;
		public int weapponDelay;
		public int machineGunTimer;
		public int heavyCannonTimer;
		public int weaponSelect;
		public int selectTimer;
		public int mechUsageDelay;
		public bool stepping;
		public bool jumping;
		public bool falling;
		public bool landing;
		public bool inAir;

        public override void ResetEffects()
        {
            mechUpgradeGun = false;
            mechUpgradeGrenade = false;
            mechUpgradeRocket = false;
            mechUpgradeHeavyCannon = false;
			mechArmor = 0f;
            mechUpgradeArmor = false;
            mechUpgradeThorns = false;
        }
		
		public override void PostUpdateMiscEffects()
		{
			Player player = Main.LocalPlayer;
			//Screenshake
			if (screenShakeTimerVeryWeak > 0)
			{
				screenShakeTimerVeryWeak--;
			}
			if (screenShakeTimerWeak > 0)
			{
				screenShakeTimerWeak--;
			}
			if (screenShakeTimerModerate > 0)
			{
				screenShakeTimerModerate--;
			}
			if (screenShakeTimerStrong > 0)
			{
				screenShakeTimerStrong--;
			}
			if (mechWelcomeCooldown > 0)
			{
				mechWelcomeCooldown--;
			}
			
			//Energy Shield
			if (player.mount.Type == ModContent.MountType<Mech1>())
			{
				if (mechEnergyShield)
				{
					mechEnergyShieldTimer--;
					if (mechEnergyShieldTimer <= 0)
					{
						if (player.statMana > 1)
						{
							player.statMana--;
							mechEnergyShieldTimer = MountClassConfig.Instance.mechEnergyShieldTimer;
						}
						else
						{
							if (EnergyShieldLoopSound is SlotId slot)
							{
								if (SoundEngine.TryGetActiveSound(slot, out var sound))
								{
									sound.Stop();
									EnergyShieldLoopSound = null;
								}
							}
							mechEnergyShield = false;
							SoundEngine.PlaySound(Sounds.Mech.EnergyShieldOff, player.position);
							mechEnergyShieldTimer = MountClassConfig.Instance.mechEnergyShieldTimer;
						}
					}
				}
			}
		}
		
        public override void ModifyScreenPosition() //Screenshake
        {
            if (screenShakeTimerVeryWeak > 0)
            {
				Main.screenPosition.X += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 1.10f);
				Main.screenPosition.Y += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 1.10f);
            }
            if (screenShakeTimerWeak > 0)
            {
				Main.screenPosition.X += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 1.50f);
				Main.screenPosition.Y += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 1.50f);
            }
            if (screenShakeTimerModerate > 0)
            {
				Main.screenPosition.X += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 2.00f);
				Main.screenPosition.Y += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 2.00f);
            }
            if (screenShakeTimerStrong > 0)
            {
				Main.screenPosition.X += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 4.00f);
				Main.screenPosition.Y += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 4.00f);
            }
        }
		
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			Player player = Main.LocalPlayer;
			if (MountClass.EnergyShield.JustPressed && player.mount.Type == ModContent.MountType<Mech1>())
			{
				if (!mechEnergyShield && player.statMana > 1)
				{
					if (EnergyShieldLoopSound is null)
					{
						EnergyShieldLoopSound = SoundEngine.PlaySound(Sounds.Mech.EnergyShieldLoop, player.position);
					}
					mechEnergyShield = true;
					SoundEngine.PlaySound(Sounds.Mech.EnergyShieldOn, player.position);
				}
				else if (mechEnergyShield)
				{
					if (EnergyShieldLoopSound is SlotId slot)
					{
						if (SoundEngine.TryGetActiveSound(slot, out var sound))
						{
							sound.Stop();
							EnergyShieldLoopSound = null;
						}
					}
					mechEnergyShield = false;
					SoundEngine.PlaySound(Sounds.Mech.EnergyShieldOff, player.position);
				}
			}
		}
		
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter)
        {
            Player player = Main.LocalPlayer;
            if (player.mount.Type == ModContent.MountType<Mech1>())
			{
				//damage = (int)((damage - player.statDefense) * (1f - player.endurance));
				damage = (int)((damage) * (1f - mechArmor));
				//^ This calculates the received damage for us. We can then use the variable of ``damage`` later on to refer to the output damage after Defense and Endurance apply.
				player.immune = true;
				player.immuneTime = 20;
				playSound = false;
				SoundEngine.PlaySound(SoundID.NPCHit4, Player.position);
				//Energy Shield
				if (mechEnergyShield)
				{
					if (damage >= player.statMana)
					{
						if (EnergyShieldLoopSound is SlotId slot)
						{
							if (SoundEngine.TryGetActiveSound(slot, out var sound))
							{
								sound.Stop();
								EnergyShieldLoopSound = null;
							}
						}
						mechEnergyShield = false;
						SoundEngine.PlaySound(Sounds.Mech.EnergyShieldOff, player.position);
					}
					else
					{
						player.statMana -= damage;
					}
				}
				//Without Energy Shield
				else
				{
					if (damage >= player.statLife)
					{
						player.statLife = player.statLifeMax;
						mechDestroyed = true;
						player.mount.Dismount(player);
					}
					else
					{
						player.statLife -= damage;
					}
				}
				return false;
			}
            return true;
        }
		
        public override bool CanUseItem(Item item)
        {
            Player player = Main.LocalPlayer;
            if (player.mount.Type == ModContent.MountType<Mech1>() && weaponSelect != 0)
            {
                return false;
            }
            return true;
		}
		
		//WIP fix. This will prevent Mechs from despawning when Players are mounted on them at the time of the World Exit.
		/*public override void OnWorldUnload()
		{
			Player player = Main.LocalPlayer;
            if (player.mount.Type == ModContent.MountType<Mech1>())
			{
				player.mount.Dismount(player);
			}
		}*/
    }
}