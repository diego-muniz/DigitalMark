using System;
using DigitalMark.Models;
using Flunt.Notifications;
using Flunt.Validations;

namespace DigitalMark.ViewModels.EnfermeiroViewModels
{
  // public class EditorHospitalViewModel : Notifiable, IValidatable
  public class EditorEnfermeiroViewModel
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Coren { get; set; }
    public DateTime DataNascimento { get; set; }
    public int HospitalId { get; set; }
    public string Hospital { get; set; }


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