using System;
using System.Collections.Generic;

namespace QuanLiNhanSu.Entities
{
    public partial class Department
    {
        public Department()
        {
            Users = new HashSet<User>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
