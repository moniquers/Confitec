using System;

namespace Confitec.Domain.Model
{
    public class User
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime Birthdate { get; private set; }
        public EducationLevel EducationLevel { get; private set; }
    }
}
