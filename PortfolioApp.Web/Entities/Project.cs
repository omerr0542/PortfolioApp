using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Web.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        [MinLength(5, ErrorMessage = "Proje Adı En Az 5 Karakter Olmalıdır")]
        [MaxLength(50, ErrorMessage = "Proje Adı En Fazla 50 Karakter Olmalıdır")]
        [Required(ErrorMessage = "Proje Adı Zorunludur")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Proje Açıklaması Zorunludur")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Proje Resmi Zorunludur")]
        public string ImageUrl { get; set; }
        public string GitHubUrl { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
