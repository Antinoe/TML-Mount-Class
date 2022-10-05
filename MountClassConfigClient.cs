using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace MountClass
{
    [Label("Client Config")]
    public class MountClassConfigClient : ModConfig
    {
        //This is here for the Config to work at all.
        public override ConfigScope Mode => ConfigScope.ClientSide;
		
        public static MountClassConfigClient Instance;
		
	[Header("Audio")]
		
        [Label("[i:Megaphone] Vanilla Sounds")]
        [Tooltip("If false, this mod's custom sounds will be played instead of Vanilla variations.\n[Default: Off]")]
        [DefaultValue(false)]
        public bool enableVanillaSounds {get; set;}
    }
}