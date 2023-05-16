using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzar
{
    public class Stock
    {
        private List<Product> products = new List<Product>();
        private List<Restock> restockRequests = new List<Restock>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(int index)
        {
            products.RemoveAt(index);
        }

        public Product[] GetProducts()
        {
            return this.products.ToArray();
        }

        public void RequestRestock(Product product)
        {
            Restock newRestock = new Restock(product.GetName());
            restockRequests.Add(newRestock);
        }

        public Restock[] GetRestock()
        {
            return this.restockRequests.ToArray();
        }
    }
}
