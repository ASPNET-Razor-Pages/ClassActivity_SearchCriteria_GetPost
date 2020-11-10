using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassActivity_SearchCriteria_GetPost.Model;
using ClassActivity_SearchCriteria_GetPost.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ClassActivity_SearchCriteria_GetPost.Pages
{
    public class IndexModel : PageModel
    {
        // Target property for UI 
        public Dictionary<int, Student> Students { get; set; }

        // Target property for Post Method 
        [BindProperty]
        public Student NewStudent { get; set; }

        // search criteri property - target property
        [BindProperty(SupportsGet =true)]
        public string SearchCriteria { get; set; }

        public FakeRepo Repo;
        public IndexModel(FakeRepo repo)
        {
            //when we use dependency Injection we dont need to create an FakeRepo object instance in a constructor 
            // repo = new FakeRepo();
            Repo = repo;
            Students = Repo.GetAllStudents();
        }
        public IActionResult OnGet()
        {
            if(!String.IsNullOrEmpty(SearchCriteria))
            {
                Students = Repo.FilterName(SearchCriteria);
            }
            // fill up with data or information
            return Page();
        }

        // Add new Resource we need to create post method 

        public IActionResult OnPost()
        {
            Repo.AddNewStudent(NewStudent);
            Students = Repo.GetAllStudents();
            return Page();

        }
    }
}
