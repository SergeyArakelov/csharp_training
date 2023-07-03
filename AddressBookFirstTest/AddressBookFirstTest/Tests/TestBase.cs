using NUnit.Framework;
using System.Text;

namespace AddressBookTests
{
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {

            app = ApplicationManager.GetInstance();

        }


        [OneTimeTearDown]
        public void StopApplicationManager()
        {
            ApplicationManager.Stop();
        }

        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {

            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                var foo = rnd.Next(65, 90);
                var bar = Convert.ToChar(foo);
                builder.Append(bar);

            }
            return builder.ToString();
            
        }
    }
}
