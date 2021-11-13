using Blazored.Toast.Services;
using BlazorWEbAssemblyDemo.Models;
using BlazorWEbAssemblyDemo.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWEbAssemblyDemo.Components;
using BlazorWEbAssemblyDemo.Models.SeedWork;

namespace BlazorWEbAssemblyDemo.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskApiClient TaskApiClient { set; get; }
        [Inject] private IUserApiClient UserApiClient { set; get; }

        public MetaData MetaData { get; set; } = new MetaData();
        protected Confirmation DeleteConfirmation { set; get; }

        private TaskListSearch TaskListSearch = new TaskListSearch();
        private Guid DeleteId { get; set; }

        private List<TaskDto> Tasks;

        private async Task GetTasks()
        {
            try
            {
                var pagingResponse = await TaskApiClient.GetTaskList(TaskListSearch);
                Tasks = pagingResponse.Items;
                MetaData = pagingResponse.MetaData;
            }
            catch (Exception ex)
            {
                //Error.ProcessError(ex);
            }

        }

        protected override async Task OnInitializedAsync()
        {
            await GetTasks();
        }




        public async Task onsearchTaskList(TaskListSearch taskListSearch)
        {
            TaskListSearch = taskListSearch;
            await GetTasks();
        }
        public void OnDeleteTask(Guid deleteId)
        {
            DeleteId = deleteId;
            DeleteConfirmation.Show();
        }



        public async Task OnConfirmDeleteTask(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await TaskApiClient.DeleteTask(DeleteId);
                await GetTasks();
            }
        }

        private async Task SelectedPage(int page)
        {
            TaskListSearch.PageNumber = page;
            await GetTasks();
        }
    }


}
