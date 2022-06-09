using AutoMapper;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Domain.Interfaces;
using Task9ASPNetCore.Infrastructure.Busines.DTO;
using Task9ASPNetCore.Services.Interfaces;


namespace Task9ASPNetCore.Infrastructure.Busines
{
    public class GroupService : IServices<GroupDTO>, IGroupDeleteCheck
    {
        private readonly IRepository<Group> _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(IRepository<Group> repository, IMapper mapper)
        {
            _groupRepository = repository;
            _mapper = mapper;
        }
    
        public async Task<bool> GroupDeleteCheck(int id)
        {
            bool result = false;
            var group = await _groupRepository.GetByIdAsync(id);

            if (id == default)
            {
                throw new ValidationException("Group Not Found", "");
            }
            else if (group.Students.Count() == 0)
            {
                result = true;
            }

            return result;
        }

        public async Task<IEnumerable<GroupDTO>> GetAllAsync(int id)
        {
            if (id == default)
            {
                throw new ValidationException("Course Not Found", "");
            }
            return _mapper.Map < IEnumerable<GroupDTO>>((await _groupRepository.GetAllAsync())).Where(g => g.CourseId == id);
        }

        public async Task<GroupDTO> GetByIdAsync(int id)
        {
            if (id == default)
            {
                throw new ValidationException("Group Not Found", "");
            }
            return _mapper.Map< GroupDTO>( await _groupRepository.GetByIdAsync(id));
        }

        public async Task CreateAsync(GroupDTO model)
        {
            if (model == null)
            {
                throw new ValidationException("Group Not Found", "");
            }

            await _groupRepository.SaveAsync(_mapper.Map<Group>(model));
        }

        public async Task UpdateAsync(GroupDTO model)
        {
            if (model == null)
            {
                throw new ValidationException("Group Not Found", "");
            }

            await _groupRepository.SaveAsync(_mapper.Map<Group>(model));
        }

        public async Task DeleteAsync(int id)
        {
            if (id == default)
            {
                throw new ValidationException("Group Not Found", "");
            }
            await _groupRepository.DeleteAsync(id);
        }


    }
}
