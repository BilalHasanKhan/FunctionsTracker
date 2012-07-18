using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentDateTime;


namespace TrackerBusiness.ACR
{
   public  class ACRStatus
    {
       public DateTime GetEndDate(DateTime StartDate, double estimatedEfforts, string acrStatus, int numberOfAssignees)
       {
           if (acrStatus == "ACR Scheduled")
           {
               int totalDays = Convert.ToInt32(Math.Ceiling(estimatedEfforts / numberOfAssignees));
               DateTime endDate = StartDate.AddBusinessDays(totalDays);
               return endDate;
           }

           else
           {
               throw new InvalidOperationException("ACR Not Scheduled");
           }

       }

    }
}
