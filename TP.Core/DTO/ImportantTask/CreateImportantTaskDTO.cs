using System.ComponentModel.DataAnnotations;

namespace TP.Core.DTO.ImportantTask
{
    public class CreateImportantTaskDTO
    {
        [Required]
        [MaxLength(60, ErrorMessage= "Sorry! The task must be a maximium of 60 characters")]
        public string Description { get; set; }

        [Required]
        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
