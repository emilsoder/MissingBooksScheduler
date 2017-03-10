using System;
using System.Collections.Generic;

namespace MissingBooksScheduler.Models
{
    public partial class Books
    {
        public Books()
        {
            BorrowedBooks = new HashSet<BorrowedBooks>();
            MissingBooks = new HashSet<MissingBooks>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }
        public string Isbn { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<BorrowedBooks> BorrowedBooks { get; set; }
        public virtual ICollection<MissingBooks> MissingBooks { get; set; }
    }
}
