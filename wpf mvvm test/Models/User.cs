using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_mvvm_test.Models
{
    public class User
    {
        [Key]
       public int Id { get; set; }
        [StringLength(30)]
       public string Name { get; set; }
        [StringLength(50)]
       public string Email { get; set; }
        [StringLength(50)]
       public string Password { get; set; }
    }
}
