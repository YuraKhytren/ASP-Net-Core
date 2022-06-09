using AutoMapper;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Domain.Interfaces;
using Task9ASPNetCore.Infrastructure.Busines.DTO;
using Task9ASPNetCore.Services.Interfaces;


namespace Task9ASPNetCore.Infrastructure.Busines
{
    public class StudentService : IServices<StudentDTO>
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IMapper _mapper;
        public StudentService(IRepository<Student> repository, IMapper mapper)
         
        {
            _studentRepository = repository; 
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync(int id)
        {
            if (id == default)
            {
                throw new ValidationException("Group Not Found", "");
            }
            return  _mapper.Map<IEnumerable< StudentDTO >>(await _studentRepository.GetAllAsync()).Where(g => g.GroupId == id);
        }

        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            if (id == default)
            {
                throw new ValidationException("Student Not Found", "");
            }
            return _mapper.Map<StudentDTO> (await _studentRepository.GetByIdAsync(id));
        }

        public async Task CreateAsync(StudentDTO model)
        {
            if (model == null)
            {
                throw new ValidationException("Student Not Found", "");
            }
            await _studentRepository.SaveAsync(_mapper.Map<Student>(model));
        }

        public async Task UpdateAsync(StudentDTO model)
        {
            if (model == null)
            {
                throw new ValidationException("Student Not Found", "");
            }
            await _studentRepository.SaveAsync(_mapper.Map<Student>(model));
        }

        public async Task DeleteAsync(int id)
        {
            if (id == default)
            {
                throw new ValidationException("Student Not Found", "");
            }
            await _studentRepository.DeleteAsync(id);
        }
    }
}
