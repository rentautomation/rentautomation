using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Data.Concretes;
using Rent.Model.Abstracts;
using Rent.Model.Concretes;

namespace Rent.Business.Concretes
{
    public class CustomerBusiness
    {
        public Customer SignUp(Customer customer)
        {
            Customer currentCustomer = null;
            try
            {
                CustomerRepository repository = new CustomerRepository();
                currentCustomer = repository.SelectedByUsername(customer.username);

                if(currentCustomer != null)
                {
                    throw new Exception(" Customer Already Registered!\n");
                }

                bool insert = repository.Insert(customer);
                if (!insert)
                    throw new Exception(" Operation Failed");
                currentCustomer = repository.SelectedByUsername(customer.username);
            }
            catch(Exception ex)
            {
                throw new Exception("CustomerBisuness::SignUp: Error occured.\n", ex);
            }
            return currentCustomer;   
        }

        public Customer SignIn(string username, string password)
        {
            Customer currentCustomer = null;
            try
            {
                CustomerRepository repository = new CustomerRepository();
                currentCustomer = repository.SelectedByUsername(username, password);

                if (currentCustomer == null)
                    throw new Exception("CustomerBisuness::SignIn: Username or Password is Wrong!\n");
                
                
            }
            catch (Exception ex)
            {
                throw new Exception("CustomerBisuness::SignIn: Error occured.\n", ex);
            }
            return currentCustomer;
        }

        public RentModel RentVehicle(RentModel rentModel)
        {
            RentModel rent = null;
            try
            {
                VehicleRepository vehicleRepository = new VehicleRepository();
                Vehicle vehicle = vehicleRepository.SelectedByNumber(rentModel.vehiclenumber);

                if(vehicle == null)
                    throw new Exception("CustomerBisuness::RentVehicle: Vehcile Is Not Found! \n");

                MemberRepository repository = new MemberRepository();
                Member isHaveMember = repository.SelectedByNumber(rentModel.membernumber);

                if (isHaveMember == null)
                    throw new Exception("CustomerBisuness::RentVehicle: Customer Is Not Found! \n");

                if (vehicleRepository.VehicleIsTaken(rentModel.vehiclenumber))
                    throw new Exception("CustomerBisuness::RentVehicle: Vehicle Is Not Available! \n");

                RentRepository rentRepository = new RentRepository();
                rentRepository.Insert(rentModel);
                rent = rentRepository.SelectedByVehicleAndMember(rentModel.vehiclenumber, rentModel.membernumber);

                //Vehicle Update
                vehicle.istaken = 1;
                vehicleRepository.Update(vehicle);
            }
            catch (Exception ex)
            {

                throw new Exception("CustomerBisuness::RentVehicle: Error occured.\n", ex);
            }
            return rent;
        }

        public RentModel CancelRentVehicle(RentModel rentModel)
        {
            RentModel rent = null;
            try
            {
                VehicleRepository vehicleRepository = new VehicleRepository();
                Vehicle vehicle = vehicleRepository.SelectedByNumber(rentModel.vehiclenumber);

                if(vehicle == null)
                    throw new Exception("CustomerBisuness::RentVehicle: Vehcile Is Not Found! \n");

                //Rent Update
                RentRepository rentRepository = new RentRepository();

                rentModel.isactive = 0;
                rentRepository.Update(rentModel);

                rent = rentRepository.SelectedByVehicleAndMember(rentModel.vehiclenumber, rentModel.membernumber);

                //Vehicle Update
                vehicle.istaken = 0;
                vehicleRepository.Update(vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception("CustomerBisuness::RentVehicle: Error occured.\n", ex);
            }
            return rent;
        }

        public Rezerv RezervVehicle(Rezerv rezervVehicle)
        {
            Rezerv rezerv = null;
            try
            {
                VehicleRepository vehicleRepository = new VehicleRepository();
                Vehicle vehicle = vehicleRepository.SelectedByNumber(rezervVehicle.vehiclenumber);

                if (vehicle == null)
                    throw new Exception("CustomerBisuness::RentVehicle: Vehcile Is Not Found! \n");

                MemberRepository repository = new MemberRepository();
                Member isHaveMember = repository.SelectedByNumber(rezervVehicle.membernumber);

                if (isHaveMember == null)
                    throw new Exception("CustomerBisuness::RentVehicle: Customer Is Not Found! \n");

                if (vehicleRepository.VehicleIsTaken(rezervVehicle.vehiclenumber))
                    throw new Exception("CustomerBisuness::RentVehicle: Vehicle Is Not Available! \n");

                //Rezerv Insert
                RezervRepository rezervRepository = new RezervRepository();
                rezervRepository.Insert(rezervVehicle);
                //Rezerv Get
                rezerv = rezervRepository.SelectedByVehicleAndMember(rezervVehicle.vehiclenumber, rezervVehicle.membernumber);

                //Vehicle Update
                vehicle.istaken = 1;
                vehicleRepository.Update(vehicle);
            }
            catch (Exception ex)
            {

                throw new Exception("CustomerBisuness::RentVehicle: Error occured.\n", ex);
            }
            return rezerv;
        }

        public Rezerv CancelRezervVehicle(Rezerv rezervVehicle)
        {
            Rezerv rezerv = null;
            try
            {
                VehicleRepository vehicleRepository = new VehicleRepository();
                Vehicle vehicle = vehicleRepository.SelectedByNumber(rezervVehicle.vehiclenumber);

                if (vehicle == null)
                    throw new Exception("CustomerBisuness::RentVehicle: Vehcile Is Not Found! \n");

               
              
                //Rezerv Update
                RezervRepository rezervRepository = new RezervRepository();
                rezervVehicle.isactive = 0;
                rezervRepository.Update(rezervVehicle);
                //Rezerv Get
                rezerv = rezervRepository.SelectedByVehicleAndMember(rezervVehicle.vehiclenumber, rezervVehicle.membernumber);

                //Vehicle Update
                vehicle.istaken = 0;
                vehicleRepository.Update(vehicle);
            }
            catch (Exception ex)
            {

                throw new Exception("CustomerBisuness::RentVehicle: Error occured.\n", ex);
            }
            return rezerv;
        }

    }
}
