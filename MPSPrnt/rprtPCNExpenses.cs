using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtPCNExpenses : GrapeCity.ActiveReports.SectionReport
    {
        public event RevSol.PassDataString OnExpensesTotalled;

        public rprtPCNExpenses()
        {
            InitializeComponent();
        }

        #region ActiveReports Designer generated code



































        private Label label1;
        private TextBox textBox8;

        public void InitializeComponent()
        {
            GrapeCity.ActiveReports.Data.SqlDBDataSource sqlDBDataSource1 = new GrapeCity.ActiveReports.Data.SqlDBDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtPCNExpenses));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.TextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line5 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line6 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line7 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line8 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line9 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line10 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line11 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line12 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.Shape1 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.TextBox7 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line13 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.textBox8 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.TextBox,
            this.TextBox1,
            this.TextBox2,
            this.TextBox3,
            this.TextBox4,
            this.TextBox5,
            this.TextBox6,
            this.Line,
            this.Line5,
            this.Line6,
            this.Line7,
            this.Line8,
            this.Line9,
            this.Line10,
            this.Line11,
            this.Line12});
            this.Detail.Height = 0.2F;
            this.Detail.Name = "Detail";
            // 
            // TextBox
            // 
            this.TextBox.DataField = "Code";
            this.TextBox.Height = 0.2F;
            this.TextBox.Left = 0.05F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Text = "TextBox";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 0.5625F;
            // 
            // TextBox1
            // 
            this.TextBox1.CanGrow = false;
            this.TextBox1.DataField = "Description";
            this.TextBox1.Height = 0.1875F;
            this.TextBox1.Left = 0.625F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Text = "TextBox";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 2.4375F;
            // 
            // TextBox2
            // 
            this.TextBox2.DataField = "DlrsPerItem";
            this.TextBox2.Height = 0.2F;
            this.TextBox2.Left = 2.9F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat");
            this.TextBox2.Style = "text-align: right";
            this.TextBox2.Text = "TextBox";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 1.1F;
            // 
            // TextBox3
            // 
            this.TextBox3.DataField = "NumItems";
            this.TextBox3.Height = 0.2F;
            this.TextBox3.Left = 4F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Style = "text-align: right";
            this.TextBox3.Text = "TextBox";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 0.6F;
            // 
            // TextBox4
            // 
            this.TextBox4.DataField = "MUPerc";
            this.TextBox4.Height = 0.2F;
            this.TextBox4.Left = 4.6F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "text-align: right";
            this.TextBox4.Text = "TextBox";
            this.TextBox4.Top = 0F;
            this.TextBox4.Width = 0.4F;
            // 
            // TextBox5
            // 
            this.TextBox5.DataField = "MarkUp";
            this.TextBox5.Height = 0.2F;
            this.TextBox5.Left = 5F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "text-align: right";
            this.TextBox5.Text = "TextBox";
            this.TextBox5.Top = 0F;
            this.TextBox5.Width = 1F;
            // 
            // TextBox6
            // 
            this.TextBox6.DataField = "TotalCost";
            this.TextBox6.Height = 0.2F;
            this.TextBox6.Left = 6F;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat");
            this.TextBox6.Style = "text-align: right";
            this.TextBox6.Text = "TextBox";
            this.TextBox6.Top = 0F;
            this.TextBox6.Width = 1.18F;
            // 
            // Line
            // 
            this.Line.Height = 0.002083302F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0.1979167F;
            this.Line.Width = 7.187F;
            this.Line.X1 = 0F;
            this.Line.X2 = 7.187F;
            this.Line.Y1 = 0.1979167F;
            this.Line.Y2 = 0.2F;
            // 
            // Line5
            // 
            this.Line5.Height = 0.1875F;
            this.Line5.Left = 0.5625F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0F;
            this.Line5.Width = 0F;
            this.Line5.X1 = 0.5625F;
            this.Line5.X2 = 0.5625F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0.1875F;
            // 
            // Line6
            // 
            this.Line6.Height = 0.1875F;
            this.Line6.Left = 2.9F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 0F;
            this.Line6.Width = 0F;
            this.Line6.X1 = 2.9F;
            this.Line6.X2 = 2.9F;
            this.Line6.Y1 = 0F;
            this.Line6.Y2 = 0.1875F;
            // 
            // Line7
            // 
            this.Line7.Height = 0.1875F;
            this.Line7.Left = 4F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 0F;
            this.Line7.Width = 0F;
            this.Line7.X1 = 4F;
            this.Line7.X2 = 4F;
            this.Line7.Y1 = 0F;
            this.Line7.Y2 = 0.1875F;
            // 
            // Line8
            // 
            this.Line8.Height = 0.1875F;
            this.Line8.Left = 4.6F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 0F;
            this.Line8.Width = 0F;
            this.Line8.X1 = 4.6F;
            this.Line8.X2 = 4.6F;
            this.Line8.Y1 = 0F;
            this.Line8.Y2 = 0.1875F;
            // 
            // Line9
            // 
            this.Line9.Height = 0.1875F;
            this.Line9.Left = 5F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0F;
            this.Line9.Width = 0F;
            this.Line9.X1 = 5F;
            this.Line9.X2 = 5F;
            this.Line9.Y1 = 0F;
            this.Line9.Y2 = 0.1875F;
            // 
            // Line10
            // 
            this.Line10.Height = 0.1875F;
            this.Line10.Left = 6F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 0F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 6F;
            this.Line10.X2 = 6F;
            this.Line10.Y1 = 0F;
            this.Line10.Y2 = 0.1875F;
            // 
            // Line11
            // 
            this.Line11.Height = 0.2F;
            this.Line11.Left = 7.18F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 0F;
            this.Line11.Width = 0F;
            this.Line11.X1 = 7.18F;
            this.Line11.X2 = 7.18F;
            this.Line11.Y1 = 0F;
            this.Line11.Y2 = 0.2F;
            // 
            // Line12
            // 
            this.Line12.Height = 0.1875F;
            this.Line12.Left = 0F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 0F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 0F;
            this.Line12.X2 = 0F;
            this.Line12.Y1 = 0F;
            this.Line12.Y2 = 0.1875F;
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
            this.GroupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape,
            this.Label2,
            this.Label3,
            this.Label4,
            this.Label5,
            this.Label6,
            this.Line1,
            this.Line2,
            this.Line3,
            this.Line4,
            this.label1});
            this.GroupHeader1.Height = 0.5F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // Shape
            // 
            this.Shape.Height = 0.25F;
            this.Shape.Left = 0F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape.Top = 0.25F;
            this.Shape.Width = 7.18F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 2.7F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "text-align: center";
            this.Label2.Text = "$ per Item";
            this.Label2.Top = 0.25F;
            this.Label2.Width = 1.3F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 4F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "text-align: center";
            this.Label3.Text = "# Items";
            this.Label3.Top = 0.25F;
            this.Label3.Width = 0.6F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 4.6F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "text-align: center";
            this.Label4.Text = "MU %";
            this.Label4.Top = 0.25F;
            this.Label4.Width = 0.425F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 5F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "text-align: center";
            this.Label5.Text = "Markup";
            this.Label5.Top = 0.26F;
            this.Label5.Width = 1F;
            // 
            // Label6
            // 
            this.Label6.Height = 0.2F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 6.007F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "text-align: center";
            this.Label6.Text = "Total";
            this.Label6.Top = 0.26F;
            this.Label6.Width = 1.18F;
            // 
            // Line1
            // 
            this.Line1.Height = 0.25F;
            this.Line1.Left = 4F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.25F;
            this.Line1.Width = 0F;
            this.Line1.X1 = 4F;
            this.Line1.X2 = 4F;
            this.Line1.Y1 = 0.25F;
            this.Line1.Y2 = 0.5F;
            // 
            // Line2
            // 
            this.Line2.Height = 0.25F;
            this.Line2.Left = 4.6F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0.25F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 4.6F;
            this.Line2.X2 = 4.6F;
            this.Line2.Y1 = 0.25F;
            this.Line2.Y2 = 0.5F;
            // 
            // Line3
            // 
            this.Line3.Height = 0.25F;
            this.Line3.Left = 5F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0.25F;
            this.Line3.Width = 0F;
            this.Line3.X1 = 5F;
            this.Line3.X2 = 5F;
            this.Line3.Y1 = 0.25F;
            this.Line3.Y2 = 0.5F;
            // 
            // Line4
            // 
            this.Line4.Height = 0.25F;
            this.Line4.Left = 6F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 0.25F;
            this.Line4.Width = 0F;
            this.Line4.X1 = 6F;
            this.Line4.X2 = 6F;
            this.Line4.Y1 = 0.25F;
            this.Line4.Y2 = 0.5F;
            // 
            // label1
            // 
            this.label1.Height = 0.1979167F;
            this.label1.HyperLink = null;
            this.label1.Left = 0.0625F;
            this.label1.Name = "label1";
            this.label1.Style = "font-size: 9.75pt; font-weight: bold";
            this.label1.Text = "Expenses";
            this.label1.Top = 0.25F;
            this.label1.Width = 1F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape1,
            this.TextBox7,
            this.Label,
            this.Line13,
            this.textBox8});
            this.GroupFooter1.Height = 0.75F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // Shape1
            // 
            this.Shape1.Height = 0.25F;
            this.Shape1.Left = 0F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape1.Top = 0F;
            this.Shape1.Width = 7.18F;
            // 
            // TextBox7
            // 
            this.TextBox7.DataField = "TotalCost";
            this.TextBox7.Height = 0.2F;
            this.TextBox7.Left = 6F;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat");
            this.TextBox7.Style = "text-align: right";
            this.TextBox7.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All;
            this.TextBox7.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal;
            this.TextBox7.Text = "TextBox";
            this.TextBox7.Top = 0F;
            this.TextBox7.Width = 1.18F;
            // 
            // Label
            // 
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 4.957F;
            this.Label.Name = "Label";
            this.Label.Style = "font-family: Arial; font-size: 9.75pt";
            this.Label.Text = "Total Expenses";
            this.Label.Top = 0F;
            this.Label.Width = 1F;
            // 
            // Line13
            // 
            this.Line13.Height = 0.25F;
            this.Line13.Left = 6F;
            this.Line13.LineWeight = 1F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 0F;
            this.Line13.Width = 0F;
            this.Line13.X1 = 6F;
            this.Line13.X2 = 6F;
            this.Line13.Y1 = 0F;
            this.Line13.Y2 = 0.25F;
            // 
            // textBox8
            // 
            this.textBox8.Height = 0.448F;
            this.textBox8.Left = 0F;
            this.textBox8.Name = "textBox8";
            this.textBox8.Top = 0.302F;
            this.textBox8.Width = 7F;
            // 
            // rprtPCNExpenses
            // 
            this.MasterReport = false;
            sqlDBDataSource1.ConnectionString = "data source=REVSOL2\\SQL2005;initial catalog=RSManpowerSchDB;integrated security=S" +
    "SPI;persist security info=False";
            sqlDBDataSource1.SQL = "spBudgetPCNExpense_ListAllByPCN 1";
            this.DataSource = sqlDBDataSource1;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.221417F;
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
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private void GroupFooter1_Format(object sender, EventArgs e)
        {
            string totExp = TextBox7.Value.ToString();


            if (OnExpensesTotalled != null)
                OnExpensesTotalled(totExp);


        }

        public GrapeCity.ActiveReports.Data.SqlDBDataSource ds;
        private PageHeader PageHeader;
        private GroupHeader GroupHeader1;
        private Label Label2;
        private Label Label3;
        private Label Label4;
        private Label Label5;
        private Label Label6;
        private Shape Shape;
        private Line Line1;
        private Line Line2;
        private Line Line3;
        private Line Line4;
        private Detail Detail;
        private TextBox TextBox;
        private TextBox TextBox1;
        private TextBox TextBox2;
        private TextBox TextBox3;
        private TextBox TextBox4;
        private TextBox TextBox5;
        private TextBox TextBox6;
        private Line Line;
        private Line Line5;
        private Line Line6;
        private Line Line7;
        private Line Line8;
        private Line Line9;
        private Line Line10;
        private Line Line11;
        private Line Line12;
        private GroupFooter GroupFooter1;
        private Shape Shape1;
        private TextBox TextBox7;
        private Label Label;
        private Line Line13;
        private PageFooter PageFooter;
    }
}
