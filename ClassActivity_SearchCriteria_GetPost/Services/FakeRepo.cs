using ClassActivity_SearchCriteria_GetPost.Model;
using Microsoft.AspNetCore.SignalR.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassActivity_SearchCriteria_GetPost.Services
{
    public class FakeRepo
    {
        public Dictionary<int, Student> Students { get; set; }
        public FakeRepo()
        {
            // first object reference
            Students = new Dictionary<int, Student>();
            Students.Add(11, new Student(1, "ajohn", "jh@gmail.com", "john.jpg", Profession.Administration));
            Students.Add(22, new Student(2, "alex", "al@gmail.com", "alex.jpg", Profession.Production));
            Students.Add(33, new Student(3, "malina", "ma@gmail.com", "malina.jpg", Profession.Business));
            Students.Add(44, new Student(4, "nilma", "ni@gmail.com", "nilma.jpg", Profession.Accounting));

        }
        // Return all GetStudents
        public Dictionary<int, Student> GetAllStudents()
        {
            return Students;
        }

        // Add New Resource 
        public void AddNewStudent(Student student)
        {
            Students.Add(student.Id, student);
        }

        // Search Mechanism
        public Dictionary<int, Student> FilterName(string searchCriteria)
        {
            Dictionary<int, Student> result = new Dictionary<int, Student>();
            foreach(var student in Students.Values)
            {
                if (student.Name.StartsWith(searchCriteria))
                {
                    result.Add(student.Id, student);
                }
            }

            return result;
        }


    }
}
