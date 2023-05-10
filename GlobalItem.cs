using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace MountClass
{
    public class MountClassGlobalItem : GlobalItem
    {
		public override bool CanPickup(Item item, Player player)
		{
			return true;
		}

		public override bool OnPickup(Item item, Player player)
		{
			return true;
		}
		
		public override void UpdateAccessory(Item item, Player player, bool hideVisual)
		{
			MountClassPlayer mcp = player.GetModPlayer<MountClassPlayer>();
			if (MountClassConfig.Instance.mechUpgradedArmorWhitelist.Contains(new ItemDefinition(item.type)))
			{
				mcp.mechUpgradeArmor = true;
			}
			if (MountClassConfig.Instance.mechUpgradedThornsWhitelist.Contains(new ItemDefinition(item.type)))
			{
				mcp.mechUpgradeThorns = true;
			}
			if (MountClassConfig.Instance.mechUpgradedRocketWhitelist.Contains(new ItemDefinition(item.type)))
			{
				mcp.mechUpgradeRocket = true;
			}
			if (MountClassConfig.Instance.mechUpgradedGrenadeWhitelist.Contains(new ItemDefinition(item.type)))
			{
				mcp.mechUpgradeGrenade = true;
			}
			if (MountClassConfig.Instance.mechUpgradedHeavyCannonWhitelist.Contains(new ItemDefinition(item.type)))
			{
				mcp.mechUpgradeHeavyCannon = true;
			}
			if (MountClassConfig.Instance.mechUpgradedMachineGunWhitelist.Contains(new ItemDefinition(item.type)))
			{
				mcp.mechUpgradeGun = true;
			}
		}

		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if (MountClassConfig.Instance.mechUpgradedArmorWhitelist.Contains(new ItemDefinition(item.type)))
			{
				var line = new TooltipLine(Mod, "MountClass:Armor", "Upgrades the Mech's Armor.");
				tooltips.Add(line);
			}
			if (MountClassConfig.Instance.mechUpgradedThornsWhitelist.Contains(new ItemDefinition(item.type)))
			{
				var line = new TooltipLine(Mod, "MountClass:Thorns", "Upgrades the Mech's Thorns.");
				tooltips.Add(line);
			}
			if (MountClassConfig.Instance.mechUpgradedRocketWhitelist.Contains(new ItemDefinition(item.type)))
			{
				var line = new TooltipLine(Mod, "MountClass:Rocket", "Upgrades the Mech's Rockets.");
				tooltips.Add(line);
			}
			if (MountClassConfig.Instance.mechUpgradedGrenadeWhitelist.Contains(new ItemDefinition(item.type)))
			{
				var line = new TooltipLine(Mod, "MountClass:Grenade", "Upgrades the Mech's Grenades.");
				tooltips.Add(line);
			}
			if (MountClassConfig.Instance.mechUpgradedHeavyCannonWhitelist.Contains(new ItemDefinition(item.type)))
			{
				var line = new TooltipLine(Mod, "MountClass:HeavyCannon", "Upgrades the Mech's Heavy Cannon.");
				tooltips.Add(line);
			}
			if (MountClassConfig.Instance.mechUpgradedMachineGunWhitelist.Contains(new ItemDefinition(item.type)))
			{
				var line = new TooltipLine(Mod, "MountClass:MachineGun", "Upgrades the Mech's Machine Gun.");
				tooltips.Add(line);
			}
		}
    }
}