﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorWEbAssemblyDemo.Models.Enums;

namespace BlazorWEbAssemblyDemo.Models
{
    public class TaskDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? AssigneeId { get; set; }

        public string AssigneeName { set; get; }
        
        public DateTime CreatedDate { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }
    }
}
