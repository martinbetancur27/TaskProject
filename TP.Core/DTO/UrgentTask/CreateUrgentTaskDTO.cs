namespace TP.Core.DTO.UrgentTask
{
    public class CreateUrgentTaskDTO
    {
        public string Description { get; set; }

        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
