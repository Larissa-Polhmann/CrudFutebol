using CrudFutebol.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CrudFutebol.Repository
{
    public class JogadorRepository : IJogadorRepository
    {

        IConfiguration _configuration;

        public JogadorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("Default").Value;
            return connection;
        }

        public int Add(Jogador jogador)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Jogador(Id, Nome, Posicao) VALUES (@Id, @Nome, @Posicao); SELECT CAST(SCOPE_IDENTITY() as INT);";
                    count = con.Execute(query, jogador);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Delete(int id)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Jogador WHERE JogadorId =" + id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Edit(Jogador jogador)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Jogador SET Name = @Nome, Posicao = @Posicao WHERE JogadorId = " + jogador.JogadorId;
                    count = con.Execute(query, jogador);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public Jogador Get(int id)
        {
            var connectionString = this.GetConnection();
            Jogador jogador = new Jogador();

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Jogador WHERE JogadorId =" + id;
                    jogador = con.Query<Jogador>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return jogador;
            }
        }

        public List<Jogador> GetJogadores()
        {
            var connectionString = this.GetConnection();
            List<Jogador> jogadores = new List<Jogador>();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Jogador";
                    jogadores = con.Query<Jogador>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return jogadores;
            }
        }
    }
}
