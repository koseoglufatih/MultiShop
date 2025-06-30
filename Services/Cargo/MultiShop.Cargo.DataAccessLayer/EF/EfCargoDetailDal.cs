using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.EF
{
	public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
	{
		public EfCargoDetailDal(CargoContext context) : base(context)
		{
		}
	}
}
