using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DigitalMark.Data;
using DigitalMark.Models;
using DigitalMark.ViewModels.HospitalViewModels;

namespace DigitalMark.Repositories 
{
  public class HospitalRepository
  {
    private readonly StoreDataContext _context;

    public HospitalRepository(StoreDataContext context)
    {
        _context = context;
    }

    public IEnumerable<ListHospitalViewModel> Get() {
      return _context.Hospital
              .Select(x => new ListHospitalViewModel
              {
                Id = x.Id,
                Nome = x.Nome,
                CNPJ = x.CNPJ,
                Cep = x.Cep,
                Logradouro = x.Logradouro
              })
              .AsNoTracking()
              .ToList();
    }

    public Hospital Get(int id)
    {
        return _context.Hospital.FirstOrDefault(x => x.Id == id);
    }

    public void Save(Hospital hospital) 
    {
        _context.Hospital.Add(hospital);
        _context.SaveChanges();

    }
    public void Update(Hospital hospital) 
    {
        _context.Entry<Hospital>(hospital).State = EntityState.Modified;
        _context.SaveChanges();
    }
    public void Delete(Hospital hospital) 
    {
        _context.Hospital.Remove(hospital);
        _context.SaveChanges();
    }

  }
}