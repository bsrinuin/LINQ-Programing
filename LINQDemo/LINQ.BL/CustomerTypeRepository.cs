using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.BL
{
    public class CustomerTypeRepository
    {


      



        public List<CustomerType> Retrieve()
        {
            List<CustomerType> CustomerTypeList = new List<CustomerType>
            {
                new CustomerType()
                {
                    CustomerTypeId = 1,
                    TypeName = "Bible Mission",
                    DisplayOrder = 2 },

                new CustomerType()
                {
                    CustomerTypeId = 2,
                    TypeName = "Proclaim Gospel",
                    DisplayOrder = 2
                },
                new CustomerType()
                {
                    CustomerTypeId = 3,
                    TypeName = "Sharing Good News",
                    DisplayOrder = 2
                },
                  new CustomerType()
                  {
                      CustomerTypeId = 4,
                      TypeName = "Helping Others",
                      DisplayOrder = 2
                  }
            };

            return CustomerTypeList; 
        }

    }
}
