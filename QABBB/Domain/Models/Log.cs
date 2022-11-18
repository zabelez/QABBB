using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Log
    {
        public int Idlog { get; set; }
        public int IdUser { get; set; }
        public string Ip { get; set; } = null!;
        public string Date { get; set; } = null!;

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
