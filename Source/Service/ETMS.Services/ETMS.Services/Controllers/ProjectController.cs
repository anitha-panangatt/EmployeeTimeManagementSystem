using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETMS.Service.BuisinessLayer.Interfaces;
using ETMS.Service.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETMS.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {       
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }


        [HttpGet]
        [Route("GetProjects")]
        public async Task<IActionResult> GetProjects()
        {
            try
            {
                var projectList = await _projectService.GetAllProjects();
                if (projectList == null)
                {
                    return NotFound();
                }

                return Ok(projectList);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetProjectByName")]
        public async Task<IActionResult> GetProjectByName(string projectName)
        {
            try
            {
                var projectList = _projectService.GetProjectByName(projectName);
                if (projectList == null)
                {
                    return NotFound();
                }

                return Ok(projectList);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetProjectById")]
        public async Task<IActionResult> GetProjectById(int projectId)
        {
            try
            {
                var projectList = _projectService.GetProjectById(projectId);
                if (projectList == null)
                {
                    return NotFound();
                }

                return Ok(projectList);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("CreateProject")]
        public async Task<IActionResult> CreateProject([FromBody] Project project)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var projectID = _projectService.CreateProject(project);
                    if (projectID > 0)
                    {
                        return Ok(projectID);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateProject")]
        public async Task<IActionResult> UpdateProject([FromBody] Project project)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var projectID = _projectService.UpdateProjectInfo(project);
                    if (projectID > 0)
                    {
                        return Ok(projectID);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpGet]
        [Route("DeleteProject")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            try
            {
                var status = _projectService.DeleteProject(projectId);
                if (status <= 0)
                {
                    return NotFound();
                }

                return Ok(status);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AllocateProjectToEmployee")]
        public async Task<IActionResult> AllocateProjectToEmployee([FromBody] ProjectAllocation allocationInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var allocationId = _projectService.AllocateProjectToEmployee(allocationInfo);
                    if (allocationId > 0)
                    {
                        return Ok(allocationId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

    }
}
