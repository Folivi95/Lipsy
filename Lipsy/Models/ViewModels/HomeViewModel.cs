using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lipsy.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lipstick> PreferredLipsticks { get; set; }
    }
}
