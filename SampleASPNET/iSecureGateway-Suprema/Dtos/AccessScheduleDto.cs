namespace iSecureGateway_Suprema.Dtos
{
    public class AccessScheduleDto
    {
        public required string Code { get; set; }

        public required string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
