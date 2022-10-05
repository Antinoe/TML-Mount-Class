using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using MountClass;
using MountClass.NPCs;
using MountClass.Projectiles; //This is here so that Screenshake works.

namespace MountClass.Mounts
{
	public partial class Mech1 : ModMount
	{
		protected int rocketTimer;
		protected int grenadeTimer;
		protected int grenadeAmmo;
		protected int weapponDelay;
		protected int gunTimer;
		protected int heavyCannonTimer;
		protected int weaponSelect;
		protected int selectTimer;
		protected int mechUsageDelay;
		protected bool stepping;
		protected bool jumping;
		protected bool falling;
		protected bool landing;
		protected bool inAir;
		
		public override void SetStaticDefaults()
		{
            //MountData.buff = ModContent.BuffType<Mech1Mount>();
            MountData.heightBoost = 20;
			MountData.fallDamage = 0.0f;
			MountData.runSpeed = 1.2f;
			MountData.dashSpeed = 1.2f;
			MountData.flightTimeMax = 0;
			MountData.fatigueMax = 0;
			MountData.jumpSpeed = 3f;
			MountData.jumpHeight = 12;
			MountData.acceleration = 0.20f;
			MountData.blockExtraJumps = true;
			MountData.totalFrames = 4;
			MountData.constantJump = false;
			int[] array = new int[MountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 20;
			}
			MountData.playerYOffsets = array;
			MountData.xOffset = 15;
			MountData.bodyFrame = 3;
			MountData.yOffset = 7;
			MountData.playerHeadOffset = 22;
			MountData.standingFrameCount = 1;
			MountData.standingFrameDelay = 12;
			MountData.standingFrameStart = 0;
			MountData.runningFrameCount = 4;
			MountData.runningFrameDelay = 25;
			MountData.runningFrameStart = 0;
			MountData.flyingFrameCount = 0;
			MountData.flyingFrameDelay = 0;
			MountData.flyingFrameStart = 0;
			MountData.inAirFrameCount = 1;
			MountData.inAirFrameDelay = 12;
			MountData.inAirFrameStart = 1;
			MountData.idleFrameCount = 1;
			MountData.idleFrameDelay = 120;
			MountData.idleFrameStart = 0;
			MountData.idleFrameLoop = false;
			MountData.swimFrameCount = MountData.inAirFrameCount;
			MountData.swimFrameDelay = MountData.inAirFrameDelay;
			MountData.swimFrameStart = MountData.inAirFrameStart;
			if (Main.netMode != NetmodeID.Server)
			{
				MountData.textureWidth = MountData.backTexture.Width() + 20;
				MountData.textureHeight = MountData.backTexture.Height();
			}
		}

		public override void SetMount(Player player, ref bool skipDust)
		{
			skipDust = true;
			mechUsageDelay = 20;
			if (MountClassConfigClient.Instance.enableVanillaSounds)
			{
				SoundEngine.PlaySound(SoundID.Dig, player.position);
			}
			else
			{
				SoundEngine.PlaySound(Sounds.Mech.MechEnter, player.position);
			}
		}

		public override void Dismount(Player player, ref bool skipDust)
		{
			skipDust = true;
			if (MountClassConfigClient.Instance.enableVanillaSounds)
			{
				SoundEngine.PlaySound(SoundID.Dig, player.position);
			}
			else
			{
			}
			NPC.NewNPC(NPC.GetSource_None(), (int)player.position.X, (int)player.position.Y, ModContent.NPCType<Mech1NPC>());
			//Below is a test.
			//NPC.NewNPC(NPC.GetSource_None(), (int)player.position.X, (int)player.position.Y, NPCID.BlueSlime);
		}
    }
}