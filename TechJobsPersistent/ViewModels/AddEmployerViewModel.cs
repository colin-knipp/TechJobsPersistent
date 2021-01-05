using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobsPersistent.Models;

using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;

using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage = "Job is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Skill is required")]
        public string Location { get; set; }
    }
}
