using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_mvvm_test.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }
    }
}
