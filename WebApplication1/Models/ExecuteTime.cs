using System.ComponentModel.DataAnnotations;

namespace CacheServer.Models;

public class ExecuteTime
{
    [Key]
    public int Id { get; set; }
    public long Time { get; set; }
    public string Method { get; set; }
}
