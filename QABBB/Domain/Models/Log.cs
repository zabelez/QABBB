using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Log
    {
        public int IdLog { get; set; }
        public int IdUser { get; set; }
        public string Ip { get; set; } = null!;
        public DateTime Date { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
