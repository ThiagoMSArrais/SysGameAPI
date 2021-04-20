using SysGame.Domain.Interfaces;
using SysGame.Domain.Models;
using SysGame.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SysGame.Domain.Services
{
    public class JogoService : BaseService, IJogoServices
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository,
                           INotificador notificador) : base(notificador)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task Adicionar(Jogo jogo)
        {
            if (!ExecutarValidacao(new JogoValidation(), jogo)) return;

            await _jogoRepository.Adicionar(jogo);
        }

        public async Task Atualizar(Jogo jogo)
        {
            if (!ExecutarValidacao(new JogoValidation(), jogo)) return;

            await _jogoRepository.Atualizar(jogo);
        }

        public async Task<Jogo> ObterJogoPorId(Guid id)
        {
            return await _jogoRepository.ObterJogoPorId(id);
        }

        public async Task<IEnumerable<Jogo>> ObterJogos()
        {
            return await _jogoRepository.ObterJogos();
        }

        public async Task Remover(Guid id)
        {
            await _jogoRepository.Remover(id);
        }
    }
}
