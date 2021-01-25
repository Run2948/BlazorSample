using System.ComponentModel.DataAnnotations;

namespace Sample.Game.Entities.Dtos
{
    public class PlayerForUpdateDto 
    {
        [Required(ErrorMessage = "账号不能为空")]
        [StringLength(20, ErrorMessage = "账号长度不能大于50")]
        public string Account { get; set; }

        [Required(ErrorMessage = "账号类型不能为空")]
        [StringLength(10, ErrorMessage = "账号类型不能大于10")]
        public string AccountType { get; set; }
    }
}