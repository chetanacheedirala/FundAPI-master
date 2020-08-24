using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundAPI.Models
{
    [Serializable]
    public class FundDetails
    {
        public string FundName { get; set; }
        public string Ticker { get; set; }
        public string MorningStar { get; set; }
        public decimal MonthlyAvgValue { get; set; }
        public decimal ThreeMonthsAvgValue { get; set; }
        public decimal OneYearAvgValue { get; set; }
        public decimal FiveYearsAvgValue { get; set; }
        public decimal SinceInceptionAvgValue { get; set; }
    }
}
