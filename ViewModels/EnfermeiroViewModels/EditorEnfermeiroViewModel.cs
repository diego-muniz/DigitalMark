using System;
using DigitalMark.Helpers;
using DigitalMark.Models;
using Flunt.Notifications;
using Flunt.Validations;

namespace DigitalMark.ViewModels.EnfermeiroViewModels
{
  public class EditorEnfermeiroViewModel : Notifiable, IValidatable
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Coren { get; set; }
    public DateTime? DataNascimento { get; set; }
    public int HospitalId { get; set; }
    public string Hospital { get; set; }

    public void Validate()
    {
       AddNotifications(
          new Contract()
          .Requires()
            .IsNotNullOrEmpty(Nome, "Nome", "Favor, informe o nome !")
            .HasMaxLen(Nome, 255, "Nome", "O nome deve conter no maximo 255 caracteres !")
            .HasMinLen(Nome, 3, "Nome", "O nome deve conter no minimo 3 caracteres !")
            .IsNotNullOrEmpty(Coren, "Coren", "Favor, informe o COREN !")
            .HasLen(Coren, 10, "Coren", "O coren deve conter 10 caracteres !")
            .AreNotEquals(HospitalId, 0, "HospitalId", "Hospital inválido !")
            .AreNotEquals(DataNascimento.GetValueOrDefault().ToString(), "01/01/0001 00:00:00", "DataNascimento", "Favor, informe a data de nascimento !")
        );

        if(!Validar.CPF(CPF))
                AddNotification("CPF", "Favor, informe o CPF valido !");


    }
  }
}