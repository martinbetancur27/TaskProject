namespace TP.Core.DTO.ImportantTask
{
    public class CreateImportantTaskDTO
    {
        public string Description { get; set; }

        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
