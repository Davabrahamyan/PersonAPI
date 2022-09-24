using System;
using System.Collections.Generic;

namespace PersonAPI.Models
{
    public partial class PersonDetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Number { get; set; } = null!;
    }
}
