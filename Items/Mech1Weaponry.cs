using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using MountClass.NPCs;


namespace MountClass.Items
{
	public class Mech1Weaponry : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mech Weaponry");
			Tooltip.SetDefault("This is a dummy item.\nYou shouldn't be able to view this Tooltip.");
			//SacrificeTotal = 1;
        }
    }
}