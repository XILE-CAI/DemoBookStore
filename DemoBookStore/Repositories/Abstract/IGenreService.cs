using DemoBookStore.Models.Domain;

namespace DemoBookStore.Repositories.Abstract
{
    public interface IGenreService
    {
        bool Add(Genre model);

        bool Update(Genre model);
        bool Delete(int id);

        Genre FindById(int id);

        //Ienumerable is parent of list
        IEnumerable<Genre> GetAll();
    }
}
