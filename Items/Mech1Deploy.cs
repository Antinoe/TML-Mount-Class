using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using MountClass.NPCs;


namespace MountClass.Items
{
	public class Mech1Deploy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mech Deployment");
			Tooltip.SetDefault("Deploys a Mech at your position");
			//SacrificeTotal = 1;
        }

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = Item.buyPrice(0, 7, 0, 0);
            Item.rare = ItemRarityID.White;
            Item.noMelee = true;
			Item.consumable = true;
        }
        public override Vector2? HoldoutOffset()
        {
            return Vector2.Zero;
        }
		public override bool? UseItem(Player player)
		{
			NPC.NewNPC(NPC.GetSource_None(), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<Mech1NPC>());
			//NPC.NewNPC(NPC.GetSource_None(), (int)player.Center.X, (int)player.Center.Y, NPCID.BlueSlime);
			return true;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe(1)
			.AddRecipeGroup(RecipeGroupID.IronBar, 30)
			.AddIngredient(ItemID.Grenade, 5)
			.AddTile(TileID.Anvils)
			.Register();
		}
    }
}