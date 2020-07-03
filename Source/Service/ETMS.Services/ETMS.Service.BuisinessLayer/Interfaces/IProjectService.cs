using ETMS.Service.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETMS.Service.BuisinessLayer.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjects();

        Project GetProjectByName(string projectName);

        Project GetProjectById(int projectId);

        int CreateProject(Project project);

        int UpdateProjectInfo(Project project);

        int DeleteProject(int projectID);
        int AllocateProjectToEmployee(ProjectAllocation allocationInfo);
    }
}
