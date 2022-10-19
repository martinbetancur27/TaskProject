﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TP.Core.Entities;

namespace TP.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ImportantTask> ImportantTasks { get; set; }
        public ICollection<UrgentTask> UrgentTasks { get; set; }
    }
}