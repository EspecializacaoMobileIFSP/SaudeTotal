using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace SaudeTotal
{
    [Table("Pessoa")]
    class Pessoa
    {
        [PrimaryKey, AutoIncrement]
        public int PessoaId { get; set; }

        [MaxLength(255)]
        public string Nome { get; set; }

        [MaxLength(255), Unique]
        public string Acesso { get; set; }

        [MaxLength(255)]
        public string Senha { get; set; }

        [MaxLength(10)]
        public string DataDeNascimento { get; set; }

        public double Altura { get; set; }
    }
}
