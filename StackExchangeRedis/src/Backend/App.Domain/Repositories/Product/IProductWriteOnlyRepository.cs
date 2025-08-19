using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Repositories.Product
{
    public interface IProductWriteOnlyRepository
    {
        Task Add(Entities.Product product);
    }
}
