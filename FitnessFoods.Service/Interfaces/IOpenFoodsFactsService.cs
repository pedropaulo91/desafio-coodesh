using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessFoods.Service.Interfaces
{
    public interface IOpenFoodsFactsService
    {
        Task ImportData();
    }
}
