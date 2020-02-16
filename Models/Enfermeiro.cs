using System;
using System.Collections.Generic;

namespace DigitalMark.Models 
{
  public class Enfermeiro {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Coren { get; set; }
    public DateTime DataNascimento { get; set; }
     public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int HospitalId { get; set; }
    public Hospital Hospital { get; set; }

  }
}