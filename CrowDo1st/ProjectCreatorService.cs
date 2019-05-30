using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrowDo1st
{
    class ProjectCreatorService : IProjectCreatorService
    {
        
        
        public bool AddProject(string email, ProjectProfilePage project)
        {
            var context = new CrowDoDbContext();
            var user = context.Set<User>().SingleOrDefault(User => User.Email == email);
            int pid = project.ProjectId;
            var prj = context.Set<ProjectProfilePage>().SingleOrDefault(b => b.ProjectId == pid);
            prj.User = user;
            user.CreatedProjects.Add(prj);
            context.SaveChanges();
            return true;
        }

        public ProjectProfilePage ProjectCreation(string email, string title, string description, ProjectCategoryId category, int scope)
        {
            var context = new CrowDoDbContext();
            var project = new ProjectProfilePage();
            project.Title = title;
            project.Description = description;
            project.Category = category;
            project.Balance = 0;
            project.TimeScope = scope;
            project.DateOfCreation = DateTime.Now;
            project.DeadLine = project.DateOfCreation.AddDays(scope);
            project.Active = true;
            context.Add(project);
            context.SaveChanges();
            AddProject(email, project);
            context.SaveChanges();
            return project;
        }

        public ProjectProfilePage ProjectEdit(string currenttitle, string title, string description, int timeScope)
        {
            var context = new CrowDoDbContext();
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(c => c.Title == currenttitle);
            if (project != null)
            {
                project.Title = title;
                project.Description = description;
                project.TimeScope = timeScope;
                context.Update(project);
                context.SaveChanges();
            }
            return project;
        }

        public Videos AddVideo(string projectName, string videoName)
        {
            var context = new CrowDoDbContext();
            var newVideo = new Videos();
            newVideo.Name = videoName;
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            project.Videos.Add(newVideo);
            context.SaveChanges();
            return newVideo;
        }

        public bool DeleteVideo(string projectName, string videoName)
        {
            var context = new CrowDoDbContext();
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            var video = context.Set<Photos>().SingleOrDefault(l => l.Name == videoName);
            context.Remove(video);
            context.SaveChanges();
            return true;

        }

        public Photos AddPhoto(string projectName, string photoName)
        {
            var context = new CrowDoDbContext();
            var newPhoto = new Photos();
            newPhoto.Name = photoName;
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            project.Photos.Add(newPhoto);
            context.SaveChanges();
            return newPhoto;
        }

        public bool DeletePhoto(string projectName, string photoName)
        {
            var context = new CrowDoDbContext();
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            var photo = context.Set<Photos>().SingleOrDefault(l => l.Name == photoName);
            context.Remove(photo);
            context.SaveChanges();
            return true;

        }

        public Package CreateFundPackages(string title, string description, decimal lowerBound, string reward, string projectTitle)
        {
                        
            var context = new CrowDoDbContext();
            var package = new Package();
            package.Title = title;
            package.Description = description;
            package.LowerBound = lowerBound;
            package.Reward = reward;
            context.Add(package);
            context.SaveChanges();
            AddPackage(projectTitle, package);
            return package;

        }

        public bool AddPackage(string projectTitle, Package package)
        {
            var context = new CrowDoDbContext();
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectTitle);
            int packid = package.PackageId;
            var packg = context.Set<Package>().SingleOrDefault(b => b.PackageId == packid);
            package.Project = project;
            project.Packages.Add(packg);
            context.SaveChanges();
            return true;
        }



    }


}

    
    

