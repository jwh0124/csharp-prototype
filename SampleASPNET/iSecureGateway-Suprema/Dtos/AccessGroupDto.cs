namespace iSecureGateway_Suprema.DTO
{
    public class AccessGroupDto
    {
        public string? Code { get; set; }

        public required string Name { get; set; }

        public ICollection<AccessLevelDto>? AccessLevels { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
