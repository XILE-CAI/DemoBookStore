using DemoBookStore.Models.Domain;
using DemoBookStore.Repositories.Abstract;

namespace DemoBookStore.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly DatabaseContext _databaseContext;

        public GenreService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public bool Add(Genre model)
        {
            try
            {
                _databaseContext.Genre.Add(model);
                _databaseContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
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
                if(model == null)
                {
                    return false;
                }
                _databaseContext.Genre.Remove(model);
                _databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genre FindById(int id)
        {
            return _databaseContext.Genre.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _databaseContext.Genre.ToList();
        }

        public bool Update(Genre model)
        {
            try
            {
                _databaseContext.Genre.Update(model);
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
