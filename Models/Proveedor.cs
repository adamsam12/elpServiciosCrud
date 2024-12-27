using System.ComponentModel.DataAnnotations;

namespace CrudNet8MVC.Models;

public class Proveedor
{
    [Key]
    public int Id { get; set; }
    public string Ruc { get; set; }
    public string razon_social { get; set; }
    public string direccion { get; set; }
    public string telefono { get; set; }
}