using BlazorWEbAssemblyDemo.Models;
using BlazorWEbAssemblyDemo.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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

        //public async Task SearchTask(TaskListSearch taskListSearch)
        //{
        //    TaskListSearch = taskListSearch;
        //    await GetTasks();
        //}


        private async Task SearchTask(EditContext context)
        {
            //TaskListSearch = taskListSearch;
            await GetTasks();

        }

        private async Task GetTasks()
        {

            var pagingResponse = await TaskApiClient.GetTaskList(TaskListSearch);
            Assignees = await UserApiClient.GetAssignees();
            Tasks = pagingResponse.Items;
        }


    }


}
