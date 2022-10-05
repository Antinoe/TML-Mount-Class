using System; //For Math functions to work.
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
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
		public bool upgradeGun;
		public bool upgradeGrenade;
		public bool upgradeRocket;
		public bool upgradeHeavyCannon;
		public bool upgradeArmor;
		public bool upgradeThorns;
		public bool mechDestroyed;
		public bool mechEnergyShield = false;
		public int mechEnergyShieldTimer;
		public int mechEnergyShieldLoopTimer;

        public override void ResetEffects()
        {
            screenShakeTimerWeak = 0;
            upgradeGun = false;
            upgradeGrenade = false;
            upgradeRocket = false;
            upgradeHeavyCannon = false;
            upgradeArmor = false;
            upgradeThorns = false;
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
			if (mechEnergyShieldLoopTimer > 0)
			{
				mechEnergyShieldLoopTimer--;
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
							if (mechEnergyShieldLoopTimer == 1)
							{
								//SoundEngine.PlaySound(Sounds.Mech.EnergyShieldLoop, player.position);
								//Disabling Sound Loop for now until I figure out how to manually stop sounds.
							}
						}
						else
						{
							mechEnergyShield = false;
							/*if (SoundEngine.TryGetActiveSound(slot, out var sound));
							{
								sound.Stop();
							}*/
							//Disabling Sound Loop for now until I figure out how to manually stop sounds.
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
					mechEnergyShield = true;
					SoundEngine.PlaySound(Sounds.Mech.EnergyShieldOn, player.position);
					//SoundEngine.PlaySound(Sounds.Mech.EnergyShieldLoop, player.position);
					//Disabling Sound Loop for now until I figure out how to manually stop sounds.
				}
				else if (mechEnergyShield)
				{
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
				damage = (int)((damage - player.statDefense) * (1f - player.endurance));
				//^ This calculates the received damage for us. We can then use the variable of ``damage`` later on to refer to the output damage after Defense and Endurance apply.
				player.immune = true;
				player.immuneTime = 20;
				playSound = false;
				SoundEngine.PlaySound(SoundID.NPCHit4, Player.position);
				if (mechEnergyShield) //Energy Shield
				{
					if (damage >= player.statMana)
					{
						mechEnergyShield = false;
						SoundEngine.PlaySound(Sounds.Mech.EnergyShieldOff, player.position);
					}
					else
					{
						player.statMana -= damage;
					}
				}
				else //Without Energy Shield
				{
					if (damage >= player.statLife)
					{
						//player.statLife = player.statLifeMax;
						player.dead = true;
						//mechDestroyed = true;
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
            if (player.mount.Type == ModContent.MountType<Mech1>())
            {
                return false;
            }
            return true;
		}
    }
}