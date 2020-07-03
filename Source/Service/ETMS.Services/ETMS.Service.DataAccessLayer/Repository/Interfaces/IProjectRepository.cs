using ETMS.Service.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETMS.Service.DataAccessLayer.Repository.Interfaces
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects();
        Project GetProject(int projectId);

        Project GetProjectByName(string projectName);

        int CreateProject(Project project);

        int UpdateProject(Project project);
        int CreateProjectAllocation(ProjectAllocation allocationInfo);
    }
}
