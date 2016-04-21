using System;
using System.Collections.Generic;

namespace CreatingCircularReferenceBetweenInstances
{
    interface IUserConfigurationService
    {
        List<string> Attributes { get; }

        void SetUser(User user);
    }

    class UserConfigurationService : IUserConfigurationService
    {
        User user;

        public void SetUser(User user)
        {
            // for multithreading; shouldn't happen as this should be done only once
            lock (this)
            {
                if (this.user != null)
                {
                    // already done once? not allowing twice
                    throw new UserConfigurationServiceException("User already setup");
                }

                // first time so we are good
                this.user = user;
            }
        }

        public List<string> Attributes
        {
            get
            {
                // here i'm using the user object to rethrieve properties based on Other options of the user object
                return new List<string> { "foo", "bar" };
            }
        }
    }

    class UserConfigurationServiceException : ApplicationException
    {
        public UserConfigurationServiceException(string message) : base(message)
        {
        }
    }
}
