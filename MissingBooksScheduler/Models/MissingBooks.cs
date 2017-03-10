using System;
using System.Collections.Generic;

namespace MissingBooksScheduler.Models
{
    public partial class MissingBooks
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? BorrowedBookId { get; set; }
        public int? StudentId { get; set; }

        public virtual Books Book { get; set; }
        public virtual BorrowedBooks BorrowedBook { get; set; }
        public virtual Students Student { get; set; }
    }
}
