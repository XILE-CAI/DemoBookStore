using DemoBookStore.Models.Domain;

namespace DemoBookStore.Repositories.Abstract
{

    public interface IBookService
    {
        bool Add(Book model);

        bool Update(Book model);
        bool Delete(int id);

        Book FindById(int id);

        //Ienumerable is parent of list
        IEnumerable<Book> GetAll();
    }
   
}
