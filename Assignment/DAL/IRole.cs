using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheckUserRole.DAL
{
    interface IRole<TModel,in TKey> where TModel : class
    {
        public Task<TModel> CreateRoleAsync(TModel model);

    }
}
