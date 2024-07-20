using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IProductService
    {
        void CreateProduct(ProductDto productDto);
        void UpdateProduct(ProductDto productDto);
        void DeleteProduct(int productId);
        ProductDto GetProductById(int productId);
        IEnumerable<ProductDto> GetAllProducts();
    }
}
