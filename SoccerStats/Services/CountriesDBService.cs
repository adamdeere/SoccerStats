using Microsoft.Data.SqlClient;
using SoccerStats.Models;
using System.Data;

namespace SoccerStats.Services
{
    public class CountriesDBService : ICountriesDBService, IDisposable
    {
        string id;
        public CountriesDBService()
        {
            id = Guid.NewGuid().ToString();
            Console.WriteLine(id);
        }
        ~CountriesDBService() 
        {
            Console.WriteLine($"Deonstructer called: {id}");
        }

        public void Dispose()
        {
            Console.WriteLine($"Dispose called: {id}");
        }

        public List<CountryModel> RetriveCountries(string connectionString, string proc)
        {
            List<CountryModel> list = new List<CountryModel>();
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = proc;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        DataTable dt = ds.Tables[0];

                        foreach (DataRow dr in dt.Rows)
                        {
                            CountryModel m = new CountryModel()
                            {
                                
                                Id = dr["primary_id"].ToString(),
                                CountryCode = dr["country_code"].ToString(),
                                Flag = dr["country_flag"].ToString(),
                                Name = dr["country_name"].ToString(),

                            };
                            list.Add(m);
                        }
                    }
                }

                connection.Close();
                connection.Dispose();
            }

            return list;
                
        }
    }
}
