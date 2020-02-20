using System;
using System.Collections.Generic;
using DigitalMark.Models;

namespace DigitalMark.ViewModels.EnfermeiroViewModels
{
  public class ListEnfermeiroViewModel 
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Coren { get; set; }
    public DateTime DataNascimento { get; set; }
    public int HospitalId { get; set; }
    public Hospital Hospital { get; set; }

  }
}