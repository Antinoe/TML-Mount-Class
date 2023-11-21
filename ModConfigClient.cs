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
		
        /*[Label("[i:FairyBell] Welcome Sound")]
        [Tooltip("If false, the Mech will not play a Welcome sound upon entering it after a while.\n[Default: On]")]*/
        [DefaultValue(true)]
        public bool enableMechWelcome {get; set;}
		
        /*[Label("[i:FairyBell] Welcome Cooldown")]
        [Tooltip("[Default: 4000]")]*/
        [Slider]
        [DefaultValue(4000)]
        [Range(200, 8000)]
        [Increment(200)]
        public int mechWelcomeCooldown {get; set;}
		
    }
}