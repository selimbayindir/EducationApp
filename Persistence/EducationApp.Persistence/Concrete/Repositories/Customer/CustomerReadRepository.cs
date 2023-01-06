using EducationApp.Domain.Entities;
using EducationApp.Persistence.Context;
using EducationAPP.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Persistence.Concrete.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(EducationAppContext context) : base(context)
        {
        }
    }
}
