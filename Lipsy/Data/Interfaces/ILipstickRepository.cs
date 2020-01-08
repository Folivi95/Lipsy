using Lipsy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lipsy.Interfaces
{
    public interface ILipstickRepository
    {
        IEnumerable<Lipstick> Lipsticks { get; }
        IEnumerable<Lipstick> PreferredLipsticks { get; }
        Lipstick GetLipstickById(int LipstickId);
    }
}
