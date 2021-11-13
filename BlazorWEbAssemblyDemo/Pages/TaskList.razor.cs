﻿using Blazored.Toast.Services;
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


        private List<TaskDto> Tasks;

        private async Task GetTasks()
        {
            try
            {
                var pagingResponse = await TaskApiClient.GetTaskList(TaskListSearch);
                Tasks = pagingResponse.Items;
            }
            catch (Exception ex)
            {
                //Error.ProcessError(ex);
            }

        }

        protected async override Task OnInitializedAsync()
        {
            await GetTasks();
        }


        public async Task onsearchTaskList(TaskListSearch taskListSearch)
        {
            TaskListSearch = taskListSearch;
            await GetTasks();
        }

    }


}
