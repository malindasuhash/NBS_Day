using NServiceBus;
using NServiceBus.Logging;

namespace Messages
{
    public class Auth : IHandleMessages<object>
    {
        public IBus Bus { get; set; }

        public void Handle(object message)
        {
            // Gets the username from the header.
            // Returns null if the item is not found.
            var username = Bus.GetMessageHeader(message, "Username1");

            if (!IsAuthorised(username))
            {
                LogManager.GetLogger("Auth").Warn("User not authorized.");
                Bus.DoNotContinueDispatchingCurrentMessageToHandlers();
            }
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