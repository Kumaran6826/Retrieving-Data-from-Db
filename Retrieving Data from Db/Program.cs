using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrieving_Data_from_Db
{
    public class Program : SingleShareDataVariables
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            SingleShareDataVariables s=new SingleShareDataVariables();
            builder.DataSource = "10.10.15.8";
            builder.UserID = "test";
            builder.Password = "123456";
            builder.InitialCatalog = "shark";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                String sql = "SELECT [ip].[Open] as OpenValue,[ip].[high] as highValue ,[ip].[Low] as lowValue,[ip].[Volume] as volumeValue,[ip].[bid] as BidValue,[ip].[Ask] as AskValue from [dbo].[InstrumentPrice] ip where InstrumentId in(32865,32864);";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    DataTable dt = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(dt);
              
                   
                    List<SingleShareDataVariables> list=new List<SingleShareDataVariables>();
                    SingleShareData sobj =new SingleShareData();

                    foreach (DataRow row in dt.Rows)
                    {

                        
                        SingleShareDataVariables ss = new SingleShareDataVariables();
                        decimal decimalValue = decimal.Round(Convert.ToDecimal(row["OpenValue"].ToString()), 2);
                        Console.WriteLine("Open value {0}", decimalValue);
                        ss.OpenValue = decimalValue;

                        
                        decimal highValue = decimal.Round(Convert.ToDecimal(row["highValue"].ToString()), 2);
                        Console.WriteLine("highValue {0}", highValue);
                     ss.highValue = highValue;
                        decimal lowValue = decimal.Round(Convert.ToDecimal(row["lowValue"].ToString()), 2);
                        Console.WriteLine("lowValue {0}", lowValue);
                        ss.lowValue = lowValue;
                       
                        decimal volumeValue = Convert.ToDecimal(row["volumeValue"].ToString());
                        Console.WriteLine("volumeValue {0}", volumeValue);
                        ss.volumeValue= volumeValue; 
                        
                        decimal BidValue = decimal.Round(Convert.ToDecimal(row["BidValue"].ToString()), 2);
                        Console.WriteLine("BidValue {0}", BidValue);
                        ss.bidValue = BidValue;
                 
                        decimal AskValue = decimal.Round(Convert.ToDecimal(row["AskValue"].ToString()), 2);
                        Console.WriteLine("AskValue {0}", AskValue);
                        ss.askValue = AskValue;
                        list.Add(ss);

                    }
                    sobj.singeData = list;
                   decimal c = sobj.singeData[0].OpenValue;




                    



                }
                connection.Close();
            }
        }
    }
}
