using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    static public class JobLogic
    {
        static public double CalculateTimeUsed(List<WorkTime> ListWorkTime)
        {

            double returnResult = 0;

            foreach (WorkTime WT in ListWorkTime)
            {
                double result;

                TimeSpan WTresult = WT.EndTime- WT.StartTime;
                result = WTresult.Hours;
                if (WTresult.Minutes == 30)
                {
                    result = result + 0.50;
                }
                returnResult = returnResult + result;
            }   

            return returnResult;
        }
    }
}
