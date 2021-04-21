using System;

namespace SysGame.Domain.Models
{
    public class Jogo
    {
        public Guid JogoId { get; set; }
        public string Nome { get; set; }
        public bool Emprestado { get; set; }
        public Guid ProprietarioId { get; set; }
        public Guid? AmigoId { get; set; }
        public string NomeDoAmigoComJogoEmprestado { get; set; }
    }
}
