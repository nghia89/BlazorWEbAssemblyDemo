using BlazorWEbAssemblyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorWEbAssemblyDemo.Services
{
    public interface IUserApiClient
    {
        Task<List<AssigneeDto>> GetAssignees();
    }
}
