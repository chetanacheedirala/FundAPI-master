using FundAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection.Emit;
using Microsoft.Extensions.Configuration;

namespace FundAPI.DB
{
    public class FundManager : IFundManager
    {
        private IConfiguration _configuration;
        
        public FundManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<FundDetails> GetFundDetails()
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("FundDBConnection");
                List<FundDetails> listFundDetails = new List<FundDetails>();
                using (var conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetFundDetails", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        FundDetails obj = new FundDetails();
                        obj.FundName = reader["FundName"].ToString();
                        obj.Ticker = reader["Ticker"].ToString();
                        obj.MorningStar = reader["MorningStar"].ToString();
                        obj.MonthlyAvgValue = decimal.Parse(reader["MonthlyAvgValue"].ToString());
                        obj.ThreeMonthsAvgValue = decimal.Parse(reader["ThreeMonthsAvgValue"].ToString());
                        obj.OneYearAvgValue = decimal.Parse(reader["OneYearAvgValue"].ToString());
                        obj.FiveYearsAvgValue = decimal.Parse(reader["FiveYearsAvgValue"].ToString());
                        obj.SinceInceptionAvgValue = decimal.Parse(reader["SinceInceptionAvgValue"].ToString());
                        listFundDetails.Add(obj);
                    }
                    conn.Close();
                }
                return listFundDetails;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
