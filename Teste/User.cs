using System.Collections.Generic;
using NGConnection.Attributes;
using NGConnection.Enums;

namespace NGEntity
{
	[TableProperties("Usr001")]
	[Primarykey("IdUser")]
	public partial class User
	{
        string lastNane;

        [ColumnProperties(true, Key.Pk, true)]
        public int? IdUser 
		{ 
			get; 
			set; 
		}
		[ColumnProperties(50, true, Key.Unique)]
        public string Email { get; set; }
		[ColumnProperties(50, true)]
		public string Name { get; set; }
		[ColumnProperties(true)]
		public bool Flag { get; set; }
        [ColumnProperties(false, Key.Fk)]
        public int? FkAddress { get; set; }

		[Foreignkey("FkAddress")]
        public Address Address { get; set; }
        public IEnumerable<Address> Addresses { get; set; }

		public User() { }
		public User(int? idUser) { IdUser = idUser; }
	}
}
