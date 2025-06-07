using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DB.DTO;

namespace E_Commerce.Core.IServices
{
	public  interface IProductService
	{
		Task<List<ProductDto>> GetAllAsync();
		Task AddAsync(ProductCreateDto newProduct);

	}
}
