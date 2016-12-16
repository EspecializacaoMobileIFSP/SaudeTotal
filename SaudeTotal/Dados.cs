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
            conn.CreateTable<Corrida>();
            conn.CreateTable<Peso>();
        }

        internal static void Save(object obj)
        {
            try
            {
                conn.Insert(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static void Delete(object obj)
        {
            try
            {
                conn.Delete(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * Pessoa 
         */
        internal static List<Pessoa> ListPessoa()
        {
            var retorno = new List<Pessoa>();
            var result = conn.Query<Pessoa>(
                @"SELECT PessoaId, Nome, Acesso, Senha, DataDeNascimento, Altura FROM Pessoa"
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
                @"SELECT PessoaId, Nome, Acesso, Senha, DataDeNascimento, Altura FROM Pessoa WHERE Acesso = ? AND Senha= ?",
                acesso, senha
            );

            Pessoa pessoa = null;
            if (result.Count > 0)
            {
                pessoa = result[0];
            }
            return pessoa;
        }

        /*
         * Corrida
         */
        internal static List<Corrida> ListCorrida(Pessoa pessoa, String direction)
        {
            var retorno = new List<Corrida>();
            var result = conn.Query<Corrida>(
                @"SELECT CorridaId, Data, Distancia, Tempo FROM Corrida WHERE Pessoa = ? ORDER BY Data ?", pessoa.PessoaId, direction
            );

            foreach (var item in result)
            {
                retorno.Add(item);
            }
            return retorno;
        }

        /*
         * Peso
         */
        internal static List<Peso> ListPeso(Pessoa pessoa, String direction)
        {
            var retorno = new List<Peso>();
            var result = conn.Query<Peso>(
                @"SELECT PesoId, Data, Valor FROM Peso WHERE Pessoa = ? ORDER BY Data ?", pessoa.PessoaId, direction
            );

            foreach (var item in result)
            {
                retorno.Add(item);
            }
            return retorno;
        }
    }
}
