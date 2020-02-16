using System;
using System.Collections.Generic;

namespace DigitalMark.Models 
{
  public class Hospital {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; }
    public string UF { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public IEnumerable<Enfermeiro> Enfermeiro { get; set; }

   
  }
}