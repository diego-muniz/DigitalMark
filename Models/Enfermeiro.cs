using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalMark.Models 
{
  public class Enfermeiro {

    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Coren { get; set; }
    public DateTime DataNascimento { get; set; }
     public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<HospitalEnfermeiro> HospitalEnfermeiro { get; set; }

  }
}