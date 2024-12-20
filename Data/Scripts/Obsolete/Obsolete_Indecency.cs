using System;
using Server;

namespace Server.Items
{
    public class Indecency : StuddedChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        public override int BasePhysicalResistance{ get{ return 3; } }
        public override int BaseColdResistance{ get{ return 12; } }
        public override int BaseFireResistance{ get{ return 12; } }
        public override int BaseEnergyResistance{ get{ return 13; } }
        public override int BasePoisonResistance{ get{ return 18; } }

        [Constructable]
        public Indecency()
        {
            Name = "Indecency";
            Hue = 2075;
            Attributes.BonusStr = 5;
            Attributes.BonusInt = 5;
            Attributes.BonusDex = 5;
            Attributes.AttackChance = 10;
            Attributes.DefendChance = 10;
            Attributes.Luck = 205;
            Attributes.SpellDamage = 5;
            ArmorAttributes.MageArmor = 1;
            ArmorAttributes.SelfRepair = 4;
            Attributes.LowerManaCost = 8;
            Attributes.LowerRegCost = 20;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

        public Indecency(Serial serial) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int) 0 );
        }

        private void Cleanup( object state ){ Item item = new Artifact_Indecency(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
            int version = reader.ReadInt();
        }
    } // End Class
} // End Namespace
