using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using uCommunity.Server.Data;

namespace uCommunity.TestClient
{
    public class WCFTest
    {
        public static void TestCreateUser()
        {
            string uri = "http://localhost:55935/UserService.svc/CreateUser";
            User user = new User() { FirstName = "test", LastName = "haha", Alias = "test", LoginName = "test", Pwd = "123" };
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = client.PostAsJsonAsync<User>(uri, user).Result;
                Console.WriteLine(message.Content.ReadAsAsync<ResultWrapper<User>>().Result);
            }
        }

        public static void TestGetUser()
        {
            string uri = "http://localhost:55935/UserService.svc/GetUser/{0}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = client.GetAsync(string.Format(uri, "ED827F9E-AB23-49C6-89B4-1AFF1595DECC")).Result;
                var res = message.Content.ReadAsAsync<User>().Result;
            }
        }
    }
}
