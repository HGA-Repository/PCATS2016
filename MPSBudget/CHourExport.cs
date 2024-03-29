﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using C1.C1Excel;

namespace RSMPS
{
    public class CHourExport //********************************Added 6/3/15
    {
       // public void ExportBudgetForPrimavera(string saveLoc, int budgetID)
        public void ExportBudgetForPrimavera(string saveLoc, int PCNID)
        {
            SqlDataReader dr;
            C1XLBook book = new C1XLBook();
            XLSheet sheet = book.Sheets[0];
            int indx;
            decimal tmpRate;

            // must be output with the following columns
            // code,blank,description,quantity,uom,hours,rate,cost

        
            dr = CBBudgetLine.GetExportList_Hour_ByPCNID(PCNID);

            indx = 1;
            tmpRate = 0;
            sheet[0, 3].Value = "PCNID";
            sheet[0, 4].Value = "Code";
            sheet[0, 5].Value = "WBS";
            sheet[0, 6].Value = "Description";
            sheet[0, 7].Value = "Quantity";
            sheet[0, 8].Value = "HoursPerItem";
            sheet[0, 9].Value = "Rate";
            sheet[0, 10].Value = "SubtotalHrs";
            sheet[0, 11].Value = "SubtotalDlrs";
            while (dr.Read())
            {
                sheet[indx, 3].Value = dr["PCNID"];                                                      //  code
                //sheet[indx, 4].Value = "";     
                sheet[indx, 4].Value = dr["Code"]; 
                sheet[indx, 5].Value = dr["WBS"];                                               //  description
                sheet[indx, 6].Value = dr["Description"].ToString();
                sheet[indx, 7].Value = dr["Quantity"];  //  quantity
                sheet[indx, 8].Value = dr["HoursPerItem"];
                sheet[indx, 9].Value = dr["Rate"];  
                sheet[indx, 10].Value = dr["SubtotalHrs"];                                                           //  uom
                sheet[indx, 11].Value = dr["SubtotalDlrs"].ToString();                                         //  hours
               // tmpRate = GetHourRate(Convert.ToInt32(dr["TotalHours"]), Convert.ToDecimal(dr["TotalDollars"]));
               // sheet[indx, 9].Value = tmpRate.ToString("#,##0.00");                                        //  rate
               // sheet[indx, 10].Value = Convert.ToDecimal(dr["TotalDollars"]).ToString("#,##0.00");         //  cost

                indx++;
            }
            dr.Close();

            book.Save(saveLoc);
        }

        private decimal GetHourRate(int hours, decimal totalCost)
        {
            decimal hourRate;

            if (hours != 0)
            {
                hourRate = totalCost / Convert.ToDecimal(hours);
            }
            else
            {
                hourRate = 0;
            }

            return hourRate;
        }
    }
}
