using Core.DAL.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DAL.Repository
{
    public class BookRepository : BaseRepository<Book> , IBookRepository<Book>
    {
        public BookRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
