namespace MediaBazaar
{
	public class ProductPopularity
	{
		public string ProductName { get; set; }
		public int Quantity { get; set; }

		public System.DateTime Date { get; set; }

		public ProductPopularity(string productName, int quantity, System.DateTime date)
		{
			this.ProductName = productName;
			this.Quantity = quantity;
			this.Date = date;
		}
	}
}
