using Dapper;
using Microsoft.Extensions.Configuration;
using SysGame.Domain.Interfaces;
using SysGame.Domain.Models;
using SysGame.Infra.Data.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SysGame.Infra.Data.Repository
{
    public class JogoRepository : ConnectionDB, IJogoRepository
    {
        public JogoRepository(IConfiguration configuration) : base (configuration) { }

        public async Task Adicionar(Jogo jogo)
        {
            using(var con = Connection)
            {
                string sqlAdicionarJogo = @"INSERT INTO JOGO 
                                           (
                                                JOGOID,
                                                NOME,
                                                EMPRESTADO,
                                                PROPRIETARIOID,
                                                AMIGOID
                                            ) 
                                                VALUES
                                            (
                                                @JOGOID,
                                                @NOME,
                                                @EMPRESTADO,
                                                @PROPRIETARIOID,
                                                @AMIGOID
                                            )";
                                        
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametrosJogo = new DynamicParameters();
                    parametrosJogo.Add("JOGOID", jogo.JogoId, DbType.Guid, ParameterDirection.Input);
                    parametrosJogo.Add("NOME", jogo.Nome, DbType.String, ParameterDirection.Input);
                    parametrosJogo.Add("EMPRESTADO", jogo.Emprestado, DbType.Boolean, ParameterDirection.Input);
                    parametrosJogo.Add("PROPRIETARIOID", jogo.ProprietarioId, DbType.Guid, ParameterDirection.Input);
                    parametrosJogo.Add("AMIGOID", jogo.AmigoId, DbType.Guid, ParameterDirection.Input);


                    await con.ExecuteAsync(sqlAdicionarJogo, param: parametrosJogo);
                }
                catch (Exception)
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

        public async Task Atualizar(Jogo jogo)
        {
            using(var con = Connection)
            {
                string sqlAtualizarJogo = @"UPDATE JOGO " +
                                           "SET EMPRESTADO = @EMPRESTADO," +
                                           "    AMIGOID = @AMIGOID " +
                                           "WHERE" +
                                           "    JOGOID = @JOGOID";

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametrosJogo = new DynamicParameters();
                    parametrosJogo.Add("JOGOID", jogo.JogoId, DbType.Guid, ParameterDirection.Input);
                    parametrosJogo.Add("EMPRESTADO", jogo.Emprestado, DbType.Boolean, ParameterDirection.Input);
                    parametrosJogo.Add("AMIGOID", jogo.AmigoId, DbType.Guid, ParameterDirection.Input);

                    await con.ExecuteAsync(sqlAtualizarJogo, param: parametrosJogo);
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

        public async Task<Jogo> ObterJogoPorId(Guid id)
        {
            using(var con = Connection)
            {
                string sqlObterJogoPorId = @"SELECT
                                                    J.JOGOID AS JogoId,
                                                    J.NOME AS Nome,
                                                    J.EMPRESTADO AS Emprestado,
                                                    J.PROPRIETARIOID AS ProprietarioId,
                                                    J.AMIGOID AS AmigoId,
                                                    A.Nome AS NomeDoAmigoComJogoEmprestado                                                   
                                            FROM
                                                    JOGO J
                                                    INNER JOIN AMIGO A
                                                    ON J.AMIGOID = A.AMIGOID
                                            WHERE
                                                    J.JOGOID = @JOGOID";

                Jogo jogo = default(Jogo);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametroJogo = new DynamicParameters();
                    parametroJogo.Add("JOGOID", id, DbType.Guid, ParameterDirection.Input);

                    jogo = await con.QueryFirstOrDefaultAsync<Jogo>(sqlObterJogoPorId, param: parametroJogo);
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

                return jogo;
            }
        }

        public async Task<IEnumerable<Jogo>> ObterJogos()
        {
            using (var con = Connection)
            {
                string sqlObterJogoPorId = @"SELECT
                                                    J.JOGOID AS JogoId,
                                                    J.NOME AS Nome,
                                                    J.EMPRESTADO AS Emprestado,
                                                    J.PROPRIETARIOID AS ProprietarioId,
                                                    J.AMIGOID AS AmigoId,
                                                    A.Nome AS NomeDoAmigoComJogoEmprestado
                                            FROM
                                                    JOGO J
                                                    INNER JOIN AMIGO A
                                                    ON J.AMIGOID = A.AMIGOID";

                IEnumerable<Jogo> jogo = default(IEnumerable<Jogo>);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    jogo = await con.QueryAsync<Jogo>(sqlObterJogoPorId);

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

                return jogo;
            }
        }

        public async Task Remover(Guid id)
        {
            using(var con = Connection)
            {
                string sqlRemoverJogo = @"DELETE JOGO WHERE JOGOID = @JOGOID";

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametrosJogo = new DynamicParameters();
                    parametrosJogo.Add("JOGOID", id, DbType.Guid, ParameterDirection.Input);

                    await con.ExecuteAsync(sqlRemoverJogo, param: parametrosJogo);
                }
                catch (Exception)
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
