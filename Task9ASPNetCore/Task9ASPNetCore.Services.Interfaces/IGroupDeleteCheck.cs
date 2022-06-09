using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9ASPNetCore.Services.Interfaces
{
    public interface IGroupDeleteCheck
    {
        Task<bool> GroupDeleteCheck(int id);
    }
}
