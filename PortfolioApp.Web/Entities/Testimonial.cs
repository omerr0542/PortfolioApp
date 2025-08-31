using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Web.Entities
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }

        [Range(0, 5, ErrorMessage = "Değer 0 ile 5 Arasında Olmalıdır!")]
        public int Review { get; set; }
    }
}
