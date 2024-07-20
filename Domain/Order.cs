using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public DateTime DateOrder { get; set; }
        public string State { get; set; }
        public float Total { get; set; }

        public void ChangeState(string newState)
        {
            State = newState;
        }

        public void PayOrder()
        {
            // Lógica para pagar la orden
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            Products.Remove(product);
        }
    }
}
