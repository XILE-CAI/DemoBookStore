using DemoBookStore.Models.Domain;
using DemoBookStore.Repositories.Abstract;

namespace DemoBookStore.Repositories.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly DatabaseContext _databaseContext;
        public AuthorService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Add(Author model)
        {
            try
            {
                _databaseContext.Author.Add(model);
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
                _databaseContext.Author.Remove(model);
                _databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Author FindById(int id)
        {
            return _databaseContext.Author.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _databaseContext.Author.ToList();
        }

        public bool Update(Author model)
        {
            try
            {
                _databaseContext.Author.Update(model);
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
