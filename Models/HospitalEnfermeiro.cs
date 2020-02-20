using System;
using System.Collections.Generic;

namespace DigitalMark.Models 
{
  public class HospitalEnfermeiro {
    public int Id { get; set; }
    public int HospitalId { get; set; }    
    public Hospital Hospital { get; set; }
    public int EnfermeiroId { get; set; }
    public Enfermeiro Enfermeiro { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

   
  }
}