using Terraria.ModLoader;

namespace MountClass
{
    class MountClass : Mod
    {
		public static ModKeybind SelectDisarmed;
		public static ModKeybind SelectGun;
		public static ModKeybind SelectHeavyCannon;
		public static ModKeybind SelectGrenade;
		public static ModKeybind SelectRocket;
		public static ModKeybind EnergyShield;
		
        public override void Load()
        {
            EnergyShield = KeybindLoader.RegisterKeybind(this, "Toggle Energy Shield", "LeftAlt");
            SelectDisarmed = KeybindLoader.RegisterKeybind(this, "Select Disarmed", "D0");
            SelectGun = KeybindLoader.RegisterKeybind(this, "Select Machine Gun", "D1");
            SelectHeavyCannon = KeybindLoader.RegisterKeybind(this, "Select Heavy Cannon", "D2");
            SelectGrenade = KeybindLoader.RegisterKeybind(this, "Select Grenade Launcher", "D3");
            SelectRocket = KeybindLoader.RegisterKeybind(this, "Select Rocket Launcher", "D4");
		}
		
        public override void Unload()
        {
            SelectDisarmed = null;
            SelectGun = null;
            SelectHeavyCannon = null;
            SelectGrenade = null;
            SelectRocket = null;
            EnergyShield = null;
		}

        internal class Items
        {
        }
    }
}
