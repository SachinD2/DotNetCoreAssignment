using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_WebApi.Services
{
	public class CategoryService : IService<Category, int>
	{

		private readonly AllDbContext ctx;

		/// <summary>
		/// Inject the CitusTrainingContext as ctor injection in the Service class
		/// </summary>
		public CategoryService(AllDbContext c)
		{
			ctx = c;
		}


		public async Task<Category> CreateAsync(Category entity)
		{
			var res = await ctx.Categories.AddAsync(entity);
			await ctx.SaveChangesAsync();
			return res.Entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var res = await ctx.Categories.FindAsync(id);
			if (res == null) return false;
			return true;
		}

		public async Task<IEnumerable<Category>> GetAsync()
		{
			return await ctx.Categories.ToListAsync();
		}

		public async Task<Category> GetAsync(int id)
		{
			var res = await ctx.Categories.FindAsync(id);
			return res;
		}

		public async Task<Category> UpdateAsync(int id, Category entity)
		{
			var res = await ctx.Categories.FindAsync(id);
			if (res == null) return res;

			ctx.Entry<Category>(entity).State = EntityState.Modified;
			await ctx.SaveChangesAsync();
			return entity;
		}
	}
}
