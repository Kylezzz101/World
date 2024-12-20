using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x26CE, 0x26CF )]
	public class ShadowBlade : Longsword
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public ShadowBlade()
		{
			Name = "Blade of the Shadows";
			Attributes.AttackChance = 20;
            Attributes.BonusDex = 2;
		    Attributes.CastSpeed = 1;
            Attributes.ReflectPhysical = 5;
            Attributes.RegenHits = 1;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 20;
			Attributes.WeaponDamage = 45;
			Attributes.WeaponSpeed = 30;
			WeaponAttributes.HitFireball = 10;
            WeaponAttributes.HitLeechMana = 10;
            WeaponAttributes.HitLeechStam = 10;
			WeaponAttributes.SelfRepair = 1;
			Hue = 1899;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public ShadowBlade( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_ShadowBlade(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}
