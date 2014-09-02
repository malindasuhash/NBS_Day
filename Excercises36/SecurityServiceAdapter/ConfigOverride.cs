using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;

namespace SecurityServiceAdapter
{
    /// <summary>
    /// Overrides the configuration RijndaelEncryptionServiceConfig that is
    /// set in the app.config
    /// </summary>
    /// <remarks>
    /// The <see cref="RijndaelEncryptionServiceConfig"/> refers back to the 
    /// config section in the app.config.
    /// </remarks>
    public class ConfigOverride : IProvideConfiguration<RijndaelEncryptionServiceConfig>
    {
        public RijndaelEncryptionServiceConfig GetConfiguration()
        {
            // In production, we should be able to get the configuration from
            // a centralised server. (CD)
            // NSB will lookup for IProvideConfiguration automatically.. No wireup required.
            return new RijndaelEncryptionServiceConfig()
                {
                    Key = "gdDbqRpqdRbTs3mhdZh9qCaDaxJXl+e7"
                };
        }
    }
}