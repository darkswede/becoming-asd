using becoming_asd.Models;

namespace becoming_asd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Order order = new Order(1, 199);
            User user = new User("user@email.com", "secret");
        }
    }
}