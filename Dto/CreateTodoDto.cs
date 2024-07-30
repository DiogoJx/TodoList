using System.ComponentModel.DataAnnotations;

namespace MyTodo.Dto
{
    public class CreateTodoDto
    {
        [Required]
        public String Title { get; set; }
    }
}
