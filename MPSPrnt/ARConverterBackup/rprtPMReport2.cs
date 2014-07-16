using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using System.Data;


namespace RSMPS
{
    public class rprtPMReport2 : DataDynamics.ActiveReports.ActiveReport
	{
        private string msSchedule;
        private string msAct;
        private string msStaffing;

        private int miCount = 0;

		public rprtPMReport2()
		{
			InitializeComponent();
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            rprtPMReportPCN rpcn = new rprtPMReportPCN();
            DataSet ds = CBProjectBudget.GetPCNByProject(Convert.ToInt32(TextBox27.Text), Convert.ToInt32(TextBox28.Text));

            rpcn.DataSource = ds;
            rpcn.DataMember = "Table";
            SubReport.Report = rpcn;

            if (ds.Tables["Table"].Rows.Count < 1)
            {
                Label16.Visible = false;
                Label17.Visible = false;
                Label18.Visible = false;
                Label19.Visible = false;
                Shape1.Visible = false;
            }
            else
            {
                Label16.Visible = true;
                Label17.Visible = true;
                Label18.Visible = true;
                Label19.Visible = true;
                Shape1.Visible = true;
            }

			// get cost summary
            LoadForecast(TextBox26.Text);

            msSchedule = txtSchedule.Value.ToString();
            msAct = txtActivities.Value.ToString();
            msStaffing = txtStaffing.Value.ToString();

            miCount++;
		}

        private void LoadForecast(string proj)
        {
            DataSet ds;
            CBProject p = new CBProject();
            p.Load(proj);

            if (p.IsMaster == true)
            {
                CRolllups ru = new CRolllups();
                ds = ru.LoadReportForProjectRollup(proj, CPBudget.GetRprtCase(proj));
            }
            else
            {
                ds = CBProjectBudget.GetCostReport(proj, CPBudget.GetRprtCase(proj), p.IsMaster);
            }

            //SSS 20131104 decimal tmp1, tmp2;
            decimal tmp1;
            decimal cbEngHrs, cbLabor, cbDlrMH, cbExpenses, cbTotal;
            decimal spEngHrs, spLabor, spDlrMH, spExpenses, spTotal;
            decimal tcEngHrs, tcLabor, tcDlrMH, tcExpenses, tcTotal;
            decimal ftEngHrs, ftLabor, ftDlrMH, ftExpenses, ftTotal;
            decimal ouEngHrs, ouLabor;
            decimal ouExpenses, ouTotal;

            decimal tmpBud, tmpCost;

            cbEngHrs = 0;
            cbLabor = 0;
            cbDlrMH = 0;
            cbExpenses = 0;
            cbTotal = 0;

            spEngHrs = 0;
            spLabor = 0;
            spDlrMH = 0;
            spExpenses = 0;
            spTotal = 0;

            tcEngHrs = 0;
            tcLabor = 0;
            tcDlrMH = 0;
            tcExpenses = 0;
            tcTotal = 0;

            ftEngHrs = 0;
            ftLabor = 0;
            ftDlrMH = 0;
            ftExpenses = 0;
            ftTotal = 0;

            ouEngHrs = 0;
            ouLabor = 0;
            ouExpenses = 0;
            ouTotal = 0;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbEngHrs += Convert.ToDecimal(dr["BudgetHrs"]);
                cbLabor += Convert.ToDecimal(dr["BudgetDlrs"]);
                spEngHrs += Convert.ToDecimal(dr["ActualTime"]);
                spLabor += Convert.ToDecimal(dr["ActualAmnt"]);

                tmp1 = Convert.ToDecimal(dr["FTCHrs"]);
                //SSS 20131104 tmp2 = 0;

                if (tmp1 >= 0)
                {
                    if (Convert.ToDecimal(dr["ActualTime"]) > Convert.ToDecimal(dr["FTCHrs"]))
                        ftEngHrs += Convert.ToDecimal(dr["ActualTime"]);
                    else
                        ftEngHrs += Convert.ToDecimal(dr["FTCHrs"]);
                }
                else
                {
                    if (Convert.ToDecimal(dr["BudgetHrs"]) < Convert.ToDecimal(dr["ActualTime"]))
                    {
                        ftEngHrs += Convert.ToDecimal(dr["ActualTime"]);
                    }
                    else
                    {
                        ftEngHrs += Convert.ToDecimal(dr["BudgetHrs"]);
                    }
                }

                tmp1 = Convert.ToDecimal(dr["FTCAmnt"]);

                if (tmp1 >= 0)
                {
                    if (Convert.ToDecimal(dr["ActualAmnt"]) > Convert.ToDecimal(dr["FTCAmnt"]))
                        ftLabor += Convert.ToDecimal(dr["ActualAmnt"]);
                    else 
                        ftLabor += Convert.ToDecimal(dr["FTCAmnt"]);
                }
                else
                {
                    if (Convert.ToDecimal(dr["BudgetDlrs"]) < Convert.ToDecimal(dr["ActualAmnt"]))
                    {
                        ftLabor += Convert.ToDecimal(dr["ActualAmnt"]);
                    }
                    else
                    {
                        ftLabor += Convert.ToDecimal(dr["BudgetDlrs"]);
                    }
                }
            }

            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                tmpBud = Convert.ToDecimal(dr["budget"]);
                tmpCost = Convert.ToDecimal(dr["costs"]);

                cbExpenses += tmpBud;
                spExpenses += tmpCost;

                tmp1 = Convert.ToDecimal(dr["ForecastAmnt"]);

                if (tmp1 <= -9998)
                {
                    if (tmp1 < -250000)
                    {
                        ftExpenses += tmpCost;
                        tcExpenses += 0;
                    }
                    else if (tmpCost > tmpBud)
                    {
                        ftExpenses += tmpCost;
                        tcExpenses += 0;
                    }
                    else if (tmpCost < 0)
                    {
                        ftExpenses += tmpBud - tmpCost;
                        tcExpenses += 0;
                    }
                    else
                    {
                        ftExpenses += tmpBud;
                        tcExpenses += tmpBud - tmpCost;
                    }
                }
                else
                {
                    //if (tmpCost >= tmp1)
                    //SSS 20131029 Calculation Bug
                    if (tmpCost > tmp1)
                    {
                        if (tmpCost > tmpBud)
                        {
                            ftExpenses += tmpCost;
                            tcExpenses += 0;
                        }
                        else
                        {
                            ftExpenses += tmpBud;
                            tcExpenses += tmpBud - tmpCost;
                        }
                    }
                    else
                    {
                        ftExpenses += tmp1;
                        tcExpenses += tmp1 - tmpCost;
                    }
                }
            }


            tcEngHrs = ftEngHrs - spEngHrs;
            tcLabor = ftLabor - spLabor;
           // tcExpenses = ftExpenses - spExpenses;

            cbTotal = cbLabor + cbExpenses;
            spTotal = spLabor + spExpenses;
            tcTotal = tcLabor + tcExpenses;
            ftTotal = ftLabor + ftExpenses;

            ouEngHrs = ftEngHrs - cbEngHrs;
            ouLabor = ftLabor - cbLabor;
            ouExpenses = ftExpenses - cbExpenses;
            ouTotal = ftTotal - cbTotal;

            if (cbEngHrs != 0)
                cbDlrMH = cbLabor / cbEngHrs;
            else
                cbDlrMH = 0;

            if (spEngHrs != 0)
                spDlrMH = spLabor / spEngHrs;
            else
                spDlrMH = 0;

            if (tcEngHrs != 0)
                tcDlrMH = tcLabor / tcEngHrs;
            else
                tcDlrMH = 0;

            if (ftEngHrs != 0)
                ftDlrMH = ftLabor / ftEngHrs;
            else
                ftDlrMH = 0;


            // load the grid
            TextBox1.Text = cbEngHrs.ToString("#,##0");
            TextBox2.Text = cbLabor.ToString("$#,##0");
            TextBox3.Text = cbDlrMH.ToString("$#,##0.00");
            TextBox4.Text = cbExpenses.ToString("$#,##0");
            TextBox5.Text = cbTotal.ToString("$#,##0");

            TextBox6.Text = spEngHrs.ToString("#,##0");
            TextBox7.Text = spLabor.ToString("$#,##0");
            TextBox8.Text = spDlrMH.ToString("$#,##0.00");
            TextBox9.Text = spExpenses.ToString("$#,##0");
            TextBox10.Text = spTotal.ToString("$#,##0");

            TextBox11.Text = tcEngHrs.ToString("#,##0");
            TextBox12.Text = tcLabor.ToString("$#,##0");
            TextBox13.Text = tcDlrMH.ToString("$#,##0.00");
            TextBox14.Text = tcExpenses.ToString("$#,##0");
            TextBox15.Text = tcTotal.ToString("$#,##0");

            TextBox16.Text = ftEngHrs.ToString("#,##0");
            TextBox17.Text = ftLabor.ToString("$#,##0");
            TextBox18.Text = ftDlrMH.ToString("$#,##0.00");
            TextBox19.Text = ftExpenses.ToString("$#,##0");
            TextBox20.Text = ftTotal.ToString("$#,##0");

            TextBox21.Text = ouEngHrs.ToString("#,##0;(#,##0)");
            if (ouEngHrs <= 0)
                TextBox21.ForeColor = System.Drawing.Color.Black;
            else
                TextBox21.ForeColor = System.Drawing.Color.Red;

            TextBox22.Text = ouLabor.ToString("$#,##0;($#,##0)");
            if (ouLabor <= 0)
                TextBox22.ForeColor = System.Drawing.Color.Black;
            else
                TextBox22.ForeColor = System.Drawing.Color.Red;

            TextBox23.Text = "";
            TextBox24.Text = ouExpenses.ToString("$#,##0;($#,##0)");
            if (ouExpenses <= 0)
                TextBox24.ForeColor = System.Drawing.Color.Black;
            else
                TextBox24.ForeColor = System.Drawing.Color.Red;

            TextBox25.Text = ouTotal.ToString("$#,##0;($#,##0)");
            if (ouTotal <= 0)
                TextBox25.ForeColor = System.Drawing.Color.Black;
            else
                TextBox25.ForeColor = System.Drawing.Color.Red;



            DateTime tmpDate = DateTime.Now;
            DateTime dataDate;
            int weekDay;

            weekDay = (-1) * (int)tmpDate.DayOfWeek;
            dataDate = tmpDate.AddDays(weekDay);

            lblWeekEnding.Text = dataDate.ToShortDateString();
        }


		private void GroupFooter1_Format(object sender, System.EventArgs eArgs)
		{
            rtbSchdule.RTF = msSchedule;
            rtbActivities.RTF = msAct;
            rtbStaffing.RTF = msStaffing;
		}

		private void GroupHeader1_Format(object sender, System.EventArgs eArgs)
		{
            if (miCount < 1)
                GroupHeader1.NewPage = NewPage.None;
            else
                GroupHeader1.NewPage = NewPage.Before;
		}

		#region ActiveReports Designer generated code
		public DataDynamics.ActiveReports.DataSources.SqlDBDataSource ds = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.TextBox TextBox = null;
		private DataDynamics.ActiveReports.TextBox TextBox26 = null;
		private DataDynamics.ActiveReports.TextBox TextBox27 = null;
		private DataDynamics.ActiveReports.TextBox TextBox28 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.Shape Shape = null;
		private DataDynamics.ActiveReports.Label Label5 = null;
		private DataDynamics.ActiveReports.Label Label6 = null;
		private DataDynamics.ActiveReports.Label Label7 = null;
		private DataDynamics.ActiveReports.Label Label8 = null;
		private DataDynamics.ActiveReports.Label Label9 = null;
		private DataDynamics.ActiveReports.Label Label10 = null;
		private DataDynamics.ActiveReports.Label Label11 = null;
		private DataDynamics.ActiveReports.Label Label12 = null;
		private DataDynamics.ActiveReports.Label Label13 = null;
		private DataDynamics.ActiveReports.Label Label14 = null;
		private DataDynamics.ActiveReports.Label Label15 = null;
		private DataDynamics.ActiveReports.Line Line = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.Line Line2 = null;
		private DataDynamics.ActiveReports.Line Line3 = null;
		private DataDynamics.ActiveReports.Line Line4 = null;
		private DataDynamics.ActiveReports.Line Line5 = null;
		private DataDynamics.ActiveReports.Line Line6 = null;
		private DataDynamics.ActiveReports.Line Line7 = null;
		private DataDynamics.ActiveReports.Line Line8 = null;
		private DataDynamics.ActiveReports.Line Line9 = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.TextBox TextBox2 = null;
		private DataDynamics.ActiveReports.TextBox TextBox3 = null;
		private DataDynamics.ActiveReports.TextBox TextBox4 = null;
		private DataDynamics.ActiveReports.TextBox TextBox5 = null;
		private DataDynamics.ActiveReports.TextBox TextBox6 = null;
		private DataDynamics.ActiveReports.TextBox TextBox7 = null;
		private DataDynamics.ActiveReports.TextBox TextBox8 = null;
		private DataDynamics.ActiveReports.TextBox TextBox9 = null;
		private DataDynamics.ActiveReports.TextBox TextBox10 = null;
		private DataDynamics.ActiveReports.TextBox TextBox11 = null;
		private DataDynamics.ActiveReports.TextBox TextBox12 = null;
		private DataDynamics.ActiveReports.TextBox TextBox13 = null;
		private DataDynamics.ActiveReports.TextBox TextBox14 = null;
		private DataDynamics.ActiveReports.TextBox TextBox15 = null;
		private DataDynamics.ActiveReports.TextBox TextBox16 = null;
		private DataDynamics.ActiveReports.TextBox TextBox17 = null;
		private DataDynamics.ActiveReports.TextBox TextBox18 = null;
		private DataDynamics.ActiveReports.TextBox TextBox19 = null;
		private DataDynamics.ActiveReports.TextBox TextBox20 = null;
		private DataDynamics.ActiveReports.TextBox TextBox21 = null;
		private DataDynamics.ActiveReports.TextBox TextBox22 = null;
		private DataDynamics.ActiveReports.TextBox TextBox23 = null;
		private DataDynamics.ActiveReports.TextBox TextBox24 = null;
		private DataDynamics.ActiveReports.TextBox TextBox25 = null;
		private DataDynamics.ActiveReports.Label lblWeekEnding = null;
		private DataDynamics.ActiveReports.Label Label20 = null;
		private DataDynamics.ActiveReports.Label Label = null;
		private DataDynamics.ActiveReports.TextBox txtSchedule = null;
		private DataDynamics.ActiveReports.TextBox txtActivities = null;
		private DataDynamics.ActiveReports.TextBox txtStaffing = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.Shape Shape1 = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
		private DataDynamics.ActiveReports.Label Label4 = null;
		private DataDynamics.ActiveReports.SubReport SubReport = null;
		private DataDynamics.ActiveReports.RichTextBox rtbSchdule = null;
		private DataDynamics.ActiveReports.RichTextBox rtbActivities = null;
		private DataDynamics.ActiveReports.RichTextBox rtbStaffing = null;
		private DataDynamics.ActiveReports.Label Label16 = null;
		private DataDynamics.ActiveReports.Label Label17 = null;
		private DataDynamics.ActiveReports.Label Label18 = null;
		private DataDynamics.ActiveReports.Label Label19 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtPMReport2));
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource sqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Shape = new DataDynamics.ActiveReports.Shape();
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.Label9 = new DataDynamics.ActiveReports.Label();
            this.Label10 = new DataDynamics.ActiveReports.Label();
            this.Label11 = new DataDynamics.ActiveReports.Label();
            this.Label12 = new DataDynamics.ActiveReports.Label();
            this.Label13 = new DataDynamics.ActiveReports.Label();
            this.Label14 = new DataDynamics.ActiveReports.Label();
            this.Label15 = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Line6 = new DataDynamics.ActiveReports.Line();
            this.Line7 = new DataDynamics.ActiveReports.Line();
            this.Line8 = new DataDynamics.ActiveReports.Line();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox4 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox5 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox6 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox7 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox8 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox9 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox10 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox11 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox12 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox13 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox14 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox15 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox16 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox19 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox21 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox22 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox23 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox24 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox25 = new DataDynamics.ActiveReports.TextBox();
            this.lblWeekEnding = new DataDynamics.ActiveReports.Label();
            this.Label20 = new DataDynamics.ActiveReports.Label();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.txtSchedule = new DataDynamics.ActiveReports.TextBox();
            this.txtActivities = new DataDynamics.ActiveReports.TextBox();
            this.txtStaffing = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TextBox26 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox27 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox28 = new DataDynamics.ActiveReports.TextBox();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.Shape1 = new DataDynamics.ActiveReports.Shape();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.SubReport = new DataDynamics.ActiveReports.SubReport();
            this.rtbSchdule = new DataDynamics.ActiveReports.RichTextBox();
            this.rtbActivities = new DataDynamics.ActiveReports.RichTextBox();
            this.rtbStaffing = new DataDynamics.ActiveReports.RichTextBox();
            this.Label16 = new DataDynamics.ActiveReports.Label();
            this.Label17 = new DataDynamics.ActiveReports.Label();
            this.Label18 = new DataDynamics.ActiveReports.Label();
            this.Label19 = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeekEnding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStaffing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Shape,
            this.Label5,
            this.Label6,
            this.Label7,
            this.Label8,
            this.Label9,
            this.Label10,
            this.Label11,
            this.Label12,
            this.Label13,
            this.Label14,
            this.Label15,
            this.Line,
            this.Line1,
            this.Line2,
            this.Line3,
            this.Line4,
            this.Line5,
            this.Line6,
            this.Line7,
            this.Line8,
            this.Line9,
            this.TextBox1,
            this.TextBox2,
            this.TextBox3,
            this.TextBox4,
            this.TextBox5,
            this.TextBox6,
            this.TextBox7,
            this.TextBox8,
            this.TextBox9,
            this.TextBox10,
            this.TextBox11,
            this.TextBox12,
            this.TextBox13,
            this.TextBox14,
            this.TextBox15,
            this.TextBox16,
            this.TextBox17,
            this.TextBox18,
            this.TextBox19,
            this.TextBox20,
            this.TextBox21,
            this.TextBox22,
            this.TextBox23,
            this.TextBox24,
            this.TextBox25,
            this.lblWeekEnding,
            this.Label20,
            this.Label,
            this.txtSchedule,
            this.txtActivities,
            this.txtStaffing});
            this.Detail.Height = 1.989583F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // Shape
            // 
            this.Shape.Height = 1.5625F;
            this.Shape.Left = 0.5F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Top = 0.375F;
            this.Shape.Width = 6.625F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 0.5625F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "font-family: Times New Roman; font-size: 9.75pt; font-weight: bold";
            this.Label5.Text = "Week Ending";
            this.Label5.Top = 0.375F;
            this.Label5.Width = 1F;
            // 
            // Label6
            // 
            this.Label6.Height = 0.2F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 0.5625F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "font-family: Times New Roman; font-size: 9.75pt; font-weight: bold";
            this.Label6.Text = "Engineering Workhours";
            this.Label6.Top = 0.8125F;
            this.Label6.Width = 1.5F;
            // 
            // Label7
            // 
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = null;
            this.Label7.Left = 0.5625F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "font-family: Times New Roman; font-size: 9.75pt; font-weight: bold";
            this.Label7.Text = "Labor Cost";
            this.Label7.Top = 1.046875F;
            this.Label7.Width = 1.5F;
            // 
            // Label8
            // 
            this.Label8.Height = 0.2F;
            this.Label8.HyperLink = null;
            this.Label8.Left = 0.5625F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "font-family: Times New Roman; font-size: 9.75pt; font-weight: bold";
            this.Label8.Text = "$/MH";
            this.Label8.Top = 1.28125F;
            this.Label8.Width = 1.5F;
            // 
            // Label9
            // 
            this.Label9.Height = 0.2F;
            this.Label9.HyperLink = null;
            this.Label9.Left = 0.5625F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "font-family: Times New Roman; font-size: 9.75pt; font-weight: bold";
            this.Label9.Text = "Expenses";
            this.Label9.Top = 1.515625F;
            this.Label9.Width = 1.5F;
            // 
            // Label10
            // 
            this.Label10.Height = 0.2F;
            this.Label10.HyperLink = null;
            this.Label10.Left = 0.5625F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "font-family: Times New Roman; font-size: 9.75pt; font-weight: bold";
            this.Label10.Text = "Project Total";
            this.Label10.Top = 1.75F;
            this.Label10.Width = 1.5F;
            // 
            // Label11
            // 
            this.Label11.Height = 0.2F;
            this.Label11.HyperLink = null;
            this.Label11.Left = 2.0625F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "font-family: Times New Roman; font-size: 9.75pt; font-weight: bold; text-align: c" +
    "enter";
            this.Label11.Text = "Current Budget";
            this.Label11.Top = 0.4375F;
            this.Label11.Width = 1F;
            // 
            // Label12
            // 
            this.Label12.Height = 0.2F;
            this.Label12.HyperLink = null;
            this.Label12.Left = 3.0625F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "font-family: Times New Roman; font-size: 9.75pt; font-weight: bold; text-align: c" +
    "enter";
            this.Label12.Text = "Spent to Date";
            this.Label12.Top = 0.4375F;
            this.Label12.Width = 1F;
            // 
            // Label13
            // 
            this.Label13.Height = 0.2F;
            this.Label13.HyperLink = null;
            this.Label13.Left = 4.0625F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "font-family: Times New Roman; font-size: 9.75pt; font-weight: bold; text-align: c" +
    "enter";
            this.Label13.Text = "To Complete";
            this.Label13.Top = 0.4375F;
            this.Label13.Width = 1F;
            // 
            // Label14
            // 
            this.Label14.Height = 0.2F;
            this.Label14.HyperLink = null;
            this.Label14.Left = 5.0625F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "font-family: Times New Roman; font-size: 9.75pt; font-weight: bold; text-align: c" +
    "enter";
            this.Label14.Text = "Forecast Total";
            this.Label14.Top = 0.4375F;
            this.Label14.Width = 1F;
            // 
            // Label15
            // 
            this.Label15.Height = 0.2F;
            this.Label15.HyperLink = null;
            this.Label15.Left = 6.5F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "font-family: Times New Roman; font-size: 9.75pt; font-weight: bold; text-align: c" +
    "enter";
            this.Label15.Text = "/(Under)";
            this.Label15.Top = 0.4375F;
            this.Label15.Width = 0.5625F;
            // 
            // Line
            // 
            this.Line.Height = 0F;
            this.Line.Left = 0.5F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0.75F;
            this.Line.Width = 6.625F;
            this.Line.X1 = 0.5F;
            this.Line.X2 = 7.125F;
            this.Line.Y1 = 0.75F;
            this.Line.Y2 = 0.75F;
            // 
            // Line1
            // 
            this.Line1.Height = 0F;
            this.Line1.Left = 0.5F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.0225F;
            this.Line1.Width = 6.625F;
            this.Line1.X1 = 0.5F;
            this.Line1.X2 = 7.125F;
            this.Line1.Y1 = 1.0225F;
            this.Line1.Y2 = 1.0225F;
            // 
            // Line2
            // 
            this.Line2.Height = 0F;
            this.Line2.Left = 0.5F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 1.2425F;
            this.Line2.Width = 6.625F;
            this.Line2.X1 = 0.5F;
            this.Line2.X2 = 7.125F;
            this.Line2.Y1 = 1.2425F;
            this.Line2.Y2 = 1.2425F;
            // 
            // Line3
            // 
            this.Line3.Height = 0F;
            this.Line3.Left = 0.5F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 1.4925F;
            this.Line3.Width = 6.625F;
            this.Line3.X1 = 0.5F;
            this.Line3.X2 = 7.125F;
            this.Line3.Y1 = 1.4925F;
            this.Line3.Y2 = 1.4925F;
            // 
            // Line4
            // 
            this.Line4.Height = 0F;
            this.Line4.Left = 0.5F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 1.7325F;
            this.Line4.Width = 6.625F;
            this.Line4.X1 = 0.5F;
            this.Line4.X2 = 7.125F;
            this.Line4.Y1 = 1.7325F;
            this.Line4.Y2 = 1.7325F;
            // 
            // Line5
            // 
            this.Line5.Height = 1.5625F;
            this.Line5.Left = 2.0625F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0.375F;
            this.Line5.Width = 0F;
            this.Line5.X1 = 2.0625F;
            this.Line5.X2 = 2.0625F;
            this.Line5.Y1 = 0.375F;
            this.Line5.Y2 = 1.9375F;
            // 
            // Line6
            // 
            this.Line6.Height = 1.5625F;
            this.Line6.Left = 3.0625F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 0.375F;
            this.Line6.Width = 0F;
            this.Line6.X1 = 3.0625F;
            this.Line6.X2 = 3.0625F;
            this.Line6.Y1 = 0.375F;
            this.Line6.Y2 = 1.9375F;
            // 
            // Line7
            // 
            this.Line7.Height = 1.5625F;
            this.Line7.Left = 4.0625F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 0.375F;
            this.Line7.Width = 0F;
            this.Line7.X1 = 4.0625F;
            this.Line7.X2 = 4.0625F;
            this.Line7.Y1 = 0.375F;
            this.Line7.Y2 = 1.9375F;
            // 
            // Line8
            // 
            this.Line8.Height = 1.5625F;
            this.Line8.Left = 5.0625F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 0.375F;
            this.Line8.Width = 0F;
            this.Line8.X1 = 5.0625F;
            this.Line8.X2 = 5.0625F;
            this.Line8.Y1 = 0.375F;
            this.Line8.Y2 = 1.9375F;
            // 
            // Line9
            // 
            this.Line9.Height = 1.5625F;
            this.Line9.Left = 6.0625F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0.375F;
            this.Line9.Width = 0F;
            this.Line9.X1 = 6.0625F;
            this.Line9.X2 = 6.0625F;
            this.Line9.Y1 = 0.375F;
            this.Line9.Y2 = 1.9375F;
            // 
            // TextBox1
            // 
            this.TextBox1.Height = 0.2F;
            this.TextBox1.Left = 2.125F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox1.Text = "TextBox1";
            this.TextBox1.Top = 0.8125F;
            this.TextBox1.Width = 0.875F;
            // 
            // TextBox2
            // 
            this.TextBox2.Height = 0.2F;
            this.TextBox2.Left = 2.125F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox2.Text = "TextBox1";
            this.TextBox2.Top = 1.046875F;
            this.TextBox2.Width = 0.875F;
            // 
            // TextBox3
            // 
            this.TextBox3.Height = 0.2F;
            this.TextBox3.Left = 2.125F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox3.Text = "TextBox1";
            this.TextBox3.Top = 1.28125F;
            this.TextBox3.Width = 0.875F;
            // 
            // TextBox4
            // 
            this.TextBox4.Height = 0.2F;
            this.TextBox4.Left = 2.125F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox4.Text = "TextBox1";
            this.TextBox4.Top = 1.515625F;
            this.TextBox4.Width = 0.875F;
            // 
            // TextBox5
            // 
            this.TextBox5.Height = 0.2F;
            this.TextBox5.Left = 2.125F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox5.Text = "TextBox1";
            this.TextBox5.Top = 1.75F;
            this.TextBox5.Width = 0.875F;
            // 
            // TextBox6
            // 
            this.TextBox6.Height = 0.2F;
            this.TextBox6.Left = 3.125F;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox6.Text = "TextBox1";
            this.TextBox6.Top = 0.8125F;
            this.TextBox6.Width = 0.875F;
            // 
            // TextBox7
            // 
            this.TextBox7.Height = 0.2F;
            this.TextBox7.Left = 3.125F;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox7.Text = "TextBox1";
            this.TextBox7.Top = 1.046875F;
            this.TextBox7.Width = 0.875F;
            // 
            // TextBox8
            // 
            this.TextBox8.Height = 0.2F;
            this.TextBox8.Left = 3.125F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox8.Text = "TextBox1";
            this.TextBox8.Top = 1.28125F;
            this.TextBox8.Width = 0.875F;
            // 
            // TextBox9
            // 
            this.TextBox9.Height = 0.2F;
            this.TextBox9.Left = 3.125F;
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox9.Text = "TextBox1";
            this.TextBox9.Top = 1.516F;
            this.TextBox9.Width = 0.875F;
            // 
            // TextBox10
            // 
            this.TextBox10.Height = 0.2F;
            this.TextBox10.Left = 3.125F;
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox10.Text = "TextBox1";
            this.TextBox10.Top = 1.75F;
            this.TextBox10.Width = 0.875F;
            // 
            // TextBox11
            // 
            this.TextBox11.Height = 0.2F;
            this.TextBox11.Left = 4.125F;
            this.TextBox11.Name = "TextBox11";
            this.TextBox11.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox11.Text = "TextBox1";
            this.TextBox11.Top = 0.8125F;
            this.TextBox11.Width = 0.875F;
            // 
            // TextBox12
            // 
            this.TextBox12.Height = 0.2F;
            this.TextBox12.Left = 4.125F;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox12.Text = "TextBox1";
            this.TextBox12.Top = 1.046875F;
            this.TextBox12.Width = 0.875F;
            // 
            // TextBox13
            // 
            this.TextBox13.Height = 0.2F;
            this.TextBox13.Left = 4.125F;
            this.TextBox13.Name = "TextBox13";
            this.TextBox13.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox13.Text = "TextBox1";
            this.TextBox13.Top = 1.28125F;
            this.TextBox13.Width = 0.875F;
            // 
            // TextBox14
            // 
            this.TextBox14.Height = 0.2F;
            this.TextBox14.Left = 4.125F;
            this.TextBox14.Name = "TextBox14";
            this.TextBox14.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox14.Text = "TextBox1";
            this.TextBox14.Top = 1.515625F;
            this.TextBox14.Width = 0.875F;
            // 
            // TextBox15
            // 
            this.TextBox15.Height = 0.2F;
            this.TextBox15.Left = 4.125F;
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox15.Text = "TextBox1";
            this.TextBox15.Top = 1.75F;
            this.TextBox15.Width = 0.875F;
            // 
            // TextBox16
            // 
            this.TextBox16.Height = 0.2F;
            this.TextBox16.Left = 5.125F;
            this.TextBox16.Name = "TextBox16";
            this.TextBox16.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox16.Text = "TextBox1";
            this.TextBox16.Top = 0.8125F;
            this.TextBox16.Width = 0.875F;
            // 
            // TextBox17
            // 
            this.TextBox17.Height = 0.2F;
            this.TextBox17.Left = 5.125F;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox17.Text = "TextBox1";
            this.TextBox17.Top = 1.046875F;
            this.TextBox17.Width = 0.875F;
            // 
            // TextBox18
            // 
            this.TextBox18.Height = 0.2F;
            this.TextBox18.Left = 5.125F;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox18.Text = "TextBox1";
            this.TextBox18.Top = 1.28125F;
            this.TextBox18.Width = 0.875F;
            // 
            // TextBox19
            // 
            this.TextBox19.Height = 0.2F;
            this.TextBox19.Left = 5.125F;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox19.Text = "TextBox1";
            this.TextBox19.Top = 1.515625F;
            this.TextBox19.Width = 0.875F;
            // 
            // TextBox20
            // 
            this.TextBox20.Height = 0.2F;
            this.TextBox20.Left = 5.125F;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox20.Text = "TextBox1";
            this.TextBox20.Top = 1.75F;
            this.TextBox20.Width = 0.875F;
            // 
            // TextBox21
            // 
            this.TextBox21.Height = 0.2F;
            this.TextBox21.Left = 6.125F;
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.OutputFormat = resources.GetString("TextBox21.OutputFormat");
            this.TextBox21.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox21.Text = "TextBox1";
            this.TextBox21.Top = 0.8125F;
            this.TextBox21.Width = 0.875F;
            // 
            // TextBox22
            // 
            this.TextBox22.Height = 0.2F;
            this.TextBox22.Left = 6.125F;
            this.TextBox22.Name = "TextBox22";
            this.TextBox22.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox22.Text = "TextBox1";
            this.TextBox22.Top = 1.046875F;
            this.TextBox22.Width = 0.875F;
            // 
            // TextBox23
            // 
            this.TextBox23.Height = 0.2F;
            this.TextBox23.Left = 6.125F;
            this.TextBox23.Name = "TextBox23";
            this.TextBox23.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox23.Text = "TextBox1";
            this.TextBox23.Top = 1.28125F;
            this.TextBox23.Width = 0.875F;
            // 
            // TextBox24
            // 
            this.TextBox24.Height = 0.2F;
            this.TextBox24.Left = 6.125F;
            this.TextBox24.Name = "TextBox24";
            this.TextBox24.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox24.Text = "TextBox1";
            this.TextBox24.Top = 1.515625F;
            this.TextBox24.Width = 0.875F;
            // 
            // TextBox25
            // 
            this.TextBox25.Height = 0.2F;
            this.TextBox25.Left = 6.125F;
            this.TextBox25.Name = "TextBox25";
            this.TextBox25.Style = "font-family: Times New Roman; font-size: 9.75pt; text-align: right";
            this.TextBox25.Text = "TextBox1";
            this.TextBox25.Top = 1.75F;
            this.TextBox25.Width = 0.875F;
            // 
            // lblWeekEnding
            // 
            this.lblWeekEnding.Height = 0.2F;
            this.lblWeekEnding.HyperLink = null;
            this.lblWeekEnding.Left = 0.5625F;
            this.lblWeekEnding.Name = "lblWeekEnding";
            this.lblWeekEnding.Style = "font-family: Times New Roman; font-size: 9.75pt; font-weight: bold";
            this.lblWeekEnding.Text = "00/00/00";
            this.lblWeekEnding.Top = 0.5625F;
            this.lblWeekEnding.Width = 1F;
            // 
            // Label20
            // 
            this.Label20.Height = 0.2F;
            this.Label20.HyperLink = null;
            this.Label20.Left = 6.1875F;
            this.Label20.Name = "Label20";
            this.Label20.Style = "color: Red; font-family: Times New Roman; font-size: 9.75pt; font-weight: bold; t" +
    "ext-align: center";
            this.Label20.Text = "Over";
            this.Label20.Top = 0.4375F;
            this.Label20.Width = 0.375F;
            // 
            // Label
            // 
            this.Label.Height = 0.25F;
            this.Label.HyperLink = null;
            this.Label.Left = 0.3125F;
            this.Label.Name = "Label";
            this.Label.Style = "font-family: Times New Roman; font-size: 12pt; font-weight: bold";
            this.Label.Text = "-  Cost Summary";
            this.Label.Top = 0.0625F;
            this.Label.Width = 2.75F;
            // 
            // txtSchedule
            // 
            this.txtSchedule.DataField = "Schedule";
            this.txtSchedule.Height = 0.2F;
            this.txtSchedule.Left = 3.1875F;
            this.txtSchedule.Name = "txtSchedule";
            this.txtSchedule.Text = "TextBox29";
            this.txtSchedule.Top = 0.0625F;
            this.txtSchedule.Visible = false;
            this.txtSchedule.Width = 1F;
            // 
            // txtActivities
            // 
            this.txtActivities.DataField = "ActHigh";
            this.txtActivities.Height = 0.2F;
            this.txtActivities.Left = 4.3125F;
            this.txtActivities.Name = "txtActivities";
            this.txtActivities.Text = "TextBox30";
            this.txtActivities.Top = 0.0625F;
            this.txtActivities.Visible = false;
            this.txtActivities.Width = 1F;
            // 
            // txtStaffing
            // 
            this.txtStaffing.DataField = "StaffNeeds";
            this.txtStaffing.Height = 0.2F;
            this.txtStaffing.Left = 5.4375F;
            this.txtStaffing.Name = "txtStaffing";
            this.txtStaffing.Text = "TextBox31";
            this.txtStaffing.Top = 0.0625F;
            this.txtStaffing.Visible = false;
            this.txtStaffing.Width = 1F;
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox,
            this.TextBox26,
            this.TextBox27,
            this.TextBox28});
            this.GroupHeader1.DataField = "Number";
            this.GroupHeader1.Height = 0.28125F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.GroupHeader1.Format += new System.EventHandler(this.GroupHeader1_Format);
            // 
            // TextBox
            // 
            this.TextBox.DataField = "Project";
            this.TextBox.Height = 0.25F;
            this.TextBox.Left = 0F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "font-family: Times New Roman; font-size: 12pt; font-weight: bold";
            this.TextBox.Text = "TextBox";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 7.125F;
            // 
            // TextBox26
            // 
            this.TextBox26.DataField = "Number";
            this.TextBox26.Height = 0.2F;
            this.TextBox26.Left = 3.875F;
            this.TextBox26.Name = "TextBox26";
            this.TextBox26.Text = "TextBox26";
            this.TextBox26.Top = 0.0625F;
            this.TextBox26.Visible = false;
            this.TextBox26.Width = 1F;
            // 
            // TextBox27
            // 
            this.TextBox27.DataField = "ProjSumID";
            this.TextBox27.Height = 0.2F;
            this.TextBox27.Left = 5.0625F;
            this.TextBox27.Name = "TextBox27";
            this.TextBox27.Text = "TextBox27";
            this.TextBox27.Top = 0.1875F;
            this.TextBox27.Visible = false;
            this.TextBox27.Width = 1F;
            // 
            // TextBox28
            // 
            this.TextBox28.DataField = "ProjectID";
            this.TextBox28.Height = 0.2F;
            this.TextBox28.Left = 6.1875F;
            this.TextBox28.Name = "TextBox28";
            this.TextBox28.Text = "TextBox28";
            this.TextBox28.Top = 0.1875F;
            this.TextBox28.Visible = false;
            this.TextBox28.Width = 1F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Shape1,
            this.Label1,
            this.Label2,
            this.Label3,
            this.Label4,
            this.SubReport,
            this.rtbSchdule,
            this.rtbActivities,
            this.rtbStaffing,
            this.Label16,
            this.Label17,
            this.Label18,
            this.Label19});
            this.GroupFooter1.Height = 3.25F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // Shape1
            // 
            this.Shape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape1.Height = 0.25F;
            this.Shape1.Left = 0.6875F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 0.375F;
            this.Shape1.Width = 6.063001F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0.3125F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-family: Times New Roman; font-size: 12pt; font-weight: bold";
            this.Label1.Text = "-  Pending PCN\'s";
            this.Label1.Top = 0.0625F;
            this.Label1.Width = 3.5625F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.25F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0.3125F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-family: Times New Roman; font-size: 12pt; font-weight: bold";
            this.Label2.Text = "-  Schedule";
            this.Label2.Top = 0.8125F;
            this.Label2.Width = 3.5625F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.25F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0.3125F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-family: Times New Roman; font-size: 12pt; font-weight: bold";
            this.Label3.Text = "-  Activities / Highlights";
            this.Label3.Top = 1.625F;
            this.Label3.Width = 3.5625F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.25F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 0.3125F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "font-family: Times New Roman; font-size: 12pt; font-weight: bold";
            this.Label4.Text = "-  Staffing Issues / Needs / Concerns";
            this.Label4.Top = 2.4375F;
            this.Label4.Width = 3.5625F;
            // 
            // SubReport
            // 
            this.SubReport.CloseBorder = false;
            this.SubReport.Height = 0.0625F;
            this.SubReport.Left = 0.6875F;
            this.SubReport.Name = "SubReport";
            this.SubReport.Report = null;
            this.SubReport.Top = 0.625F;
            this.SubReport.Width = 6.4375F;
            // 
            // rtbSchdule
            // 
            this.rtbSchdule.AutoReplaceFields = true;
            this.rtbSchdule.CanShrink = true;
            this.rtbSchdule.Font = new System.Drawing.Font("Arial", 10F);
            this.rtbSchdule.Height = 0.3125F;
            this.rtbSchdule.Left = 0.6875F;
            this.rtbSchdule.Name = "rtbSchdule";
            this.rtbSchdule.RTF = resources.GetString("rtbSchdule.RTF");
            this.rtbSchdule.Top = 1.125F;
            this.rtbSchdule.Width = 6.4375F;
            // 
            // rtbActivities
            // 
            this.rtbActivities.AutoReplaceFields = true;
            this.rtbActivities.CanShrink = true;
            this.rtbActivities.Font = new System.Drawing.Font("Arial", 10F);
            this.rtbActivities.Height = 0.3125F;
            this.rtbActivities.Left = 0.6875F;
            this.rtbActivities.Name = "rtbActivities";
            this.rtbActivities.RTF = resources.GetString("rtbActivities.RTF");
            this.rtbActivities.Top = 1.9375F;
            this.rtbActivities.Width = 6.4375F;
            // 
            // rtbStaffing
            // 
            this.rtbStaffing.AutoReplaceFields = true;
            this.rtbStaffing.CanShrink = true;
            this.rtbStaffing.Font = new System.Drawing.Font("Arial", 10F);
            this.rtbStaffing.Height = 0.3125F;
            this.rtbStaffing.Left = 0.6875F;
            this.rtbStaffing.Name = "rtbStaffing";
            this.rtbStaffing.RTF = resources.GetString("rtbStaffing.RTF");
            this.rtbStaffing.Top = 2.75F;
            this.rtbStaffing.Width = 6.4375F;
            // 
            // Label16
            // 
            this.Label16.Height = 0.2F;
            this.Label16.HyperLink = null;
            this.Label16.Left = 0.75F;
            this.Label16.Name = "Label16";
            this.Label16.Style = "font-size: 9.75pt; font-weight: bold";
            this.Label16.Text = "PCN No.";
            this.Label16.Top = 0.4375F;
            this.Label16.Width = 1F;
            // 
            // Label17
            // 
            this.Label17.Height = 0.2F;
            this.Label17.HyperLink = null;
            this.Label17.Left = 2F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "font-size: 9.75pt; font-weight: bold";
            this.Label17.Text = "Description";
            this.Label17.Top = 0.4375F;
            this.Label17.Width = 1F;
            // 
            // Label18
            // 
            this.Label18.Height = 0.2F;
            this.Label18.HyperLink = null;
            this.Label18.Left = 4.8125F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.Label18.Text = "Hours";
            this.Label18.Top = 0.4375F;
            this.Label18.Width = 1F;
            // 
            // Label19
            // 
            this.Label19.Height = 0.2F;
            this.Label19.HyperLink = null;
            this.Label19.Left = 5.875F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.Label19.Text = "Dollars";
            this.Label19.Top = 0.4375F;
            this.Label19.Width = 0.85F;
            // 
            // rprtPMReport2
            // 
            this.MasterReport = false;
            sqlDBDataSource1.ConnectionString = "data source=REVSOL2\\SQL2005;initial catalog=RSManpowerSchDB;integrated security=S" +
    "SPI;persist security info=False";
            sqlDBDataSource1.SQL = "spRPRT_PMReport1 35";
            this.DataSource = sqlDBDataSource1;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.25F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.25F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.302083F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter1);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeekEnding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStaffing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion
	}
}