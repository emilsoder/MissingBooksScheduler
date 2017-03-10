using System;
using System.Collections.Generic;

namespace MissingBooksScheduler.Models
{
    public partial class Students
    {
        public Students()
        {
            BorrowedBooks = new HashSet<BorrowedBooks>();
            MissingBooks = new HashSet<MissingBooks>();
        }

        public int StudentId { get; set; }
        public int? CourseId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BorrowedBooks> BorrowedBooks { get; set; }
        public virtual ICollection<MissingBooks> MissingBooks { get; set; }
        public virtual Courses Course { get; set; }
    }
}
