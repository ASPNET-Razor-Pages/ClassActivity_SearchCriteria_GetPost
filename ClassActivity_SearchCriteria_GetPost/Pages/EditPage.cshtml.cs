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

        public FakeRepo _repo;
        public EditPageModel(FakeRepo repo)
        {
             EditStudent = new Student();
            _repo = repo;
            
        }
        public IActionResult OnGet(int id)
        {
            
            EditStudent = _repo.GetStudentById(id);

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
                _repo.UpdateStudent(EditStudent);
            }

            return RedirectToPage("Index");
        }

      
    }
}
