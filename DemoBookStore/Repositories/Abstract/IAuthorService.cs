using DemoBookStore.Models.Domain;

namespace DemoBookStore.Repositories.Abstract
{
    public interface IAuthorService
    {
        bool Add(Author model);

        bool Update(Author model);
        bool Delete(int id);

        Author FindById(int id);

        //Ienumerable is parent of list
        IEnumerable<Author> GetAll();
    }
}

