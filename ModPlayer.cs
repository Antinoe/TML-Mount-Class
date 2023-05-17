using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using ReLogic.Utilities;
using MountClass.Mounts;

namespace MountClass
{
    public class MountClassPlayer : ModPlayer
    {
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
		public bool machineGunGatling;
		public int heavyCannonTimer;
		public bool weaponSelected;
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
			if (mechWelcomeCooldown > 0)
			{
				mechWelcomeCooldown--;
			}
			
			//Prevent Drowning
			if (player.mount.Type == ModContent.MountType<Mech1>())
			{
				/*if (Player.breath < Player.breathMax)
				{
					Player.breath = Player.breathMax;
				}*/
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

        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            Player player = Main.LocalPlayer;
			var damage = modifiers.FinalDamage.Flat;
            if (player.mount.Type == ModContent.MountType<Mech1>())
			{
				modifiers.KnockbackImmunityEffectiveness *= 100f;
				//damage = (int)((damage - player.statDefense) * (1f - player.endurance));
				damage = (int)((damage) * (1f - mechArmor));
				//^ This calculates the received damage for us. We can then use the variable of ``damage`` later on to refer to the output damage after Defense and Endurance apply.
				player.immune = true;
				if (damage <= 1)
				{
					player.immuneTime = 20;
				}
				else
				{
					player.immuneTime = 40;
				}
				modifiers.DisableSound();
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
						player.statMana -= (int)damage;
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
						player.statLife -= (int)damage;
					}
				}
			}
            base.ModifyHurt(ref modifiers);
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