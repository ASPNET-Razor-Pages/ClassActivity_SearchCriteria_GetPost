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
        // This property we use when we display collection of objects first time in a Page
        public Dictionary<int, Student> Students { get; set; }

        // Target property for Post Method 
        // This property we use when we make a Post request of form
        // Adding new Resource information 
        [BindProperty]
        public Student NewStudent { get; set; }

        // search criteri property - target property
        [BindProperty(SupportsGet =true)]

        // This property we use when we make a Search of specific objects
        public string SearchCriteria { get; set; }

        public FakeRepo Repo;
        public IndexModel(FakeRepo repo)
        {
            //when we use dependency Injection we dont need to create an FakeRepo object instance in a constructor 
            // repo = new FakeRepo();
            Repo = repo;
            // Here are we call the GetAllStudents method to retrieve current Dictionary Object List
            Students = Repo.GetAllStudents();
        }
        public IActionResult OnGet()
        {
            if(!String.IsNullOrEmpty(SearchCriteria))
            {
                // Here we update Students property with current searching criteria
                Students = Repo.FilterName(SearchCriteria);
            }
            // fill up with data or information
            return Page();
        }

        // Add new Resource we need to create post method 

        public IActionResult OnPost()
        {
            // here we adding new Resource
            Repo.AddNewStudent(NewStudent);
            // When we added new information , we need to retrieve updated List to show on the screen  
            Students = Repo.GetAllStudents();
            return Page();

        }
    }
}
