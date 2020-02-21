using System;
using System.Collections.Generic;
using DigitalMark.Models;
using DigitalMark.ViewModels.EnfermeiroViewModels;
using DigitalMark.ViewModels.HospitalViewModels;

namespace DigitalMark.ViewModels.HospitalEnfermeiroViewModels
{
  public class ListHospitalEnfermeiroViewModel 
  {
    public int Id { get; set; }
     public int EnfermeiroId { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Coren { get; set; }
    public DateTime DataNascimento { get; set; }
    public int HospitalId { get; set; }
    public string Hospital { get; set; }
    public string UF { get; set; }
    public string CNPJ { get; set; }
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Localidade { get; set; }
    public string Bairro { get; set; }
    public string Complemento { get; set; }

    
    // public Enfermeiro Enfermeiro { get; set; }
    // public Hospital Hospital { get; set; }

  }
}