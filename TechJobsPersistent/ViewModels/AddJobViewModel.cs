using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required(ErrorMessage = "Job name is required")]
        public string JobName { get; set; }

        [Required(ErrorMessage = "Employer is required")]
        public int EmployerId { get; set; }

        public Job Job { get; set; }

        public List<SelectListItem> Employers { get; set; }

        public List<Skill> Skills { get; set; }

        

        public AddJobViewModel(List<Employer> possibleEmployers, List<Skill> possibleSkills)
        {
            Employers = new List<SelectListItem>();
            

            foreach (var employer in possibleEmployers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });
            }

            Skills = possibleSkills;

            //foreach (var skill in Skills)
            //{
             //   possibleSkills.Add(new Skill
             //   {
             //       Id = Int16.Parse(skill.Value),
             //       Name = skill.Text
             //   }); 
           // }

            
            
        }

        public AddJobViewModel()
        {
            

        }
    }
}
