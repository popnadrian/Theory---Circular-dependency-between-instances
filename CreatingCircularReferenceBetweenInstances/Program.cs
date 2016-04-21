using System;

namespace CreatingCircularReferenceBetweenInstances
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User(new UserConfigurationService());

            Console.WriteLine("User attributes: {0}", string.Join(",", user.Attributes));

            Console.ReadKey();
        }
    }
}
