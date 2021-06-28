using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApp
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TModel"></typeparam>
	/// <typeparam name="TKey"></typeparam>
	public interface IService<TModel, in TKey> where TModel : class
	{
		// Read all records from Collections
		 void Get();
		// Read a single record based on Key
		 void Get(TKey id);
		// CReate a new Record
		IEnumerable<TModel> Create(TModel model);
		// Update record based on key
		 void Update(TKey id, TModel model);
		 //Delete record based on key
		 bool Delete(TKey id);
	}
}
