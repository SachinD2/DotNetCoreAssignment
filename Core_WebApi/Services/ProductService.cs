using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_WebApi.Services
{
	public class ProductService : IService<Product, int>
	{
		private readonly AllDbContext ctx;

		/// <summary>
		/// Inject the CitusTrainingContext as ctor injection in the Service class
		/// </summary>
		public ProductService(AllDbContext c)
		{
			ctx = c;
		}


		public async Task<Product> CreateAsync(Product entity)
		{
			var res = await ctx.Products.AddAsync(entity);
			await ctx.SaveChangesAsync();
			return res.Entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var res = await ctx.Products.FindAsync(id);
			if (res == null) return false;
			return true;
		}

		public async Task<IEnumerable<Product>> GetAsync()
		{
			return await ctx.Products.ToListAsync();
		}

		public async Task<Product> GetAsync(int id)
		{
			var res = await ctx.Products.FindAsync(id);
			return res;
		}

		public async Task<Product> UpdateAsync(int id, Product entity)
		{
			var res = await ctx.Products.FindAsync(id);
			if (res == null) return res;

			ctx.Entry<Product>(entity).State = EntityState.Modified;
			await ctx.SaveChangesAsync();
			return entity;
		}
	}
}
