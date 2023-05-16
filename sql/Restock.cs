using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar
{
    public class Restock
    {
        public int Id { get; }
        public DateTime orderDate { get; set; }
        public int PersonId { get; set; }
        public int orderrequestId { get; set; }
        public string productName { get; set; }
        public double buyPrice { get; set; }
        public double sellPrice { get; set; }
        public Category category { get; set; }
        public bool IsOpen { get; set; }
        public int quantity { get; set; }
        public Person person { get; set; }
        public Product product { get; set; }

        public Restock(int orderrequestId, string productName, double buyPrice, double sellPrice, Category category, bool IsOpen, int quantity)
        {
            this.orderDate = DateTime.Now;
            this.orderrequestId = orderrequestId;
            this.productName = productName;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
            this.category = category;
            this.IsOpen = IsOpen;
            this.quantity = quantity;
        }

        public Restock(int Id, DateTime orderDate, int personid, int orderrequestId, string productName, double buyPrice, double sellPrice, Category category, bool IsOpen, int quantity)
        {
            this.Id = Id;
            this.orderDate = orderDate;
            this.PersonId = personid;
            this.orderrequestId = orderrequestId;
            this.productName = productName;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
            this.category = category;
            this.IsOpen = IsOpen;
            this.quantity = quantity;
        }

        public Restock(int quantity, Person person, Product product)
        {
            this.quantity = quantity;
            this.person = person;
            this.product = product;
        }

    }
}
