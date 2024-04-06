using Microsoft.EntityFrameworkCore;

namespace Simulacro.Models{
    public class Companies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nit { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Phone { get; set; }
        public string LegalRepresentative { get; set; }
        public int SectorId { get; set; }
        // public  DateTime create_at { get; set; }
        // public  DateTime update_at { get; set; }
    }
}