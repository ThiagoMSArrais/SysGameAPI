using SysGame.Domain.Interfaces;
using SysGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGame.Domain.Services
{
    public class AmigoService : IAmigoServices
    {
        public Task Adicionar(Amigo amigo)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Amigo amigo)
        {
            throw new NotImplementedException();
        }

        public Task<Amigo> ObterAmigoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Amigo>> ObterAmigos()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
