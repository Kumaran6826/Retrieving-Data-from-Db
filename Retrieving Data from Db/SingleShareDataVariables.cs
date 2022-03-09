using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrieving_Data_from_Db
{
    public class SingleShareData
    {
        public List<SingleShareDataVariables> singeData{ get; set; }
    }
        public class SingleShareDataVariables
    {

        public decimal OpenValue { get; set; }
        public decimal highValue { get; set; }
        public decimal lowValue { get; set; }
        public decimal volumeValue { get; set; }
        public decimal bidValue { get; set; }
        public decimal askValue { get; set; }

        

    }
}
