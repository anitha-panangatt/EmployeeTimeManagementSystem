using ETMS.Service.BuisinessLayer.Interfaces;
using ETMS.Service.DataAccessLayer.Models;
using ETMS.Service.DataAccessLayer.Repository;
using ETMS.Service.DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETMS.Service.BuisinessLayer
{
    public class ProjectService:IProjectService
    {
        IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public int CreateProject(Project project)
        {
            project.IsActive = true;
            project.CreatedDateTime = DateTime.Now;

            return _projectRepository.CreateProject(project);
        }

        public int DeleteProject(int projectID)
        {
            var project = _projectRepository.GetProject(projectID);
            if (project != null)
            {
                project.IsActive = false;
                _projectRepository.UpdateProject(project);
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<Project>> GetAllEmployees()
        {
            return _projectRepository.GetAllProjects();
        }

        public Project GetProjectByName(string projectName)
        {
            return _projectRepository.GetProjectByName(projectName);
        }

        public Project GetProjectById(int projectId)
        {
            return _projectRepository.GetProject(projectId);
        }

        public int UpdateProjectInfo(Project project)
        {
            return _projectRepository.UpdateProject(project);
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return _projectRepository.GetAllProjects();
        }

        public int AllocateProjectToEmployee(ProjectAllocation allocationInfo)
        {
            allocationInfo.IsAllocationActive = true;
            allocationInfo.CreatedDateTime = DateTime.Now;
            return _projectRepository.CreateProjectAllocation(allocationInfo);
        }
    }
}
