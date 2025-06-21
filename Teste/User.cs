using System.Collections.Generic;
using NGConnection.Attributes;
using NGConnection.Enums;

namespace NGEntity
{
	[TableProperties("Usr001")]
	public partial class User
	{
        string lastNane;

        public int? IdUser 
		{ 
			get; 
			set; 
		}
        public string Email { get; set; }
		public string Name { get; set; }
		public bool Flag { get; set; }
        public int? FkAddress { get; set; }

		public User() { }
		public User(int? idUser) { IdUser = idUser; }
	}
}
