using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PracticeApp.Models
{
    public class TestModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "VerifyEmail", controller: "Home", ErrorMessage = "Remote validation is working")]
        public string Email { get; set; } = string.Empty!;

        [Remote(action: "CheckMax", controller: "Home", AdditionalFields = nameof(Total))]
        public int Total { get; set; }
    }
}