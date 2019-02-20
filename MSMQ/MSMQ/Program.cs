using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Configuration;

namespace MSMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = ConfigurationManager.AppSettings["MsmqPath"];
            MessageQueue messageQueue = null;
            try
            {
                var model = new Model()
                {
                    ID = 4,
                    Name = "Rajesh",
                    Age = "35",
                    Dob = DateTime.Now,
                    Address = "Pune"
                };

                if (MessageQueue.Exists(path))
                {
                    messageQueue = new MessageQueue(path);
                }

                else
                {
                    MessageQueue.Create(path);
                    messageQueue = new MessageQueue(path);

                }
                messageQueue.Send(model, "TestModel");
            }
           catch(Exception ex)
            {
                throw;
            }
            finally
            {
                messageQueue.Dispose();
            }
            
        }
    }
}
