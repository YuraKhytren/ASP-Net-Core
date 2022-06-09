using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Domain.Interfaces;
using Task9ASPNetCore.Services.Interfaces;

namespace Task9ASPNetCore.Services.Data.ServiceRepository
{
    public class GroupServiseRepository : IServices<Group>
    {
        public IRepository<Group> Repository { get; set; }
    }
}
