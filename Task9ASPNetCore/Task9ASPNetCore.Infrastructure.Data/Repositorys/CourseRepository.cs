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
    public class CourseRepository : IRepository<Course>
    {
        private readonly DBContext _dbContext;

        public CourseRepository(DBContext dBContext) 
        {
            _dbContext = dBContext;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _dbContext.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _dbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveAsync(Course model)
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
            _dbContext.Courses.Remove(new Course() {Id = id });
           await _dbContext.SaveChangesAsync();
        }
    }
}
