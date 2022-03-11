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
    public class TimeRepository : ITimeRepository
    {
        IConfiguration _configuration;

        public TimeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("Default").Value;
            return connection;
        }

        public int Add(Time time)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERTO INTO Time(Nome) VALUES (@Nome); SELECT CAST(SCOPE_IDENTITY() as INT);";
                    count = con.Execute(query, time);
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
                    var query = "DELETE FROM Time WHERE TimeId =" + id;
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

        public int Edit(Time time)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Time SET Name = @Nome WHERE TimeId = " + time.TimeId;
                    count = con.Execute(query, time);
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

        public Time Get(int id)
        {
            var connectionString = this.GetConnection();
            Time time = new Time();

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Time WHERE TimeId =" + id;
                    time = con.Query<Time>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return time;
            }
        }

        public List<Time> GetTimes()
        {
            var connectionString = this.GetConnection();
            List<Time> times = new List<Time>();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Time";
                    times = con.Query<Time>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return times;
            }
        }
    }
}
