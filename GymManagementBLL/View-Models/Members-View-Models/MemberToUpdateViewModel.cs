using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.View_Models.Members_View_Models
{
    public class MemberToUpdateViewModel
    {
        public string Name { get; set; } = null!;
        public string? Photo { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Email must be in a valid format (e.g., name@example.com)")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^01[0-2,5][0-9]{8}$", ErrorMessage = "Phone number must be a valid Egyptian number (e.g., 01012345678)")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Building number is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Building number must be greater than 0")]
        public int BuildingNumber { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "City name must be between 2 and 50 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "City name can contain letters and spaces only")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Street is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Street name must be between 2 and 100 characters")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Street name can contain letters, numbers, and spaces only")]
        public string Street { get; set; } = null!;
    }
}
