using Flunt.Notifications;
using Flunt.Validations;

namespace DigitalMark.ViewModels.ProductViewModels
{
  // public class EditorHospitalViewModel : Notifiable, IValidatable
  public class EditorHospitalViewModel
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; }
    public string UF { get; set; }

    // public void Validate()
    // {
    //     AddNotifications(
    //       new Contract()
    //       .HasMaxLen(Title, 120, "Title", "O Titulo deve conter até 120 caracteres")
    //       .HasMinLen(Title, 3, "Title", "O Titulo deve conter pelo menos 3 caracteres")
    //       .IsGreaterThan(Price, 0, "Price", "O preço deve ser maior que zero")
    //     );
    // }
  }
}