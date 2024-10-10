using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFormService
    {
        List<Form> GetAll(string formName=null);

        void Add(Form form);
        Form GetForm(int formId);
    }
}
