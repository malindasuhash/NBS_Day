using NServiceBus;
using NServiceBus.Logging;

namespace Messages
{
    /// <summary>
    /// Handles all the messages.
    /// Not sure whether this is a good thing or not. This handler captures
    /// all the messages received by the receiver. 
    /// </summary>
    public class Auth : IHandleMessages<object>
    {
        public IBus Bus { get; set; }

        public void Handle(object message)
        {
            //// Gets the username from the header.
            //// Returns null if the item is not found.
            //var username = Bus.GetMessageHeader(message, "Username");

            //if (!IsAuthorised(username))
            //{
            //    LogManager.GetLogger("Auth").Warn("User not authorized.");
            //    Bus.DoNotContinueDispatchingCurrentMessageToHandlers();
            //}
        }

        private bool IsAuthorised(string user)
        {
            if (user == null)
            {
                return false;
            }

            return user.Equals("malinda");
        }
    }
}