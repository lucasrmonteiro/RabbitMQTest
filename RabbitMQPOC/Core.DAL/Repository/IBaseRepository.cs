using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DAL.Repository
{
    public interface IBaseRepository<TEntity>
    {
        void AddData(TEntity entity);

        TEntity SelectData(TEntity entity);
    }
}
