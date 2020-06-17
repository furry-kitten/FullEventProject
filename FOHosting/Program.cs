using System;
using System.ServiceModel;

namespace FOHosting
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Starting...");

            using (var host = new ServiceHost(typeof(ForOrganizators.ForOrganizators)))
            {
                try
                {
                    host.Open();
                    Console.WriteLine("Started!");
                }
                catch (CommunicationException ex)
                {
                    Console.WriteLine("An exception occurred: {0}", ex.Message);
                    host.Abort();
                    Console.WriteLine("<---------->");
                    Console.WriteLine("Host stoped!");
                    Console.WriteLine("<---------->");
                }
                finally
                {
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("To stop press any key");
                    Console.ReadKey();
                }
            }
        }
    }
}
