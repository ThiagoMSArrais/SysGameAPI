using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sysgame.API.ViewModels;
using SysGame.Domain.Interfaces;
using SysGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sysgame.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/amigos")]
    public class AmigoController : MainController
    {
        private readonly IAmigoServices _amigoService;
        private readonly IMapper _mapper;

        public AmigoController(IAmigoServices amigoService,
                               IMapper mapper,
                               INotificador notificador) : base (notificador)
        {
            _amigoService = amigoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AmigoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AmigoViewModel>>(await _amigoService.ObterAmigos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AmigoViewModel>> ObterPorId(Guid id)
        {
            var amigo = _mapper.Map<AmigoViewModel>(await _amigoService.ObterAmigoPorId(id));

            if (amigo == null) return NotFound();

            return amigo;
        }

        [HttpPost]
        public async Task<ActionResult<AmigoViewModel>> Adicionar(AmigoViewModel amigoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _amigoService.Adicionar(_mapper.Map<Amigo>(amigoViewModel));

            return CustomResponse(amigoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AmigoViewModel>> Atualizar(Guid id, [FromBody] AmigoViewModel amigoViewModel)
        {
            if (id != amigoViewModel.AmigoId)
            {
                NotificarErro("O id informado não é o mesmo que foi passado");
                return CustomResponse(amigoViewModel);
            }
            
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _amigoService.Atualizar(_mapper.Map<Amigo>(amigoViewModel));

            return CustomResponse(amigoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AmigoViewModel>> Excluir(Guid id)
        {
            var amigoViewModel = _mapper.Map<AmigoViewModel>(await _amigoService.ObterAmigoPorId(id));

            if (amigoViewModel == null) return NotFound();

            await _amigoService.Remover(id);

            return CustomResponse(amigoViewModel);
        }
    }
}
