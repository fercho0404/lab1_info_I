#region usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Gerstor_De_Particiones_De_Memoria.Models
{
    public class MemorySpace
    {
        public int TotalMemory { get; set; }
        public int UsedMemory { get; set; }
    }
}
