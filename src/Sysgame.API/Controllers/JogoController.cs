using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sysgame.API.ViewModels;
using SysGame.Domain.Interfaces;
using SysGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sysgame.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/jogos")]
    public class JogoController : MainController
    {
        private readonly IJogoServices _jogoService;
        private readonly IMapper _mapper;

        public JogoController(IJogoServices jogoService,
                              IMapper mapper,
                              INotificador notificador) : base(notificador)
        {
            _jogoService = jogoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<JogoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<JogoViewModel>>(await _jogoService.ObterJogos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<JogoViewModel>> ObterPorId(Guid id)
        {
            var jogo = _mapper.Map<JogoViewModel>(await _jogoService.ObterJogoPorId(id));

            if (jogo == null) return NotFound();

            return jogo;
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> Adicionar(JogoViewModel jogoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _jogoService.Adicionar(_mapper.Map<Jogo>(jogoViewModel));

            return CustomResponse(jogoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<JogoViewModel>> Atualizar(Guid id, [FromBody] JogoViewModel jogoViewModel)
        {
            if (id != jogoViewModel.AmigoId)
            {
                NotificarErro("O id informado não é o mesmo que foi passado");
                return CustomResponse(jogoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _jogoService.Atualizar(_mapper.Map<Jogo>(jogoViewModel));

            return CustomResponse(jogoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<JogoViewModel>> Excluir(Guid id)
        {
            var jogoViewModel = _mapper.Map<JogoViewModel>(await _jogoService.ObterJogoPorId(id));

            if (jogoViewModel == null) return NotFound();

            await _jogoService.Remover(id);

            return CustomResponse(jogoViewModel);
        }
    }
}
