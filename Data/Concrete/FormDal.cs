using Core.Data.Base;
using Data.Abstract;
using Entities.Concrete;

namespace Data.Concrete
{
    public class FormDal : EntityRepositoryBase<Form,Context>,IFormDal
    {
    }
}
