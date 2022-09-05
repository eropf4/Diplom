using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Diplom.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Resourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly ApplicationContext Context;

        public ResourceController(ApplicationContext context)
        {
            Context = context;
        }

        private string UserId => User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;

        [HttpGet]
        [Authorize]
        [Route("task")]
        public JsonResult GetTaskData([FromBody]string TaskId)
        {
            var user = Context.Accounts.FirstOrDefault(x => x.Id == int.Parse(UserId)) ;
            var task = Context.UserTasks.Include(x => x.Files).FirstOrDefault(x => x.Id == int.Parse(TaskId));

            var workgroupsTask = Context.WorkgroupTasks.FirstOrDefault(x => x.UserTasks.Contains(task));

            var workgroup = Context.Workgroups.FirstOrDefault(x => x.WorkgroupTasks.Contains(workgroupsTask));
            var Project = Context.Projects.FirstOrDefault(x => x.Workgroups.Contains(workgroup));

            var taskName = task.Name;
            var taskDescripton = task.Description;
            var endTimeTask = task.EndDateTime;
            var taskReadiness = task.Readiness;
            var taskReview = task.Review;
            var TaskFiles = new List<TaskFile>();
            foreach (var file in task.Files)
                TaskFiles.Add(new TaskFile {Id = file.Id, dateTime = file.Datetime, Name = file.Name, Definition = file.Definition });

            var ProjectName = Project.ProjectTittle;
            var workgroupName = workgroup.Title;

            
            var result = new JsonResult(new {TaskName = taskName,
            taskDescripton = taskDescripton,
            endTimeTask = endTimeTask,
            taskReadiness = taskReadiness,
            taskReview = taskReview,
            TaskFiles = TaskFiles,
            ProjectName = ProjectName,
            workgroupName = workgroupName,
            workgroupsTaskId = workgroupsTask.Id,
            worgroupsTaskName = workgroupsTask.Title
            });

            return result;
        }

        private class TaskFile
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime dateTime { get; set; }
            public string Definition { get; set; }
        }
    }

}
