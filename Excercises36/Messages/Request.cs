namespace Messages
{
    [Message]
    public class Request
    {
        [Encrypted]
        public string SaySomething { get; set; }
    }
}