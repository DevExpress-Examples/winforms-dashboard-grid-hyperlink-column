using DevExpress.DashboardCommon;
using DevExpress.DataAccess.Excel;

namespace Dashboard_GridHyperlinkColumn
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            dashboardDesigner1.CreateRibbon();

            Dashboard dashboard = new Dashboard();

            DashboardExcelDataSource excelDataSource = new DashboardExcelDataSource("Excel Data Source");
            excelDataSource.FileName = @"..\..\Data\GDPByCountry.xlsx";
            excelDataSource.SourceOptions = new ExcelSourceOptions(new ExcelWorksheetSettings("Sheet1"));
            dashboard.DataSources.Add(excelDataSource);

            GridDashboardItem grid = new GridDashboardItem();
            grid.DataSource = excelDataSource;

            // Creates two hyperlink columns: the first column takes hyperlinks from the underlying data source while the second 
            // generates links based on the specified URI pattern and country names.
            GridHyperlinkColumn hyperlinkColumn1 = new GridHyperlinkColumn(new Dimension("Name"));
            hyperlinkColumn1.UriDataMember = "Link";
            GridHyperlinkColumn hyperlinkColumn2 = new GridHyperlinkColumn(new Dimension("OfficialName"));
            hyperlinkColumn2.UriDataMember = "Name";
            hyperlinkColumn2.UriPattern = "https://en.wikipedia.org/wiki/{0}";

            GridMeasureColumn gdpColumn = new GridMeasureColumn(new Measure("GDP"));
            grid.Columns.AddRange(hyperlinkColumn1, hyperlinkColumn2, gdpColumn);
            dashboard.Items.Add(grid);
            dashboardDesigner1.Dashboard = dashboard;
        }
    }
}