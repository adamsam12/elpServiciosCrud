using System.ComponentModel.DataAnnotations;

namespace CrudNet8MVC.Models;

public class Message
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El mensaje es obligatorio")]
    public string Text { get; set; }
    
    // Destino correos
    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El email no es válido")]
    public string Email { get; set; }
    
    public DateTime Date { get; set; }
}