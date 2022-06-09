using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Domain.Interfaces;
using Task9ASPNetCore.Services.Interfaces;

namespace Task9ASPNetCore.Infrastructure.Data.Repositorys
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly DBContext _dbContext;

        public GroupRepository(DBContext dBContext)
        { 
            _dbContext = dBContext;
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _dbContext.Groups.Include(s => s.Students).ToListAsync();
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _dbContext.Groups.AsNoTracking().Include(s => s.Students).FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task SaveAsync(Group model)
        {
            if (model.Id == default)
            {
                _dbContext.Entry(model).State = EntityState.Added;
            }
            else
            {
                _dbContext.Entry(model).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            _dbContext.Groups.Remove( new Group() { Id = id } );
            await _dbContext.SaveChangesAsync();
        }

    }
}
