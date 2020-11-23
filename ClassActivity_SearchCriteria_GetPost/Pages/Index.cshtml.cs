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
        [BindProperty(SupportsGet =true)]
        public string SearchCriteria { get; set; }       
        public Dictionary<int, Student> Students { get; set; }
      
        [BindProperty]
        public Student NewStudent { get; set; }       

        // Fakerepo object reference
        private FakeRepo repo;
        public IndexModel()
        {
            // here we called singelton pattern instance ( we need always current updated instance which is only possible through this design pattern)
            // Page to page communication we need always updated instance of Fakerepo which possible by through this means.
            repo = FakeRepo.Instance;
            //when we use dependency Injection we dont need to create an FakeRepo object instance in a constructor 
            // repo = new FakeRepo();
            // Here are we call the GetAllStudents method to retrieve current Dictionary Object List
             Students = repo.GetAllStudents();
        }

        public IActionResult OnGet()
        {
            if (!String.IsNullOrEmpty(SearchCriteria))
            {
               Students = repo.FilterName(SearchCriteria);
            }
            return Page();
        }
        
        // Add new Resource we need to create post method 

        public IActionResult OnPost()
        {

            if(ModelState.IsValid)
            {
                // here we adding new Resource
                repo.AddNewStudent(NewStudent);
                // When we added new information , we need to retrieve updated List to show on the screen  
                Students = repo.GetAllStudents();
            }
            return Page();
        }
    }
}
