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
            //GetAllCustomer();
            //AddAddress();
            //DeleteAddress();
            //GetCustomerWithUsername();
            //GetAddressByAddressnumber();
        }

       

        public static void GetAddressByAddressnumber()
        {
            AddressRepository repository = new AddressRepository();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                Address address = repository.SelectedByNumber(1);
                stringBuilder.Append(address.neighborhood + " ");
                stringBuilder.Append(address.street + " ");
                stringBuilder.Append(address.district + " ");
                stringBuilder.Append(address.city + " ");
                stringBuilder.Append(address.buildnumber + " ");
                stringBuilder.Append(address.isactive + " ");
                Console.WriteLine(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("Bir Hata Oluştu: " + e);
            }
            Console.ReadKey();
        }

        public static void GetCustomerWithUsername()
        {
            CustomerRepository repository = new CustomerRepository();
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                Customer customer = repository.SelectedByUsername("saliha");
                    stringBuilder.Append(customer.username + " ");
                    stringBuilder.Append(customer.name + " ");
                    stringBuilder.Append(customer.lastname + " ");
                    stringBuilder.Append(customer.birthdate.ToShortDateString() + " ");
                    stringBuilder.Append(customer.age + " ");
                    stringBuilder.Append(customer.isactive + " ");
                    Console.WriteLine(stringBuilder.ToString());
                    stringBuilder.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("Bir Hata Oluştu: " + e);
            }
            Console.ReadKey();
        }

        public static void DeleteAddress()
        {
            IRepository<Address> repository = new AddressRepository();
            try
            {
                repository.Delete(1);
                Console.WriteLine("Silme başarılı");
            }
            catch (Exception e)
            {
                Console.WriteLine("Bir Hata Oluştu: " + e);
            }
            Console.ReadKey();

        }

        public static void AddAddress()
        {
            IRepository<Address> repository = new AddressRepository();
            Address address = new Address()
            {
                neighborhood = "İstiklal Mahallesi",
                street = "Palmiye Caddesi",
                city = "Manisa",
                district = "Turgutlu",
                buildnumber = 25,
                isactive  = 1
            };

            try
            {
                repository.Insert(address);

                Console.WriteLine("Ekleme başarılı");
            }
            catch (Exception e)
            {
                Console.WriteLine("Bir Hata Oluştu: " + e);
            }
            Console.ReadKey();

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
            customer.name = "Salih";
            customer.lastname = "Kardeş";
            customer.username = "salih";
            customer.password = "123456";
            customer.birthdate = new DateTime(1977, 08, 11);
            customer.age = DateTime.Now.Year - customer.birthdate.Year;
            try
            {
                bool insert = repository.Insert(customer);
                if(insert)
                    Console.WriteLine("İşlem Başarılı");
                else
                    Console.WriteLine("İşlem Başarısız.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Bir Hata Oluştu: " + e);
            }
            Console.ReadKey();
        }
    }
}
