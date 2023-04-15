using System.ComponentModel.DataAnnotations;

namespace DemoBookStore.Models.Domain
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
