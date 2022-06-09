using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnCuoiky.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhvienController : ControllerBase
    {
        private readonly DataContext _context;

        public SinhvienController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SinhvienModel>>> GetSinhvienDetail()
        {
            var resutl = _context.SinhvienCD.ToList();
            return Ok(resutl);
        }

        [HttpGet("search/{name}")]
        public async Task<ActionResult<List<SinhvienModel>>> SearchSinhvien(string name)
        {
            var resutl = await _context.SinhvienCD.Where(s => s.Name.ToLower().Contains(name.ToLower())).ToListAsync();
            return Ok(resutl);
        }
        [HttpGet("search")]
        public async Task<ActionResult<List<SinhvienModel>>> SearchNull()
        {
            var resutl = _context.SinhvienCD.ToList();
            return Ok(resutl);
        }
        [HttpPost]
        public async Task<ActionResult<List<SinhvienModel>>> CreateSinhVien(SinhvienModel student)
        {
            _context.SinhvienCD.Add(student);
            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SinhvienModel>> GetSinglesinhvien(int id)
        {
            var student = await _context.SinhvienCD.FirstOrDefaultAsync(h => h.Id == id);
            if (student == null)
            {
                return NotFound("Sorry, no hero here. :/");
            }
            return Ok(student);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<SinhvienModel>>> UpdateSinhvien(SinhvienModel student, int id)
        {
            var dbStudent = await _context.SinhvienCD
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbStudent == null)
                return NotFound("Sorry, but no hero for you. :/");

            dbStudent.Name = student.Name;
            dbStudent.MSSV = student.MSSV;
            dbStudent.Gender = student.Gender;
            dbStudent.Email = student.Email;
            dbStudent.Birthday = student.Birthday;
            await _context.SaveChangesAsync();

            return Ok(await GetSinhvienDetail());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SinhvienModel>>> DeleteSinhvien(int id)
        {
            var dbStudent = await _context.SinhvienCD.FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbStudent == null)
                return NotFound("Sorry, but no student for you. :/");

            _context.SinhvienCD.Remove(dbStudent);
            await _context.SaveChangesAsync();

            return Ok(await GetSinhvienDetail());
        }
    }
}
