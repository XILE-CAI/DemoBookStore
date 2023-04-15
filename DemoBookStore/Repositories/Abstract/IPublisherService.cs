using DemoBookStore.Models.Domain;

namespace DemoBookStore.Repositories.Abstract
{
    public interface IPublisherService
    {
        bool Add(Publisher model);

        bool Update(Publisher model);
        bool Delete(int id);

        Publisher FindById(int id);

        //Ienumerable is parent of list
        IEnumerable<Publisher> GetAll();
    }
}
