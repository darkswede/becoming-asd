namespace becoming_asd.Models
{
    public interface IEmailSender
    {
        void SendMessage(string receiver, string title, string message);
    }

    public class EmailSender : IEmailSender
    {
        public void SendMessage(string receiver, string title, string message)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IDatabase
    {
        bool IsConnected { get; }
        void Connect();
        User GetUser(string email);
        Order GetOrder(int id);
        void SaveChanges();
    }

    public class Database : IDatabase
    {
        public bool IsConnected => throw new System.NotImplementedException();

        public void Connect()
        {
            throw new System.NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(string email)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IOrderProcesssor
    {
        void ProcessOrder(string email, int orderId);
    }

    public class OrderProcessor : IOrderProcesssor
    {
        private readonly IDatabase _database;
        private readonly IEmailSender _emailSender;

        public OrderProcessor(IDatabase database, IEmailSender emailSender)
        {
            _database = database;
            _emailSender = emailSender;
        }

        public void ProcessOrder(string email, int orderId)
        {
            User user = _database.GetUser(email);
            if (user == null)
            {
                return;
            }

            Order order = _database.GetOrder(orderId);
            if (order == null)
            {
                return;
            }

            user.PurchaseOrder(order);
            _database.SaveChanges();
            _emailSender.SendMessage(email, "Order Purchased", "Success!");
        }
    }
}