using System.ComponentModel.DataAnnotations;

namespace GrpcServer.Models
{
    public class ExecuteTime
    {
        [Key]
        public int Id { get; set; }
        public long Time { get; set; }
        public string Method { get; set; }
    }
}
