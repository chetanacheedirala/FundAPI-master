using FundAPI.Models;
using System.Collections.Generic;

namespace FundAPI.DB
{
    public interface IFundManager
    {
        List<FundDetails> GetFundDetails();
    }
}