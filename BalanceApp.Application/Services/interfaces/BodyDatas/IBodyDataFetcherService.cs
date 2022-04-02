using BalanceApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Services.interfaces.BodyDatas
{
    public interface IBodyDataFetcherService
    {
        Task<List<BodyData>> GetAllBodyData(string userEmail);
    }
}
