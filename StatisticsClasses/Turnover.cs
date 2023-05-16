namespace MediaBazaar
{
	public class Turnover
	{
		public string ProductName { get; set; }
		public int TurnoverAmount { get; set; }

		public System.DateTime Date { get; set; }

		public Turnover(string ProductName, int Turnover, System.DateTime Date)
		{
			this.ProductName = ProductName;
			this.TurnoverAmount = Turnover;
			this.Date = Date;
		}
	}
}
