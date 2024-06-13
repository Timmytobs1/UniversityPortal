﻿namespace UniversityPortal.Dtos.Student
{
    public class UpdateStudentDto
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
}
