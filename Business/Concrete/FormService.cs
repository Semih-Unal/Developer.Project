using Business.Abstract;
using Data.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FormService : IFormService
    {
        private readonly IFormDal _formDal;
        public FormService(IFormDal formDal)
        {
            _formDal = formDal;
        }
        public void Add(Form frm)
        {
            _formDal.Add(frm);
        }

        public List<Form> GetAll(string formName)
        {
            return _formDal.GetAll().Where(x=> (string.IsNullOrWhiteSpace(formName) || x.Name.ToLower().Contains(formName.ToLower()))).ToList();
        }
        public Form GetForm(int formId)
        {
            return _formDal.GetAll().FirstOrDefault(x=>x.Id== formId);
        }
    }
}
