using System;

namespace UseADO.Modals
{
    public class Customer
    {
        public string Id { get; set; }
        public string  Name { get; set; }

        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }

        public Customer()
        {
        }

        public Customer(string id, string name, string gender, string address, DateTime dOB)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Address = address;
            DOB = dOB;
        }
    }
}
