using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingAdminService.Repositories
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public T GetByID(int id);
        public bool Add(T entity);
    }
}