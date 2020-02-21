using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DigitalMark.Data;
using DigitalMark.Models;
using DigitalMark.ViewModels.HospitalEnfermeiroViewModels;

namespace DigitalMark.Repositories 
{
  public class HospitalEnfermeiroRepository
  {
    private readonly StoreDataContext _context;

    public HospitalEnfermeiroRepository(StoreDataContext context)
    {
        _context = context;
    }

    public IEnumerable<ListHospitalEnfermeiroViewModel> Get() {
      return _context.HospitalEnfermeiro
                       .Include(x => x.Hospital)
                        .Include(x => x.Enfermeiro)
                     .Select(x => new ListHospitalEnfermeiroViewModel{
                       Enfermeiro = x.Enfermeiro,
                       Hospital = x.Hospital
                     })
                     .AsNoTracking()
                     .ToList();
    }

    public ListHospitalEnfermeiroViewModel Get(int id)
    {
        return _context.HospitalEnfermeiro
                       .Include(x => x.Hospital)
                        .Include(x => x.Enfermeiro)
                     .Select(x => new ListHospitalEnfermeiroViewModel{
                       Id = x.Id,
                       Enfermeiro = x.Enfermeiro,
                       Hospital = x.Hospital
                     })
                     .FirstOrDefault(x => x.Enfermeiro.Id == id);
    }

      public HospitalEnfermeiro GetHospitalEnfermeiro(int id)
    {
        return _context.HospitalEnfermeiro
                     .FirstOrDefault(x => x.Enfermeiro.Id == id);
    }

    public void Save(HospitalEnfermeiro hospitalEnfermeiro) 
    {
        _context.HospitalEnfermeiro.Add(hospitalEnfermeiro);
        _context.SaveChanges();

    }
    public void Update(HospitalEnfermeiro hospitalEnfermeiro) 
    {
        _context.Entry<HospitalEnfermeiro>(hospitalEnfermeiro).State = EntityState.Modified;
        _context.SaveChanges();
    }
    public void Delete(HospitalEnfermeiro hospitalEnfermeiro) 
    {
        _context.HospitalEnfermeiro.Remove(hospitalEnfermeiro);
        _context.SaveChanges();
    }

  }
}