using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingAdminService.Data;
using VotingAdminService.Models;

namespace VotingAdminService.Repositories
{
    public class ContenderRepo : IRepository<Contender>
    {
        private readonly AdminDbContext _context;

        public ContenderRepo(AdminDbContext context)
        {
            _context = context;
        }
        public bool Add(Contender entity)
        {
            _context.Contenders.Add(entity);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Contender> GetAll()
        {
            var contenders = _context.Contenders.ToList();
            return contenders;
        }

        public Contender GetByID(int id)
        {
            Contender contender = _context.Contenders.Find(id);
            return contender;
        }
    }
}