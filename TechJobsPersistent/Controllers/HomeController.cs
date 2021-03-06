﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob(List<Skill> Skills)
        {
            var test = context.Employers.ToList();
            var test2 = context.Skills.ToList();
            AddJobViewModel viewModel = new AddJobViewModel(test, test2);

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
        {
            AddJobViewModel viewModel = new AddJobViewModel();

            if (ModelState.IsValid)
            {
                Employer thisEmployer = context.Employers.Find(addJobViewModel.EmployerId);

                Job newJob = new Job
                {
                    Employer = thisEmployer,
                    Name = addJobViewModel.JobName,
                    EmployerId = addJobViewModel.EmployerId
                };

                for (int i = 0; i < selectedSkills.Length; i++)
                {
                    

                    JobSkill newJobSkill = new JobSkill
                    {
                        SkillId = Int32.Parse(selectedSkills[i]),
                        JobId = newJob.Id,
                        Job = newJob


                    };

                    context.JobSkills.Add(newJobSkill);
                }


                
                context.Jobs.Add(newJob);
                context.SaveChanges();

                return Redirect("/Home/Detail/" + newJob.Id);
            }

            return View("AddJob", addJobViewModel);
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
