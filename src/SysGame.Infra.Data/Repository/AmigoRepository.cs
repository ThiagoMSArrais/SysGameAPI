using Microsoft.Extensions.Configuration;
using SysGame.Domain.Interfaces;
using SysGame.Domain.Models;
using SysGame.Infra.Data.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace SysGame.Infra.Data.Repository
{
    public class AmigoRepository : ConnectionDB, IAmigoRepository
    {
        public AmigoRepository(IConfiguration configuration) : base(configuration) { }

        public async Task Adicionar(Amigo amigo)
        {
            using(var con = Connection)
            {
                string sqlAdicionarAmigo = @"INSERT INTO AMIGO
                                            (
                                                AMIGOID,
                                                NOME
                                            )
                                            VALUES
                                            (
                                                @AMIGOID,
                                                @NOME
                                            )";

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametrosAmigo = new DynamicParameters();
                    parametrosAmigo.Add("AMIGOID", amigo.AmigoId, DbType.Guid, ParameterDirection.Input);
                    parametrosAmigo.Add("NOME", amigo.Nome, DbType.String, ParameterDirection.Input);

                    await con.ExecuteAsync(sqlAdicionarAmigo, param: parametrosAmigo);

                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        public async Task Atualizar(Amigo amigo)
        {
            using(var con = Connection)
            {
                string sqlAtualizarAmigo = @"UPDATE AMIGO SET NOME = @NOME WHERE AMIGOID = @AMIGOID";

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametrosAmigo = new DynamicParameters();
                    parametrosAmigo.Add("AMIGOID", amigo.AmigoId, DbType.Guid, ParameterDirection.Input);
                    parametrosAmigo.Add("NOME", amigo.Nome, DbType.String, ParameterDirection.Input);

                    await con.ExecuteAsync(sqlAtualizarAmigo, param: parametrosAmigo);
                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        public async Task<Amigo> ObterAmigoPorId(Guid id)
        {
            using(var con = Connection)
            {
                string sqlObterAmigo = @"SELECT 
                                                AMIGOID AS AmigoId, 
                                                NOME AS Nome
                                        FROM
                                                AMIGO
                                        WHERE 
                                                AMIGOID = @AMIGOID";

                Amigo amigo = default(Amigo);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametrosAmigo = new DynamicParameters();
                    parametrosAmigo.Add("AMIGOID", id, DbType.Guid, ParameterDirection.Input);

                    amigo = await con.QueryFirstOrDefaultAsync<Amigo>(sqlObterAmigo, param: parametrosAmigo);

                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

                return amigo;
            }
        }

        public async Task<IEnumerable<Amigo>> ObterAmigos()
        {
            using (var con = Connection)
            {
                string sqlObterAmigo = @"SELECT 
                                                AMIGOID AS AmigoId, 
                                                NOME AS Nome
                                        FROM
                                                AMIGO";

                IEnumerable<Amigo> amigos = default(IEnumerable<Amigo>);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    amigos = await con.QueryAsync<Amigo>(sqlObterAmigo);

                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

                return amigos;
            }
        }

        public async Task Remover(Guid id)
        {
            using(var con = Connection)
            {
                string sqlRemoverAmigo = @"DELETE AMIGO WHERE AMIGOID = @AMIGOID";

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametrosAmigo = new DynamicParameters();
                    parametrosAmigo.Add("AMIGOID", id, DbType.Guid, ParameterDirection.Input);

                    await con.ExecuteAsync(sqlRemoverAmigo, param: parametrosAmigo);
                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
    }
}
