namespace iSecureGateway_Suprema.DTO
{
    public class AccessLevelDto
    {
        public required string Code { get; set; }

        public required string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
