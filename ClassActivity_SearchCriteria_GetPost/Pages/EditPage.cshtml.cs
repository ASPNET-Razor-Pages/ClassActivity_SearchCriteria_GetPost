using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassActivity_SearchCriteria_GetPost.Model;
using ClassActivity_SearchCriteria_GetPost.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassActivity_SearchCriteria_GetPost.Pages
{
    public class EditPageModel : PageModel
    {
        [BindProperty]
        public Student EditStudent { get; set; }

        // Fakerepo object reference
        private FakeRepo repo;
        public EditPageModel()
        {
             EditStudent = new Student();
            repo = FakeRepo.Instance;
            
        }
        public IActionResult OnGet(int id)
        {
            
            EditStudent = repo.GetStudentById(id);

            return Page(); ;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(EditStudent != null)
            {
                repo.UpdateStudent(EditStudent);
            }

            return RedirectToPage("Index");
        }

      
    }
}
