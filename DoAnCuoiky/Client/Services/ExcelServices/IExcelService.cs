namespace DoAnCuoiky.Client.Services.ExcelServices
{
    public interface IExcelService
    {
        List<SinhvienModel> Excelservices { get; set; }
        Task CreateExcelDetail(SinhvienModel student);
        Task GetExcelDetail();
    }
}
