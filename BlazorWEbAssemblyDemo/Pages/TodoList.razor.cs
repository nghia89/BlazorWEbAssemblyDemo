using BlazorWEbAssemblyDemo.Models;
using BlazorWEbAssemblyDemo.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWEbAssemblyDemo.Pages
{
    public partial class TodoList
    {
        [Inject] private ITaskApiClient TaskApiClient { set; get; }

        private List<TaskDto> Tasks;


        protected override async Task OnInitializedAsync()
        {
            await GetTasks();
        }

        private async Task GetTasks()
        {

            var pagingResponse = await TaskApiClient.GetTaskList(new TaskListSearch() { });
            Tasks = pagingResponse.Items;

        }
    }


}
