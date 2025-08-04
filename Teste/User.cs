using NGConnection.Attributes;

namespace NGEntity
{
	[TableProperties("Usr001")]
	public partial class User
	{
        string lastNane;
        [ColumnPrimarykey(true)]

        public int IdUser 
		{ 
			get; 
			set; 
		}
        public string Email { get; set; }
		public string Name { get; set; }
		public bool Flag { get; set; }
        public int? FkAddress { get; set; }
        public Address Address { get; set; }


        public User() { }
	}
}
