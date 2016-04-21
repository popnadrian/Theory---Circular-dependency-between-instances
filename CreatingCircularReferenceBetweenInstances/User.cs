using System.Collections.Generic;

namespace CreatingCircularReferenceBetweenInstances
{
    class User
    {
        readonly IUserConfigurationService configService;

        public User(IUserConfigurationService configService)
        {
            this.configService = configService;
            configService.SetUser(this);
        }

        public List<string> Attributes { get { return configService.Attributes; } }
    }
}
