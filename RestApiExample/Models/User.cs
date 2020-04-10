using Microsoft.EntityFrameworkCore;

namespace RestApiExample.Models
{
    public class User
    {
        public long Id { get; set; }
        public string name { get; set; }
        public bool IsComplete { get; set; }
    }
}
