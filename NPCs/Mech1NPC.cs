using Terraria.ID;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Microsoft.Xna.Framework;
using System;
using Terraria.GameContent.ItemDropRules;
using System.Collections.Generic;
using Terraria.Localization;
using Terraria.GameContent.Personalities;
using Terraria.GameContent.Bestiary;
using MountClass.Mounts;
using MountClass.Projectiles;

namespace MountClass.NPCs
{
    public class Mech1NPC : ModNPC
    {
		private bool landing;
        public override string Texture
		{
			get
			{
				return "MountClass/NPCs/Mech1NPC";
			}
		}
        public override void SetDefaults()
        {
            NPC.friendly = true;
            NPC.width = 50;
            NPC.height = 64;
            NPC.aiStyle = 0;
            NPC.defense = 20;
            NPC.lifeMax = 500;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.Item53;
            NPC.knockBackResist = 0.75f;
			NPC.knockBackResist = 0f;
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 1;
        }
		
		public override bool CanChat()
		{
			return true;
		}
		
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = ("Mount");
            button2 = ("Test");
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
			Player player = Main.LocalPlayer;
            if (firstButton)
            {
				player.Center = NPC.Center;
				player.mount.SetMount(ModContent.MountType<Mech1>(), player);
				//WorldGen.KillTile(i, j);
				NPC.active = false;
            }
        }

        public override string GetChat()
		{
			return "Test?";
        }
		
		//This is here so the Mech doesn't despawn on World Exit.
		public override bool NeedSaving()
		{
			return true;
		}
		public override void AI()
		{
			Player player = Main.LocalPlayer;
			//Landing
			if (NPC.velocity.Y == 0)
			{
				if (!landing)
				{
					landing = true;
					Projectile.NewProjectile(Projectile.GetSource_None(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileModerate>(), 0, 0, player.whoAmI);
					if (MountClassConfigClient.Instance.enableVanillaSounds)
					{
					}
					else
					{
						SoundEngine.PlaySound(Sounds.Mech.MechStep, NPC.position);
						SoundEngine.PlaySound(Sounds.Mech.MechStep, NPC.position);
					}
				}
			}
			else
			{
				landing = false;
			}
		}
    }
}