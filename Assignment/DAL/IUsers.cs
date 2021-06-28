using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheckUserRole.DAL
{
    interface IUsers<TModel,in Tkey> where TModel : class
    {
        public Task<TModel> CreateAsyncUser(TModel model);
    }

}
