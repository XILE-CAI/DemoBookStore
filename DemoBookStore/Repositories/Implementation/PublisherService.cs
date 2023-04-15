using DemoBookStore.Models.Domain;
using DemoBookStore.Repositories.Abstract;

namespace DemoBookStore.Repositories.Implementation
{
    public class PublisherService:IPublisherService
    {
        private readonly DatabaseContext _databaseContext;

        public PublisherService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public bool Add(Publisher model)
        {
            try
            {
                _databaseContext.Publisher.Add(model);
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
                _databaseContext.Publisher.Remove(model);
                _databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Publisher FindById(int id)
        {
            return _databaseContext.Publisher.Find(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _databaseContext.Publisher.ToList();
        }

        public bool Update(Publisher model)
        {
            try
            {
                _databaseContext.Publisher.Update(model);
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
