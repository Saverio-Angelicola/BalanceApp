using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalanceApp.Domain;

namespace BalanceApp.Application.Dtos.BodyData
{
    public class BodyDataListDto
    {
        public List<Domain.ValueObjects.BodyData> bodydatas { get; set; }
        public BodyDataListDto(List<Domain.ValueObjects.BodyData> list)
        {
            bodydatas = list;
        }
        public BodyDataListDto()
        {
            bodydatas = new List<Domain.ValueObjects.BodyData>();
        }
    }
}
