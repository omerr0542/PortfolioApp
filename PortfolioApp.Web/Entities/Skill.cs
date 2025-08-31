using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Web.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Title { get; set; }

        [Range(0, 100, ErrorMessage = "Değer 0 ile 100 Arasında Olmalıdır!")]
        public int Percentage { get; set; }
    }
}
