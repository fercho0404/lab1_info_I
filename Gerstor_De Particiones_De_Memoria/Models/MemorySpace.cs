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
        public string ProcessName { get; set; }
        public bool UsedSpace { get; set; }
    }
}
