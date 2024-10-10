using Core.Data;
using Entities.Concrete;

namespace Data.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
