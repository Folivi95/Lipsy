using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lipsy.Models.ViewModels
{
    public class LipstickViewModel
    {
        public IEnumerable<Lipstick> Lipsticks { get; set; }
        public string CurrentCategory { get; set; }
    }
}
