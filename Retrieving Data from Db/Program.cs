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
            builder.DataSource = "Enter DataSource";
            builder.UserID = "Enter UserId";
            builder.Password = "Enter Password";
            builder.InitialCatalog = "Enter DB";
           
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                String sql = "Type The Query here";

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
                        int a =10;
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
