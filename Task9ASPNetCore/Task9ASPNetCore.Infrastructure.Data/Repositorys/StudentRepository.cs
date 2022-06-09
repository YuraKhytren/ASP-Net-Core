using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Domain.Interfaces;

namespace Task9ASPNetCore.Infrastructure.Data.Repositorys
{
    public class StudentRepository : IRepository<Student>
    {

        private readonly DBContext _dbContext;

        public StudentRepository(DBContext dBContext) 
        { 
            _dbContext = dBContext;
        }
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _dbContext.Students.Include(s => s.Group).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task SaveAsync(Student model)
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
            _dbContext.Students.Remove(new Student() { Id = id });
            await _dbContext.SaveChangesAsync();
        }
    }
}
