﻿namespace TP.Core.Entities
{
    public class UrgentTask
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime EndDate { get; set; }

        public string IdUser { get; set; }
    }
}
