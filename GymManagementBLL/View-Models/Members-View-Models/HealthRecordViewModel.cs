using System.ComponentModel.DataAnnotations;

namespace GymManagementBLL.View_Models
{
    public class HealthRecordViewModel
    {
        [Required(ErrorMessage = "Height is required")]
        [Range(50, 250, ErrorMessage = "Height must be between 50 cm and 250 cm")]
        public decimal Height { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [Range(20, 300, ErrorMessage = "Weight must be between 20 kg and 300 kg")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Blood type is required")]
        [RegularExpression(@"^(A|B|AB|O)[+-]$", ErrorMessage = "Invalid blood type (valid examples: A+, B-, O+, AB-)")]
        public string BloodType { get; set; } = null!;

        [StringLength(300, ErrorMessage = "Note can't exceed 300 characters")]
        public string? Note { get; set; }
    }
}
