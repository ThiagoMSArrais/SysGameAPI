using SysGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SysGame.Domain.Interfaces
{
    public interface IAmigoServices
    {
        Task Adicionar(Amigo amigo);
        Task<IEnumerable<Amigo>> ObterAmigos();
        Task<Amigo> ObterAmigoPorId(Guid id);
        Task Atualizar(Amigo amigo);
        Task Remover(Guid id);
    }
}
