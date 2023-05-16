namespace MediaBazaar
{
	public class Manufacturer
	{
		public int ManId { get; }
		public string ManName { get; set; }
		public string ManAdress { get; set; }
		public ManCountry ManCountry { get; set; }

		public Manufacturer(string manName, string manAdress, ManCountry manCountry)
		{
			this.ManName = manName;
			this.ManAdress = manAdress;
			this.ManCountry = manCountry;
		}

		public Manufacturer(int manId, string manName, string manAdress, ManCountry manCountry)
		{
			this.ManId = manId;
			this.ManName = manName;
			this.ManAdress = manAdress;
			this.ManCountry = manCountry;
		}
	}
}
