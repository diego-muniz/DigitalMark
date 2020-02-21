using System.Collections.Generic;
using DigitalMark.Models;

namespace DigitalMark.ViewModels.HospitalViewModels
{
  public class ListHospitalViewModel 
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public string Cep { get; set; }
    public string Logradouro { get; set; }

  }
}