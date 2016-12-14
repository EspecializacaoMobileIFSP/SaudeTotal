using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;

namespace SaudeTotal
{
    class Dados
    {
        public static SQLiteConnection conn;
        public static void LoadDatabase()
        {
            conn = new SQLiteConnection(new SQLitePlatformWinRT(), "saudetotal.db");
            conn.CreateTable<Pessoa>();
        }

        internal static void SavePessoa(Pessoa pessoa)
        {
            conn.Insert(pessoa);
        }

        internal static void DeletePessoa(Pessoa pessoa)
        {
            conn.Delete(pessoa);
        }

        internal static List<Pessoa> ListPessoa()
        {
            var retorno = new List<Pessoa>();
            var result = conn.Query<Pessoa>(
                @"SELECT PessoaId, Nome, Acesso, Senha, DataDeNascimento, Peso FROM Pessoa"
            );

            foreach (var item in result)
            {
                retorno.Add(item);
            }
            return retorno;
        }

        internal static Pessoa GetPessoa(string acesso, string senha)
        {
            var result = conn.Query<Pessoa>(
                @"SELECT PessoaId, Nome, Acesso, Senha, DataDeNascimento, Peso FROM Pessoa WHERE Acesso = ? AND Senha= ?",
                acesso, senha
            );

            Pessoa pessoa = null;
            if (result.Count > 0)
            {
                pessoa = result[0];
            }
            return pessoa;
        }
    }
}
