using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Person
    {
        public int IdPerson { get; set; }
        public string PersonName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsDarkMode { get; set; }

        public virtual User? User { get; set; }
    }
}
