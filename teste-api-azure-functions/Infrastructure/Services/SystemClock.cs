using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste_api_azure_functions.Domain.Interfaces;

namespace teste_api_azure_functions.Infrastructure.Services
{
    public class SystemClock : IClock
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
