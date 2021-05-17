using System;

namespace Confitec.Application.ViewModel
{
    public class UserVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int EducationLevel { get; set; }
    }
}
