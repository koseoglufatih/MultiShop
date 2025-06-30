using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.EF
{
	public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
	{
		public EfCargoCustomerDal(CargoContext context) : base(context)
		{
		}
	}
}
