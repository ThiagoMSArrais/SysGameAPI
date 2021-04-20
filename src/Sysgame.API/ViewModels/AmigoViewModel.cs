using System;
using System.ComponentModel.DataAnnotations;

namespace Sysgame.API.ViewModels
{
    public class AmigoViewModel
    {

        public AmigoViewModel()
        {
            AmigoId = Guid.NewGuid();
        }

        [Key]
        public Guid AmigoId { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        [StringLength(150, ErrorMessage = "O campo nome precisa ter entre 2 e 150 caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

    }
}
