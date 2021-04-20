using SysGame.Domain.Notificacoes;
using System.Collections.Generic;

namespace SysGame.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
