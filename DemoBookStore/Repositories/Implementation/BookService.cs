using DemoBookStore.Models.Domain;
using DemoBookStore.Repositories.Abstract;

namespace DemoBookStore.Repositories.Implementation
{
    public class BookService:IBookService
    {
        private readonly DatabaseContext _databaseContext;
        public BookService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Add(Book model)
        {
            try
            {
                _databaseContext.Book.Add(model);
                _databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var model = this.FindById(id);
                //not found is null
                if (model == null)
                {
                    return false;
                }
                _databaseContext.Book.Remove(model);
                _databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Book FindById(int id)
        {
            return _databaseContext.Book.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            var data = (from book in _databaseContext.Book
                        join author in _databaseContext.Author
                        on book.AuthorId equals author.Id
                        join publisher in _databaseContext.Publisher on book.PublisherId equals publisher.Id
                        join genre in _databaseContext.Genre on book.GenreId equals genre.Id
                        select new Book
                        {
                            Id = book.Id,
                            AuthorId = book.AuthorId,
                            GenreId = book.GenreId,
                            Isbn = book.Isbn,
                            PublisherId = book.PublisherId,
                            Title = book.Title,
                            TotalPages = book.TotalPages,
                            GenreName = genre.Name,
                            AuthorName = author.AuthorName,
                            PublisherName = publisher.PublisherName
                        }
                        ).ToList();
            return data;
        }

        public bool Update(Book model)
        {
            try
            {
                _databaseContext.Book.Update(model);
                _databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
