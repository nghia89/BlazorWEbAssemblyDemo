using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorWEbAssemblyDemo.Models.Enums;

namespace BlazorWEbAssemblyDemo.Models
{
    public class TaskUpdateRequest
    {
        public string Name { get; set; }

        public Priority Priority { get; set; }

    }
}
