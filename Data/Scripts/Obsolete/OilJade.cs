using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Misc;

namespace Server.Items
{
	public class OilJade : Item
	{
		[Constructable]
		public OilJade() : this( 1 )
		{
		}

		[Constructable]
		public OilJade( int amount ) : base( 0x1FDD )
		{
			Weight = 0.01;
			Stackable = true;
			Amount = amount;
			Hue = 2963;
			Name = "oil of metal enhancement ( jade )";
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1070722, "Rub On Metal To Change It" );
		}

		public OilJade( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new TransmutationPotion();
			((TransmutationPotion)item).Resource = CraftResource.JadeBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}