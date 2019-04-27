using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Data.Abstracts;
using Rent.Data.Concretes;
using Rent.Model.Concretes;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            InsertCustomer();
        }

        public static void InsertCustomer()
        {
            IRepository<Customer> repository = new CustomerRepository();
            Customer customer = new Customer();
            customer.name = "Murat";
            customer.lastname = "Doğan";
            customer.username = "muratdogan";
            customer.password = "123456";
            customer.birthdate = new DateTime(1998, 04, 12);
            customer.age = DateTime.Now.Year - customer.birthdate.Year;
            try
            {
                repository.Insert(customer);
                Console.WriteLine("İşlem Başarılı");
            }
            catch (Exception e)
            {
                Console.WriteLine("Bir Hata Oluştu: " + e);
            }
            Console.ReadKey();
        }
    }
}
