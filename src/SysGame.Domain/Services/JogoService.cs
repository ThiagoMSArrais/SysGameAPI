using SysGame.Domain.Interfaces;
using SysGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SysGame.Domain.Services
{
    public class JogoService : IJogoServices
    {
        public Task Adicionar(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public Task<Jogo> ObterJogoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Jogo>> ObterJogos()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
