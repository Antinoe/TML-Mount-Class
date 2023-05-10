using Terraria.Audio;

namespace MountClass
{
	public static partial class Sounds
	{
		public static class Mech
		{
			public static readonly SoundStyle MechEnter = new($"{nameof(MountClass)}/Assets/Sounds/MechEnter")
			{
				Volume = 0.75f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle MechStep = new($"{nameof(MountClass)}/Assets/Sounds/MechStep", 2)
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle MechJump = new($"{nameof(MountClass)}/Assets/Sounds/MechJump")
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle MechWelcome = new($"{nameof(MountClass)}/Assets/Sounds/MechWelcome")
			{
				Volume = 0.5f,
				//PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle GunFire = new($"{nameof(MountClass)}/Assets/Sounds/GunFire", 9)
			{
				Volume = 0.50f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle GunUpgradedFire = new($"{nameof(MountClass)}/Assets/Sounds/GunUpgradedFire", 6)
			{
				Volume = 0.50f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle GrenadeFire = new($"{nameof(MountClass)}/Assets/Sounds/GrenadeFire", 5)
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle GrenadeReload1 = new($"{nameof(MountClass)}/Assets/Sounds/GrenadeReload1")
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle RocketFire = new($"{nameof(MountClass)}/Assets/Sounds/RocketFire", 4)
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle RocketReload1 = new($"{nameof(MountClass)}/Assets/Sounds/RocketReload1")
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle RocketReload2 = new($"{nameof(MountClass)}/Assets/Sounds/RocketReload2")
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle Overheat = new($"{nameof(MountClass)}/Assets/Sounds/Overheat")
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle HeavyCannonFire = new($"{nameof(MountClass)}/Assets/Sounds/HeavyCannonFire", 5)
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle HeavyCannonReload1 = new($"{nameof(MountClass)}/Assets/Sounds/HeavyCannonReload1")
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle HeavyCannonReload2 = new($"{nameof(MountClass)}/Assets/Sounds/HeavyCannonReload2")
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle ChainLoopHeavy = new($"{nameof(MountClass)}/Assets/Sounds/ChainLoopHeavy")
			{
				Volume = 0.5f,
				//PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle ChainLoopLight = new($"{nameof(MountClass)}/Assets/Sounds/ChainLoopLight")
			{
				Volume = 0.5f,
				//PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle SwitchGun = new($"{nameof(MountClass)}/Assets/Sounds/SwitchGun")
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle SwitchHeavyCannon = new($"{nameof(MountClass)}/Assets/Sounds/SwitchHeavyCannon")
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle SwitchGrenade = new($"{nameof(MountClass)}/Assets/Sounds/SwitchGrenade")
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle SwitchRocket = new($"{nameof(MountClass)}/Assets/Sounds/SwitchRocket")
			{
				Volume = 0.5f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle EnergyShieldOn = new($"{nameof(MountClass)}/Assets/Sounds/EnergyShieldOn")
			{
				Volume = 0.5f,
				//PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle EnergyShieldLoop = new($"{nameof(MountClass)}/Assets/Sounds/EnergyShieldLoop")
			{
				Volume = 0.5f,
				//PitchVariance = 0.5f,
				IsLooped = true,
				MaxInstances = 12
			};
			public static readonly SoundStyle EnergyShieldOff = new($"{nameof(MountClass)}/Assets/Sounds/EnergyShieldOff")
			{
				Volume = 0.5f,
				//PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle CasingMachineGun = new($"{nameof(MountClass)}/Assets/Sounds/CasingMachineGun", 2)
			{
				Volume = 0.25f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle CasingHeavyCannon = new($"{nameof(MountClass)}/Assets/Sounds/CasingHeavyCannon", 3)
			{
				Volume = 0.25f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
			public static readonly SoundStyle EjectHeavyCannon = new($"{nameof(MountClass)}/Assets/Sounds/EjectHeavyCannon")
			{
				Volume = 0.75f,
				PitchVariance = 0.5f,
				MaxInstances = 12
			};
		}
	}
}
