using NGConnection.Attributes;

namespace NGEntity
{
	[Primarykey("IdAddress")]
	public class Address
	{
		public int? IdAddress { get; set; }
		public string Street { get; set; }

        public Address() { }
	}
}
