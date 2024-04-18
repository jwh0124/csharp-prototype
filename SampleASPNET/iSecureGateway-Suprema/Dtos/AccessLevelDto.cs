using iSecureGateway_Suprema.Dtos;
using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.DTO
{
    public class AccessLevelDto
    {
        public required string Code { get; set; }

        public required string Name { get; set; }

        public AccessScheduleDto? AccessSchedule { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
