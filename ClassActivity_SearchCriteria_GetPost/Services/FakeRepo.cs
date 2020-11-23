using ClassActivity_SearchCriteria_GetPost.Model;
using System.Collections.Generic;
using System.Linq;

namespace ClassActivity_SearchCriteria_GetPost.Services
{
    public class FakeRepo
    {
        public Dictionary<int, Student> Students { get; set; }

        private static FakeRepo _instance;
        public static FakeRepo Instance
        {          
            get
            {
                if(_instance == null)
                {
                    _instance = new FakeRepo();
                }
                return _instance;
            }
        }
        public FakeRepo()
        {
            // first object reference
            Students = new Dictionary<int, Student>();
            Students.Add(1, new Student(1, "ajohn", "jh@gmail.com", "john.jpg", Profession.Administration));
            Students.Add(2, new Student(2, "alex", "al@gmail.com", "alex.jpg", Profession.Production));
            Students.Add(3, new Student(3, "malina", "ma@gmail.com", "malina.jpg", Profession.Business));
            Students.Add(4, new Student(4, "nilma", "ni@gmail.com", "nilma.jpg", Profession.Accounting));

        }
        // Return all GetStudents
        public Dictionary<int, Student> GetAllStudents()
        {
            return Students;
        }   

        // Add New Resource 
        public void AddNewStudent(Student student)
        {
            var st = AutoGenerateId(student);
            Students.Add(st.Id, st);
        }

        // Search Mechanism
       
        public Student GetStudentById(int id)
        {
            Student getStudentById = null;
            if (Students.ContainsKey(id))
            {
                getStudentById = Students[id];
            }
            return getStudentById;

        }

        // Update student 

        public void UpdateStudent(Student student)
        {
            if(student != null)
            {
                Students[student.Id].Id = student.Id;
                Students[student.Id].Name = student.Name;
                Students[student.Id].Profession = student.Profession;
                Students[student.Id].Image = student.Image;
                Students[student.Id].Email = student.Email;
            }
        }

        // Auto generate Id 
        public Student AutoGenerateId(Student student)
        {
            List<int> empListId = new List<int>();
            foreach (var stu in Students.Values)
            {
                empListId.Add(stu.Id);
            }
            if(empListId.Count != 0)
            {
                int maxId = empListId.Max() + 1;
                student.Id = maxId;
            }
            else
            {
                student.Id = 1;
            }

            return student;
        }

        public Dictionary<int, Student> FilterName(string searchCriteria)
        {
            Dictionary<int, Student> emp = new Dictionary<int, Student>();

            foreach(var stu in Students.Values)
            {
               if(stu.Name.StartsWith(searchCriteria))
                {  //I want to add searching results from dictionary and add these results into emp dic
                    emp.Add(stu.Id, stu);
                }
            }

            return emp;
        }


    }
}
