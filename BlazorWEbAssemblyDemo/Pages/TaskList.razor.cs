using BlazorWEbAssemblyDemo.Models;
using BlazorWEbAssemblyDemo.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWEbAssemblyDemo.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskApiClient TaskApiClient { set; get; }
        [Inject] private IUserApiClient UserApiClient { set; get; }


        private TaskListSearch TaskListSearch = new TaskListSearch();

        private List<AssigneeDto> Assignees;


        private List<TaskDto> Tasks;


        protected override async Task OnInitializedAsync()
        {
            await GetTasks();
        }

        private async Task GetTasks()
        {

            var pagingResponse = await TaskApiClient.GetTaskList(new TaskListSearch() { });
            Assignees = await UserApiClient.GetAssignees();
            Tasks = pagingResponse.Items;

        }

    }


}
