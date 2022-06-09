using AutoMapper;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Domain.Interfaces;
using Task9ASPNetCore.Infrastructure.Busines.DTO;
using Task9ASPNetCore.Services.Interfaces;


namespace Task9ASPNetCore.Infrastructure.Busines
{
    public class CourseServise : IServices<CourseDTO>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IMapper _mapper;

        public CourseServise(IRepository<Course> repository, IMapper mapper) 
        {
            _courseRepository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllAsync(int id)
        {
            return _mapper.Map<IEnumerable<CourseDTO>>(await _courseRepository.GetAllAsync());
        }

        public async Task<CourseDTO> GetByIdAsync(int id)
        {
            if (id == default)
            {
                throw new ValidationException("Course Not Found","");
            }
            return  _mapper.Map<CourseDTO>(await _courseRepository.GetByIdAsync(id));
        }

        public async Task CreateAsync(CourseDTO model)
        {
            if (model == null)
            {
                throw new ValidationException("Course Not Found", "");
            }
             await _courseRepository.SaveAsync(_mapper.Map<Course>(model));
        }

        public async Task UpdateAsync(CourseDTO model)
        {
            if (model == null)
            {
                throw new ValidationException("Course Not Found", "");
            }
            await _courseRepository.SaveAsync(_mapper.Map<Course>(model));
        }

        public async Task DeleteAsync(int id)
        {
            if (id == default)
            {
                throw new ValidationException("Course Not Found", "");
            }
            await _courseRepository.DeleteAsync(id);
        }

    }
}
