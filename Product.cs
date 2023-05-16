namespace MediaBazaar
{
	public class Product
	{
		public int Id { get; }
		public string ManufacturerName { get; set; }
		public int ManufacturerId { get; set; }
		public string ProductName { get; set; }
		public double BuyPrice { get; set; }
		public double SellPrice { get; set; }
		public string Description { get; set; }
		public Category Category { get; set; }
		public ProductStatus ProductStatus { get; set; }
		public float Width { get; set; }
		public float Height { get; set; }
		public float Depth { get; set; }
		public float Weight { get; set; }

		public Product(int manufacturerId, string manufacturerName, string productName, double buyPrice, double sellPrice, string description, Category category, ProductStatus productStatus,
			float width, float height, float depth, float weight)
		{
			this.ManufacturerId = manufacturerId;
			this.ManufacturerName = manufacturerName;
			this.ProductName = productName;
			this.BuyPrice = buyPrice;
			this.SellPrice = sellPrice;
			this.Description = description;
			this.Category = category;
			this.ProductStatus = productStatus;
			this.Width = width;
			this.Height = height;
			this.Depth = depth;
			this.Weight = weight;
		}

		public Product(int id, int manufacturerId, string manufacturerName, string productName, double buyPrice, double sellPrice, string description, Category category, ProductStatus productStatus,
			float width, float height, float depth, float weight)
		{
			this.Id = id;
			this.ManufacturerId = manufacturerId;
			this.ManufacturerName = manufacturerName;
			this.ProductName = productName;
			this.BuyPrice = buyPrice;
			this.SellPrice = sellPrice;
			this.Description = description;
			this.Category = category;
			this.ProductStatus = productStatus;
			this.Width = width;
			this.Height = height;
			this.Depth = depth;
			this.Weight = weight;
		}
	}
}
