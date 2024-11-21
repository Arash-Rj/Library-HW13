using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Entities
{
    public class Result
    {
        public bool IsDone { get; set; }
        public string Message { get; set; }
        public Result(bool isdone,string message=null) 
        {
            IsDone = isdone;
            Message = message;
        }
    }
}
