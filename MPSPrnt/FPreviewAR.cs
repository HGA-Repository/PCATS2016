using RSMPS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



using GrapeCity.ActiveReports;

//using C1.C1Excel;

using DataDynamics.ActiveReports;

namespace RSMPS
{
    public partial class FPreviewAR : Form
    {
        private SectionReport rprt;

        public  string projNumber;  //**********************Added these three variables 6/25/15 
        public string Title;//********************Added 9/30/2015********************10/1
        public string pcnNumber;
        public  string reportType;
        public int budID;

        public string wbs;
        
        //public string BusinessUnit;
        
        public FPreviewAR()
        {
            InitializeComponent();
                                     
        }

        public void ViewReport(SectionReport ar)
        {
           
            
          //  MessageBox.Show("Wbs is"+this.wbs);
            reportType = ar.GetType().ToString(); //***************************Added 6/29
           
            //MessageBox.Show(reportType);

          //  MessageBox.Show(budID.ToString());

           

            rprt = ar;
            viewer1.Document = rprt.Document;
            rprt.Run();
        }

        public void ViewReportNoRun(SectionReport ar)
        {
            reportType = ar.GetType().ToString(); //***************************Added 6/29
            rprt = ar;
            viewer1.Document = rprt.Document;
        }

        public void ViewReportWithExcel(SectionReport ar)
        {
            reportType = ar.GetType().ToString(); //***************************Added 6/29
            rprt = ar;
            viewer1.Document = rprt.Document;
            rprt.Run();
        }

        public void ViewDrawingLogWithExcel(SectionReport ar)
        {
            reportType = ar.GetType().ToString(); //***************************Added 6/29
            rprt = ar;
            viewer1.Document = rprt.Document;
            rprt.Run();
        }
       
        private void SendForcastReportToExcel()
        {
        //    GrapeCity.ActiveReports.Export.Excel.Section.XlsExport xlExport;
        //    xlExport = new GrapeCity.ActiveReports.Export.Excel.Section.XlsExport();

        //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        this.Cursor = Cursors.WaitCursor;

        //        xlExport.Export(viewer1.Document, saveFileDialog1.FileName);

        //        this.Cursor = Cursors.Default;
        //    }
        }
        private void SendForcastReportToExcelOld()
        {
        //     if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        this.Cursor = Cursors.WaitCursor;

        //        C1.C1Excel.C1XLBook book = new C1.C1Excel.C1XLBook();
        //        C1.C1Excel.XLSheet sheet = book.Sheets[0];
        //        int indx = 0;
        //        int ftc1000, ftc2000, ftc3000, ftc4000, ftc5000, ftc6000;
        //        int ftcTotVal;

        //        sheet[indx, 0].Value = "Job #";
        //        sheet[indx, 1].Value = "Client";
        //        sheet[indx, 2].Value = "Description";
        //        sheet[indx, 3].Value = "Admin/PM";
        //        sheet[indx, 4].Value = "Proc";
        //        sheet[indx, 5].Value = "M/P";
        //        sheet[indx, 6].Value = "CSA";
        //        sheet[indx, 7].Value = "E&I";
        //        sheet[indx, 8].Value = "Spclst";
        //        sheet[indx, 9].Value = "Total";
        //        sheet[indx, 10].Value = "Status";

        //        indx++;

        //        foreach (DataRow dr in ((DataSet)rprt.DataSource).Tables[0].Rows)
        //        {
                  
        //            ftc1000 = Convert.ToInt32(dr["ftc1000"]);
        //            ftc2000 = Convert.ToInt32(dr["ftc2000"]);
        //            ftc3000 = Convert.ToInt32(dr["ftc3000"]);
        //            ftc4000 = Convert.ToInt32(dr["ftc4000"]);
        //            ftc5000 = Convert.ToInt32(dr["ftc5000"]);
        //            ftc6000 = Convert.ToInt32(dr["ftc6000"]);
        //            ftcTotVal = ftc1000 + ftc2000 + ftc3000 + ftc4000 + ftc5000 + ftc6000;

        //            sheet[indx, 0].Value = dr["Number"].ToString();
        //            sheet[indx, 1].Value = dr["Customer"].ToString();
        //            sheet[indx, 2].Value = dr["Description"].ToString();
        //            sheet[indx, 3].Value = ftc1000;
        //            sheet[indx, 4].Value = ftc2000;
        //            sheet[indx, 5].Value = ftc3000;
        //            sheet[indx, 6].Value = ftc4000;
        //            sheet[indx, 7].Value = ftc5000;
        //            sheet[indx, 8].Value = ftc6000;
        //            sheet[indx, 9].Value = ftcTotVal;
        //            sheet[indx, 10].Value = dr["Status"].ToString();

        //            indx++;
        //        }

        //        book.Save(saveFileDialog1.FileName);

        //        this.Cursor = Cursors.Default;
        //    }
        }

        private void SendDrawingLogToExcel()




        {


            //SaveFileDialog sv3 = new SaveFileDialog();
            //Report_Name = CreateFileNAme();
            //sv3.FileName = Report_Name;
            //sv3.Filter = "XLS Files | *.xls";
            //sv3.DefaultExt = "xls";


            //if (sv3.ShowDialog() == DialogResult.OK)
            //{
            //    this.Cursor = Cursors.WaitCursor;

            //    C1.C1Excel.C1XLBook book = new C1.C1Excel.C1XLBook();
            //    C1.C1Excel.XLSheet sheet = book.Sheets[0];
            //    int indx = 0;
            //    string hgaNumber, cadNumber, title, revision, issuedate, issuefor, transmittalnumber;
            //    //SSS 201131126 uncommented the comment
            //    //string cadNumber, title, revision, issuedate, issuefor, transmittalnumber;
            //    DataSet dsLoc;
            //    DataView dvLoc;

            //    sheet[indx, 0].Value = "CADNumber";
            //    sheet[indx, 1].Value = "Title";
            //    sheet[indx, 2].Value = "Revision";
            //    sheet[indx, 3].Value = "IssueDate";
            //    sheet[indx, 4].Value = "IssuedFor";
            //    sheet[indx, 5].Value = "TransmittalNumber";

            //    indx++;

            //    dsLoc = (dsDrawingLog)rprt.DataSource;
            //    dvLoc = new DataView(dsLoc.Tables["Revisions"]);
            //    dvLoc.Sort = "IssuedDate";

            //    foreach (DataRow dr in dsLoc.Tables["DrawingList"].Rows)
            //    {
            //        dvLoc.RowFilter = "DrawingID = " + dr["DrawingID"].ToString();

            //        if (dvLoc.Count > 0)
            //        {
            //            for (int i = 0; i < dvLoc.Count; i++)
            //            {
            //                DataRowView d = dvLoc[i];

            //                cadNumber = dr["CADNumber"].ToString();
            //                title = dr["Title1"].ToString();
            //                revision = d["RevisionNumber"].ToString();
            //                issuedate = DateToOutput(Convert.ToDateTime(d["IssuedDate"]));
            //                issuefor = d["IssuedFor"].ToString();
            //                transmittalnumber = d["TransmittalNumber"].ToString();

            //                sheet[indx, 0].Value = cadNumber;
            //                sheet[indx, 1].Value = title;
            //                sheet[indx, 2].Value = revision;
            //                sheet[indx, 3].Value = issuedate;
            //                sheet[indx, 4].Value = issuefor;
            //                sheet[indx, 5].Value = transmittalnumber;

            //                indx++;
            //            }
            //        }
            //        else
            //        {
            //            cadNumber = dr["CADNumber"].ToString();
            //            hgaNumber = dr["DrawingID"].ToString();
            //            title = dr["Title1"].ToString();
            //            revision = "";
            //            issuedate = "";
            //            issuefor = "";
            //            transmittalnumber = "";

            //            sheet[indx, 0].Value = cadNumber;
            //            sheet[indx, 1].Value = title;
            //            sheet[indx, 2].Value = revision;
            //            sheet[indx, 3].Value = issuedate;
            //            sheet[indx, 4].Value = issuefor;
            //            sheet[indx, 5].Value = transmittalnumber;

            //            indx++;
            //        }
            //    }

            //    book.Save(sv3.FileName);

            //    this.Cursor = Cursors.Default;
            //}
        }

        private string DateToOutput(DateTime dOut)
        {
            string retVal = "";

            if (dOut < new DateTime(2000, 1, 1))
                retVal = "";
            else
                retVal = dOut.ToShortDateString();

            return retVal;
        }
        const long pdfExportToolID = 42;
        private void FPreviewAR_Load(object sender, EventArgs e)
        {
           // var zoomOutButton = viewer1.TouchModeToolbar.ToolStrip.Items[8];
            //zoomOutButton.Visible = true;

        }

        private void c1Button1_Click(object sender, EventArgs e)        //*************************************Added 6/25/15******MZ
        {
            GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport PDFEx = new GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport();


            //FPreviewAR pv = new FPreviewAR();
            //rprtBudgetDetail rprt = new rprtBudgetDetail();
            //DataSet ds;
            //CBBudget bud = new CBBudget();
            //CBProject proj = new CBProject();
            //CBCustomer cust = new CBCustomer();
            //CBLocation loc = new CBLocation();
            //CBState state = new CBState();

            ////bud.Load(budID);
            //proj.Load(bud.ProjectID);
            //cust.Load(proj.CustomerID);
            //loc.Load(proj.LocationID);
            //state.Load(loc.StateID);
           
                     
           
      //      MessageBox.Show(projNumber);
            //MessageBox.Show(pcnNumber);
           MessageBox.Show(reportType);
           //MessageBox.Show(BusinessUnit);
        //    MessageBox.Show(ForeCastTitle);
         

           // MessageBox.Show(fileName);
            Report_Name = CreateFileNAme();
            SaveFileDialog sv1 = new SaveFileDialog();
            // sv1.InitialDirectory = "c:\\MZ\\";
            sv1.InitialDirectory = "v:\\HGA\\";

          
            sv1.FileName = Report_Name;
            sv1.Filter = "PDF Files | *.pdf";
            sv1.DefaultExt = "pdf";

           


            if (sv1.ShowDialog() == DialogResult.OK)
            {
                viewer1.Export(PDFEx, new System.IO.FileInfo(sv1.FileName));
                //PDFEx.Export(rprt.Document, sv1.FileName);


            }


        }

        public string Report_Name;
        public string deptXml; public string projXml; public string xml; public string leadXml; 
        public bool isPreview; public int sortCode; public int drwgSpec;
        public string name_of_Method;
       
        private void bttExportExcel_Click(object sender, EventArgs e)
        {
            CDrawingLogExport DrEx = new CDrawingLogExport();

            SaveFileDialog sv2 = new SaveFileDialog();
            Report_Name = CreateFileNAme();
            sv2.FileName = Report_Name;
            sv2.Filter = "XLS Files | *.xls";
            sv2.DefaultExt = "xls";
          
            if (sv2.ShowDialog() == DialogResult.OK)
            {
              if(name_of_Method =="GetDrawingLogMainByDeptListProjList" )
                   DrEx.ExportBudgetForPrimavera_GetDrawingLogMainByDeptListProjList(sv2.FileName, deptXml, projXml, sortCode, drwgSpec);

                if(name_of_Method =="GetDrawingLogMainByDeptList")
                    DrEx.ExportBudgetForPrimavera_GetDrawingLogMainByDeptList(sv2.FileName, xml, sortCode, drwgSpec);
       
                if(name_of_Method =="GetDrawingLogMainByProjList")
                    DrEx.ExportBudgetForPrimavera_GetDrawingLogMainByProjList(sv2.FileName, xml, sortCode, drwgSpec);
       
                if(name_of_Method =="GetDrawingLogMainByLeadList")
                    DrEx.ExportBudgetForPrimavera_GetDrawingLogMainByLeadList(sv2.FileName, deptXml, leadXml, sortCode, drwgSpec); 




            }
        }


        public string CreateFileNAme() //******************Added / Edited 10/4/2015
        {
            DateTime dt = DateTime.Now;
            string fileName;
            if (reportType == "RSMPS.rprtBudgetDetail")
                fileName = Title + "-" + projNumber + " " + dt.ToString("yyyMMdd hhmmss");

            else
                if (reportType == "RSMPS.rprtPCNMain")
                    fileName = "Project Change Notice-" + projNumber + Title + "-" + "-PCN No-" + pcnNumber + "-" + dt.ToString("yyyMMdd hhmmss");
                else
                    if (reportType == "RSMPS.rprtBudgetSummary1")
                        fileName = Title + "-" + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                    else
                        if (reportType == "GrapeCity.ActiveReports.SectionReport")
                            fileName = "Proposal Budget Detail(All)- " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                        else
                            if (reportType == "RSMPS.rprtBudgetJobStat2")
                                fileName = "Job Stat Data- " + " " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                            else
                                if (reportType == "RSMPS.rprtBudgetAccounting")
                                    fileName = "Budget Entry- " + " " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                                else
                                    if (reportType == "RSMPS.rprtPCIInformation")
                                        fileName = "Project Change Identification- " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                                    else
                                        if (reportType == "RSMPS.rprtJobStat1")
                                            fileName = "Job Stat- " + " " + dt.ToString("yyyMMdd hhmmss"); //******No project No, because there may be many
                                        else
                                            if (reportType == "RSMPS.rprtPCNLog")
                                                fileName = "PCN Log- " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                                            else
                                                if (reportType == "RSMPS.rprtPCILog")
                                                    fileName = "PCI Log- " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                                                else
                                                    if (reportType == "RSMPS.rprtCostSummary")
                                                        fileName = "Cost Summary- " + projNumber + "- " + dt.ToString("yyyMMdd hhmmss");
                                                    else
                                                        if (reportType == "RSMPS.rprtPMReport1")
                                                            fileName = "PM Report- " + " " + dt.ToString("yyyMMdd hhmmss");
                                                        else
                                                            if (reportType == "RSMPS.rprtJobVariance1")
                                                                // fileName = "Job Varience- " + " " + dt.ToString("yyyMMdd hhmmss");
                                                                fileName = Title + "-" + " " + dt.ToString("yyyMMdd hhmmss");
                                                            else
                                                                if (reportType == "RSMPS.rprtDrawingLogTranAlt2")
                                                                    fileName = "Drawing Log- " + " " + dt.ToString("yyyMMdd hhmmss"); //******No project No, because there may be many

                                                                else
                                                                    if (reportType == "RSMPS.rprtForecastRemaining")
                                                                        fileName = Title + "--" + dt.ToString("yyyMMdd hhmmss");
                                                                    else
                                                                        if (reportType == "RSMPS.rprtTravelExpenseDetail")
                                                                            fileName = "Travel Expense(WorkSheet)- " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                                                                        else
                                                                            if (reportType == "RSMPS.rprtTransmittal1")
                                                                                fileName = "Transmittal- " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");
                                                                            else
                                                                                if (reportType == "RSMPS.rprtTransmittalRelease1")
                                                                                    fileName = "Issue Release- " + projNumber + " " + dt.ToString("yyyMMdd hhmmss");

                                                                                else fileName = "Report-" + dt.ToString("yyyMMdd hhmmss");
            return fileName;

        }       



    }
}


	
	