using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace MountClass
{
    [Label("Server Config")]
    public class MountClassConfig : ModConfig
    {
        //This is here for the Config to work at all.
        public override ConfigScope Mode => ConfigScope.ServerSide;
		
        public static MountClassConfig Instance;
		
	[Header("Mech Defense")]
		
        [Label("[i:ObsidianShield] Endurance")]
        [Tooltip("The percentage of damage the Mech will reduce.\n[Default: 0.75]")]
        [Slider]
        [DefaultValue(0.75f)]
        [Range(0f, 1f)]
        [Increment(.05f)]
        public float mechEndurance {get; set;}
		
        [Label("[i:ObsidianShield] Endurance Upgrade")]
        [Tooltip("Additional percentage of damage the Upgrade Module will reduce.\n[Default: 0.15]")]
        [Slider]
        [DefaultValue(0.15f)]
        [Range(0f, 1f)]
        [Increment(.05f)]
        public float mechUpgradedEndurance {get; set;}
		
		[Label("[i:ObsidianShield] Endurance Whitelist")]
		[Tooltip("Accessories in this list will grant Upgraded Endurance for the Mech when equipped.\n(WORK IN PROGRESS)")]
		public List<ItemDefinition> mechUpgradedEnduranceWhitelist = new List<ItemDefinition>();
		
        [Label("[i:Stinger] Thorns")]
        [Tooltip("The percentage of damage the Mech will reflect.\n[Default: 0.25]")]
        [Slider]
        [DefaultValue(0.25f)]
        [Range(0f, 1f)]
        [Increment(.05f)]
        public float mechThorns {get; set;}
		
        [Label("[i:Stinger] Thorns Upgrade")]
        [Tooltip("Additional percentage of damage the Upgrade Module will reflect.\n[Default: 0.25]")]
        [Slider]
        [DefaultValue(0.25f)]
        [Range(0f, 1f)]
        [Increment(.05f)]
        public float mechUpgradedThorns {get; set;}
		
        [Label("[i:CobaltShield] Energy Shield Timer")]
        [Tooltip("[Default: 5]")]
        [Slider]
        [DefaultValue(5)]
        [Range(5, 600)]
        [Increment(5)]
        public int mechEnergyShieldTimer {get; set;}
		
		[Label("[i:ObsidianShield] Thorns Whitelist")]
		[Tooltip("Accessories in this list will grant Upgraded Thorns for the Mech when equipped.\n(WORK IN PROGRESS)")]
		public List<ItemDefinition> mechUpgradedThornsWhitelist = new List<ItemDefinition>();
		
	[Header("Mech Arsenal")]
		
        [Label("[i:RocketIII] Rocket Damage")]
        [Tooltip("[Default: 40]")]
        [Slider]
        [DefaultValue(40)]
        [Range(0, 200)]
        [Increment(5)]
        public int weaponRocketDamage {get; set;}
		
        [Label("[i:ClusterRocketI] Upgraded Rocket Damage")]
        [Tooltip("[Default: 65]")]
        [Slider]
        [DefaultValue(65)]
        [Range(0, 200)]
        [Increment(5)]
        public int weaponUpgradedRocketDamage {get; set;}
		
		[Label("[i:ClusterRocketI] Rocket Whitelist")]
		[Tooltip("Accessories in this list will grant Upgraded Rockets for the Mech when equipped.\n(WORK IN PROGRESS)")]
		public List<ItemDefinition> mechUpgradedRocketWhitelist = new List<ItemDefinition>();
		
        [Label("[i:Grenade] Grenade Damage")]
        [Tooltip("[Default: 75]")]
        [Slider]
        [DefaultValue(75)]
        [Range(0, 200)]
        [Increment(5)]
        public int weaponGrenadeDamage {get; set;}
		
		[Label("[i:Grenade] Grenade Whitelist")]
		[Tooltip("Accessories in this list will grant Upgraded Grenades for the Mech when equipped.\n(WORK IN PROGRESS)")]
		public List<ItemDefinition> mechUpgradedGrenadeWhitelist = new List<ItemDefinition>();
		
        [Label("[i:HighVelocityBullet] Heavy Cannon Damage")]
        [Tooltip("[Default: 20]")]
        [Slider]
        [DefaultValue(20)]
        [Range(0, 200)]
        [Increment(5)]
        public int weaponHeavyCannonDamage {get; set;}
		
        [Label("[i:HighVelocityBullet] Upgraded Heavy Cannon Damage")]
        [Tooltip("[Default: 45]")]
        [Slider]
        [DefaultValue(45)]
        [Range(0, 200)]
        [Increment(5)]
        public int weaponUpgradedHeavyCannonDamage {get; set;}
		
		[Label("[i:HighVelocityBullet] Heavy Cannon Whitelist")]
		[Tooltip("Accessories in this list will grant an Upgraded Heavy Cannon for the Mech when equipped.\n(WORK IN PROGRESS)")]
		public List<ItemDefinition> mechUpgradedHeavyCannonWhitelist = new List<ItemDefinition>();
		
        [Label("[i:SilverBullet] Machine Gun Damage")]
        [Tooltip("[Default: 10]")]
        [Slider]
        [DefaultValue(10)]
        [Range(0, 200)]
        [Increment(5)]
        public int weaponMachineGunDamage {get; set;}
		
        [Label("[i:SilverBullet] Upgraded Machine Gun Damage")]
        [Tooltip("[Default: 20]")]
        [Slider]
        [DefaultValue(20)]
        [Range(0, 200)]
        [Increment(5)]
        public int weaponUpgradedMachineGunDamage {get; set;}
		
		[Label("[i:SilverBullet] Machine Gun Whitelist")]
		[Tooltip("Accessories in this list will grant Upgraded Machine Gun for the Mech when equipped.\n(WORK IN PROGRESS)")]
		public List<ItemDefinition> mechUpgradedMachineGunWhitelist = new List<ItemDefinition>();
		
    }
}