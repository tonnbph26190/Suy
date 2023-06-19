using _1.DATA.Dbcontext;
using _1.DATA.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        SVDbcontext _context;
        public SinhVienController(SVDbcontext sv)
        {
            _context= sv;
        }
        // GET: api/<SinhVienController>
        [HttpGet]
        public IEnumerable<SinhVien> Get()
        {
            return _context.SinhViens.ToList();
        }

        // GET api/<SinhVienController>/5
        [HttpGet("{id}")]
        public SinhVien Get(string id)
        {
            var sv = _context.SinhViens.ToList().SingleOrDefault(c => c.Ma == id);
            if (sv!=null)
            {
                return sv;
            }
            return new SinhVien();
        }

        // POST api/<SinhVienController>
        [HttpPost]
        public bool Post(SinhVien sv)
        {
            try
            {
                _context.SinhViens.Add(sv);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        // PUT api/<SinhVienController>/5
        [HttpPut("{id}")]
        public bool Put(string id,SinhVien sv )
        {
            var v1 = _context.SinhViens.ToList().SingleOrDefault(c => c.Ma == id);
            try
            {
                if (v1==null)
                {
                    return false;
                }
                 v1.Ten=sv.Ten;
                v1.tuoi=sv.tuoi;
                v1.DiemTB = sv.DiemTB;
                v1.TrangThai = sv.TrangThai;
                v1.Eamil = sv.Eamil;
                _context.SinhViens.Update(v1);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        // DELETE api/<SinhVienController>/5
        [HttpDelete("{id}")]
        public bool Delete(string id)
        {
            var v1 = _context.SinhViens.ToList().SingleOrDefault(c => c.Ma == id);
            try
            {
                if (v1 == null)
                {
                    return false;
                }
                _context.SinhViens.Remove(v1);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
