using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public string State { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public void CreateProduct()
        {
            // Lógica para crear el producto
        }

        public void ModifyProduct()
        {
            // Lógica para modificar el producto
        }

        public void DeleteProduct()
        {
            // Lógica para eliminar el producto
        }
    }
}
