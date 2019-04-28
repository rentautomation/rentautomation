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

            //InsertCustomer();
            GetAllCustomer();
        }

        public static void GetAllCustomer()
        {
            IRepository<Customer> repository = new CustomerRepository();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                IList<Customer> customers = repository.SelectAll();
                for (int i = 0; i < customers.Count; i++)
                {
                    stringBuilder.Append(customers[i].username+" ");
                    stringBuilder.Append(customers[i].name + " ");
                    stringBuilder.Append(customers[i].lastname + " ");
                    stringBuilder.Append(customers[i].birthdate.ToShortDateString()+" ");
                    stringBuilder.Append(customers[i].age + " ");
                    stringBuilder.Append(customers[i].isactive + " ");
                    Console.WriteLine(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Bir Hata Oluştu: " + e);
            }
            Console.ReadKey();
        }

        public static void InsertCustomer()
        {
            IRepository<Customer> repository = new CustomerRepository();
            Customer customer = new Customer();
            customer.name = "Merve";
            customer.lastname = "Güneş";
            customer.username = "mrvgunes";
            customer.password = "123456";
            customer.birthdate = new DateTime(1979, 09, 17);
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
