namespace DoAnCuoiky.Client.Services.SinhvienServices
{
    public interface ISinhvienService
    {
        List<SinhvienModel> Sinhvienservices { get; set; }
        Task GetSinhvienDetail();
        Task CreateSinhvien(SinhvienModel student);
        Task UpdateSinhvien(SinhvienModel student);
        Task SearchSinhvien(string name);
        Task DeleteSinhvien(int id);
        Task<SinhvienModel> GetSingleSinhvien(int id);
    }
}
