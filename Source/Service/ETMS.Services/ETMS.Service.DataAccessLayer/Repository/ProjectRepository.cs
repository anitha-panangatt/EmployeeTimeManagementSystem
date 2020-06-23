using ETMS.Service.DataAccessLayer.Models;
using ETMS.Service.DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETMS.Service.DataAccessLayer.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        public readonly EMTSDbContext _context;
        public ProjectRepository(EMTSDbContext context)
        {
            _context = context;
        }
        public int CreateProject(Project project)
        {
            _context.Add(project);
            return _context.SaveChanges();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _context.Project.OrderBy(e => e.ProjectName).ToList();
        }

        public Project GetProject(int projectId)
        {
            return _context.Project.FirstOrDefault(e => e.ProjectId == projectId);
        }

        public Project GetProjectByName(string projectName)
        {
            return _context.Project.FirstOrDefault(x => x.ProjectName == projectName);
        }

        public int UpdateProject(Project project)
        {
            var response = _context.Project.Update(project);
            return _context.SaveChanges();
        }
    }
}
