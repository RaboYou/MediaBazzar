namespace MediaBazaar
{
	 public class ProductEvolution
	{
		public int Quantity { get; set; }

		public string ProductName { get; set; }
		public string Year { get; set; }

		public ProductEvolution(string productName, int quantity, string year)
		{
			this.Quantity = quantity;
			this.Year = year;
			this.ProductName = productName;
		}
	}
}
