using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class DrawKnife : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefCarpentry.CraftSystem; } }

		[Constructable]
		public DrawKnife() : base( 0x10E4 )
		{
			Weight = 1.0;
		}

		[Constructable]
		public DrawKnife( int uses ) : base( uses, 0x10E4 )
		{
			Weight = 1.0;
		}

		public DrawKnife( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new Saw();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}