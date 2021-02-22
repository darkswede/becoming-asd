using System;
using System.Collections.Generic;

namespace becoming_asd.Models
{
    public class User
    {
        private ISet<Order> _orders = new HashSet<Order>();
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public decimal Funds { get; private set; }
        public IEnumerable<Order> Orders { get { return _orders; } }

        public User(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email is incorrect.");
            }

            if (Email == email)
            {
                return;
            }

            Email = email;
            Update();
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Email is incorrect.");
            }

            if (Password == password)
            {
                return;
            }

            Password = password;
            Update();
        }

        public void SetAge(int age)
        {
            if (age < 13)
            {
                throw new Exception("You have to be at least 13 years old");
            }

            if (age == 13)
            {
                return;
            }

            Age = age;
            Update();
        }

        public void Activate()
        {
            if (IsActive)
            {
                return;
            }

            IsActive = true;
            Update();
        }

        public void Deactivate()
        {
            if (!IsActive)
            {
                return;
            }

            IsActive = false;
            Update();
        }

        public void IncreaseFunds(decimal funds)
        {
            if (Funds <= 0)
            {
                throw new Exception("Funds must be greater than 0.");
            }

            Funds += funds;
            Update();
        }

        public void PurchaseOrder(Order order)
        {
            if (!IsActive)
            {
                throw new Exception("You need to be an active user to complete an order.");
            }

            decimal orderPrice = order.TotalPrice;
            if (Funds - orderPrice < 0)
            {
                throw new Exception("You don't have enough money");
            }

            order.Purchase();
            Funds -= orderPrice;
            _orders.Add(order);
            Update();
        }

        private void Update()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}