using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Cart
    {
        public List<Cartline> Lines { get; set; } = new List<Cartline>();

        public virtual void AddItem(Book book, int quantity)
        {
            Cartline line = Lines.Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new Cartline
                {
                    Book = book,
                    Quantity = quantity,
                    Price = book.Price
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveItem(Book book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotal() => (decimal)Lines.Sum(e => e.Price * e.Quantity);

        public class Cartline
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
        }
    }
}
