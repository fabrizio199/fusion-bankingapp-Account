


using Microsoft.AspNet.SignalR;

namespace ConsoleApp7
{
    class Redis
    {

        public void Demo()
        {
            string redisConn1 = "Redis_1";

            services.AddSignalR().AddStackExchangeRedis(null, redisConn1);

            //testchange

            // Any connection or hub wire up and configuration should go here
           // UseStackExchangeRedis("redis-server.cloudapp.net", 6379, "MyStrongPassword1234", redisConn2);
        }
    }
        private string GetAuthorizationHeader()
        {
            return string.Empty;
        }
    }
}
