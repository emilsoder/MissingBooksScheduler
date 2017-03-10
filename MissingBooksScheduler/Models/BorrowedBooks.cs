using System;
using System.Collections.Generic;

namespace MissingBooksScheduler.Models
{
    public partial class BorrowedBooks
    {
        public BorrowedBooks()
        {
            MissingBooks = new HashSet<MissingBooks>();
        }

        public int Id { get; set; }
        public int? BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int StudentId { get; set; }

        public virtual ICollection<MissingBooks> MissingBooks { get; set; }
        public virtual Books Book { get; set; }
        public virtual Students Student { get; set; }
    }
}
