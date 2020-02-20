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
    public Enfermeiro Enfermeiro { get; set; }
    public Hospital Hospital { get; set; }

  }
}