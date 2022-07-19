using System.ComponentModel.DataAnnotations;

namespace Mupsee.Models
{
    /// <summary>
    /// Email class
    /// </summary>
    public class EmailViewModel
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
