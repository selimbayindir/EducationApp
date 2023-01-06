using EducationApp.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationAPP.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity 
        //class deyimini kaldırdım Base Entity yazacaktım BaseEntiy zaten class daha dar class
    {
        DbSet<T> Table { get; }
    }
}
