using Core.DAL.Entity;
using Core.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BLL
{
    public class BookBLL 
    {
        private IBookRepository<Book> _bookRepository;
        public BookBLL(IBookRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void SaveData(Book book)
        {
            _bookRepository.AddData(book);
        }

        public Book GetData()
        {
            return _bookRepository.SelectData(new Book());
        }
    }
}
