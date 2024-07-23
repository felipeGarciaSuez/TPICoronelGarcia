using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<int> ProductIds { get; set; }
        public DateTime DateOrder { get; set; }
        public string State { get; set; }
        public float Total { get; set; }
    }
}