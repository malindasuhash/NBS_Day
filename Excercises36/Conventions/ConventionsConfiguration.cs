using System;
using System.Linq;
using System.Reflection;
using NServiceBus;

namespace Conventions
{
    /// <summary>
    /// This is a way to concetralise configuration information.
    /// </summary>
    /// <remarks>
    /// Note that NSB use lots of reflection.(not a big fan)
    /// </remarks>
    public class ConventionsConfiguration : IWantToRunBeforeConfiguration
    {
        public void Init()
        {
            Configure.Instance.DefiningMessagesAs(type =>
                     type.GetCustomAttributes(true)
                         .Any(t => t.GetType().Name == "MessageAttribute"))
                .DefiningTimeToBeReceivedAs(SetupTTL)
                .DefiningEncryptedPropertiesAs(EncryptionInfo)
                .RijndaelEncryptionService(); // Adding the configuration here as this configuration is common
            // for both sender and receiver.
        }

        private bool EncryptionInfo(PropertyInfo propertyInfo)
        {
            var p = propertyInfo.GetCustomAttributes(true)
                                .Any(t => t.GetType().Name.Equals("EncryptedAttribute"));

            return p;
        }

        private TimeSpan SetupTTL(Type t)
        {
            dynamic expression = t.GetCustomAttributes(true)
             .SingleOrDefault(s => s.GetType().Name.Equals("ExpiresAttribute"));

            return expression == null ? TimeSpan.MaxValue : expression.ExpiresAfter;
        }
    }
}