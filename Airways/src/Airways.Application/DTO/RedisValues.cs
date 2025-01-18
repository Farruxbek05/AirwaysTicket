namespace Airways.Application.DTO
{
    public class RedisValues
    {
        public RedisValues(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
        public DateTime OrderTime { get; set; } = DateTime.UtcNow;
    }


}
