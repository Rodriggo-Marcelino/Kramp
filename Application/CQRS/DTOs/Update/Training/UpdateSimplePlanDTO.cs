﻿namespace Application.CQRS.DTOs.Update.Training
{
    public record UpdateSimplePlanDTO : UpdateGenericDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
