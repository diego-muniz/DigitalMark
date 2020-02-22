using Flunt.Notifications;
using Flunt.Validations;
using DigitalMark.Helpers;

namespace DigitalMark.ViewModels.HospitalViewModels
{
  public class EditorHospitalViewModel : Notifiable, IValidatable
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

    public void Validate()
    {
        AddNotifications(
          new Contract()
          .Requires()
            .IsNotNullOrEmpty(Nome, "Nome", "Favor, informe o nome !")
            .HasMaxLen(Nome, 255, "Nome", "O nome deve conter no maximo 255 caracteres !")
            .HasMinLen(Nome, 3, "Nome", "O nome deve conter no minimo 3 caracteres !")
            .IsNotNullOrEmpty(Cep, "Cep", "Favor, informe o cep !")
            .HasLen(Cep, 8, "Cep", "O cep deve conter 8 caracteres !")
            .IsNotNullOrEmpty(CNPJ, "CNPJ", "Favor, informe o CNPJ !")
            .HasLen(CNPJ, 14, "CNPJ", "O CNPJ deve conter 14 caracteres !")
        );

        if (!Validar.CNPJ(CNPJ))
                AddNotification("CNPJ", "Favor, informe o CNPJ valido !");
    }
  }
}