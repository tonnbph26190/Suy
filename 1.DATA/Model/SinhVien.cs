using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class SinhVien
    {
        [Key]
        [StringLength(4,ErrorMessage ="Ma phai chua 4 ki tu")]
        public string Ma { get; set; }
        public string Ten { get; set; }
        [Required(ErrorMessage ="Vui long nhap tuoi")]
        [Range(18,50,ErrorMessage ="Tuoi tu 18-50")]
        public int tuoi { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [RegularExpression(@"^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Vui lòng nhập đúng email")]
        public string Eamil { get; set; }
        public float DiemTB { get; set; }
        public bool TrangThai { get; set; }
    }
}
