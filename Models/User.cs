using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data.Common;
using System;

namespace Pos2909.db.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public string Nacionalidade { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

        [JsonIgnore]
        public AppDb Db { get; set; }

        public User(AppDb db = null)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO `User` (`FullName`, `Cpf`, `Email`, `Telefone`, `Sexo`, `Nacionalidade`, `Estado`, `Cidade`) " + 
            "VALUES (@fullname, @cpf, @email, @telefone, @sexo, @nacionalidade, @estado, @estado, @cidade);";

            BindParams(cmd);

            await cmd.ExecuteNonQueryAsync();
            
            Id = (int) cmd.LastInsertedId;
        }

        public async Task<List<User>> ReadAllAsync()
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `User`";
            
            DbDataReader reader = await cmd.ExecuteReaderAsync();

            var User = new List<User>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var user = new User(Db)
                    {
                        Id = await reader.GetFieldValueAsync<int>(0),
                        FullName = await reader.GetFieldValueAsync<string>(1),
                        Cpf = await reader.GetFieldValueAsync<string>(2),
                        Email = await reader.GetFieldValueAsync<string>(3),
                        Telefone = await reader.GetFieldValueAsync<string>(4),
                        Sexo = await reader.GetFieldValueAsync<string>(5),
                        Nacionalidade = await reader.GetFieldValueAsync<string>(6),
                        Estado = await reader.GetFieldValueAsync<string>(7),
                        Cidade = await reader.GetFieldValueAsync<string>(8),
                    };

                    User.Add(user);
                }
            }

            return User;
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@fullname",
                DbType = DbType.String,
                Value = FullName,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@cpf",
                DbType = DbType.String,
                Value = Cpf,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@email",
                DbType = DbType.String,
                Value = Email,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@telefone",
                DbType = DbType.String,
                Value = Telefone,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@sexo",
                DbType = DbType.String,
                Value = Sexo,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@nacionalidade",
                DbType = DbType.String,
                Value = Nacionalidade,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@estado",
                DbType = DbType.String,
                Value = Estado,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@cidade",
                DbType = DbType.String,
                Value = Cidade,
            });
        }
    }
}