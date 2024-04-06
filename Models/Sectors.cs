using Microsoft.EntityFrameworkCore;

namespace Simulacro.Models
{
    public class Sectors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}