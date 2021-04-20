using SysGame.Domain.Interfaces;
using SysGame.Domain.Models;
using SysGame.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SysGame.Domain.Services
{
    public class AmigoService : BaseService, IAmigoServices
    {
        private readonly IAmigoRepository _amigoRepository;

        public AmigoService(IAmigoRepository amigoRepository,
                            INotificador notificador) : base(notificador)
        {
            _amigoRepository = amigoRepository;
        }

        public async Task Adicionar(Amigo amigo)
        {
            if (!ExecutarValidacao(new AmigoValidation(), amigo)) return;

            await _amigoRepository.Adicionar(amigo);
        }

        public async Task Atualizar(Amigo amigo)
        {
            if (!ExecutarValidacao(new AmigoValidation(), amigo)) return;

            await _amigoRepository.Atualizar(amigo);
        }

        public async Task<Amigo> ObterAmigoPorId(Guid id)
        {
            return await _amigoRepository.ObterAmigoPorId(id);
        }

        public async Task<IEnumerable<Amigo>> ObterAmigos()
        {
            return await _amigoRepository.ObterAmigos();
        }

        public async Task Remover(Guid id)
        {
            await _amigoRepository.Remover(id);
        }
    }
}
