using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassActivity_SearchCriteria_GetPost.Model
{
    public class Student
    {
        public Student(int id, string name, string email, string image, Profession profession)
        {
            Id = id;
            Name = name;
            Email = email;
            Image = image;
            Profession = profession;
        }

        public Student()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }

        public Profession Profession { get; set; }
    }
}
