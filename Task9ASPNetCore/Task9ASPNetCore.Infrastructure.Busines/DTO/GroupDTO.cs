﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9ASPNetCore.Infrastructure.Busines.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentCount { get; set; }
        public int CourseId { get; set; }
    }
}
