namespace Notification.Services.Options
{
    public class RedisOptions
    {
        public string ConnectionString { get; set; }
        public string AbsoluteExpireTime { get; set; }
        public string SlidingExpireTime { get; set; }
    }
}
