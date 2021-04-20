using SysGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SysGame.Domain.Interfaces
{
    public interface IJogoRepository
    {
        Task Adicionar(Jogo jogo);
        Task<IEnumerable<Jogo>> ObterJogos();
        Task<Jogo> ObterJogoPorId(Guid id);
        Task Atualizar(Jogo jogo);
        Task Remover(Guid id);
    }
}
