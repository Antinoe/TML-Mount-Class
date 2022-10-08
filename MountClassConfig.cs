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
		
	[Header("General")]
		
		[Label("[i:MountClass/Mech1Deploy] Enable Mech Deployment recipe")]
		[Tooltip("If false, Players cannot craft this.\n(REQUIRES MOD RELOAD.)\n[Default: On]")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool mechItemCraftable {get; set;}
		
	[Header("Mech Defense")]
		
        [Label("[i:ObsidianShield] Armor")]
        [Tooltip("The percentage of damage the Mech will reduce.\n[Default: 0.85]")]
        [Slider]
        [DefaultValue(0.85f)]
        [Range(0f, 1f)]
        [Increment(.05f)]
        public float mechArmor {get; set;}
		
        [Label("[i:ObsidianShield] Armor Upgrade")]
        [Tooltip("Additional percentage of damage the Upgrade Module will reduce.\n[Default: 0.10]")]
        [Slider]
        [DefaultValue(0.10f)]
        [Range(0f, 1f)]
        [Increment(.05f)]
        public float mechUpgradedArmor {get; set;}
		
		[Label("[i:ObsidianShield] Armor Whitelist")]
		[Tooltip("Accessories in this list will grant Upgraded Armor for the Mech when equipped.\n(WORK IN PROGRESS)")]
		public List<ItemDefinition> mechUpgradedArmorWhitelist = new List<ItemDefinition>();
		
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
        [Tooltip("[Default: 1]")]
        [Slider]
        [DefaultValue(1)]
        [Range(1, 20)]
        [Increment(1)]
        public int mechEnergyShieldTimer {get; set;}
		
		[Label("[i:ObsidianShield] Thorns Whitelist")]
		[Tooltip("Accessories in this list will grant Upgraded Thorns for the Mech when equipped.\n(WORK IN PROGRESS)")]
		public List<ItemDefinition> mechUpgradedThornsWhitelist = new List<ItemDefinition>();
		
	[Header("Mech Arsenal")]
		
        [Label("[i:RocketIII] Rocket Damage")]
        [Tooltip("[Default: 175]")]
        [Slider]
        [DefaultValue(175)]
        [Range(0, 300)]
        [Increment(5)]
        public int mechRocketDamage {get; set;}
		
        [Label("[i:ClusterRocketI] Upgraded Rocket Damage")]
        [Tooltip("[Default: 300]")]
        [Slider]
        [DefaultValue(300)]
        [Range(0, 300)]
        [Increment(5)]
        public int mechUpgradedRocketDamage {get; set;}
		
		[Label("[i:ClusterRocketI] Rocket Whitelist")]
		[Tooltip("Accessories in this list will grant Upgraded Rockets for the Mech when equipped.\n(WORK IN PROGRESS)")]
		public List<ItemDefinition> mechUpgradedRocketWhitelist = new List<ItemDefinition>();
		
        [Label("[i:Grenade] Grenade Damage")]
        [Tooltip("[Default: 200]")]
        [Slider]
        [DefaultValue(200)]
        [Range(0, 300)]
        [Increment(5)]
        public int mechGrenadeDamage {get; set;}
		
		[Label("[i:Grenade] Grenade Whitelist")]
		[Tooltip("Accessories in this list will grant Upgraded Grenades for the Mech when equipped.\n(WORK IN PROGRESS)")]
		public List<ItemDefinition> mechUpgradedGrenadeWhitelist = new List<ItemDefinition>();
		
        [Label("[i:HighVelocityBullet] Heavy Cannon Damage")]
        [Tooltip("[Default: 60]")]
        [Slider]
        [DefaultValue(60)]
        [Range(0, 300)]
        [Increment(5)]
        public int mechHeavyCannonDamage {get; set;}
		
        [Label("[i:HighVelocityBullet] Upgraded Heavy Cannon Damage")]
        [Tooltip("[Default: 90]")]
        [Slider]
        [DefaultValue(90)]
        [Range(0, 300)]
        [Increment(5)]
        public int mechUpgradedHeavyCannonDamage {get; set;}
		
		[Label("[i:HighVelocityBullet] Heavy Cannon Whitelist")]
		[Tooltip("Accessories in this list will grant an Upgraded Heavy Cannon for the Mech when equipped.\n(WORK IN PROGRESS)")]
		public List<ItemDefinition> mechUpgradedHeavyCannonWhitelist = new List<ItemDefinition>();
		
        [Label("[i:SilverBullet] Machine Gun Damage")]
        [Tooltip("[Default: 15]")]
        [Slider]
        [DefaultValue(15)]
        [Range(0, 300)]
        [Increment(5)]
        public int mechMachineGunDamage {get; set;}
		
        [Label("[i:SilverBullet] Upgraded Machine Gun Damage")]
        [Tooltip("[Default: 30]")]
        [Slider]
        [DefaultValue(30)]
        [Range(0, 300)]
        [Increment(5)]
        public int mechUpgradedMachineGunDamage {get; set;}
		
		[Label("[i:SilverBullet] Machine Gun Whitelist")]
		[Tooltip("Accessories in this list will grant Upgraded Machine Gun for the Mech when equipped.\n(WORK IN PROGRESS)")]
		public List<ItemDefinition> mechUpgradedMachineGunWhitelist = new List<ItemDefinition>();
    }
}