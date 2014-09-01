using System;

namespace Messages
{
    /// <summary>
    /// Marks how long a message will remain in the queue.
    /// </summary>
    public class ExpiresAttribute : Attribute
    {
        public TimeSpan ExpiresAfter { get; set; }

        public ExpiresAttribute(int expiresAfterSeconds)
        {
            ExpiresAfter = TimeSpan.FromSeconds(expiresAfterSeconds);
        }
    }
}