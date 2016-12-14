using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace SaudeTotal
{
    [Table("Peso")]
    class Peso
    {
        [PrimaryKey, AutoIncrement]
        public int PesoId { get; set; }

        public int Pessoa { get; set; }

        [MaxLength(10)]
        public string Data { get; set; }

        public double Valor { get; set; }
    }
}
