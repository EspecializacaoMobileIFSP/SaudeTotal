using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace SaudeTotal
{
    [Table("Corrida")]
    class Corrida
    {
        [PrimaryKey, AutoIncrement]
        public int CorridaId { get; set; }

        public int Pessoa { get; set; }

        [MaxLength(10)]
        public string Data { get; set; }

        public double Distancia { get; set; }

        public double Tempo { get; set; }
    }
}
