using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DigitalMark.Data;
using DigitalMark.Models;
using DigitalMark.ViewModels.EnfermeiroViewModels;

namespace DigitalMark.Repositories 
{
  public class EnfermeiroRepository
  {
    private readonly StoreDataContext _context;

    public EnfermeiroRepository(StoreDataContext context)
    {
        _context = context;
    }

    public IEnumerable<ListEnfermeiroViewModel> Get() {
      return _context.HospitalEnfermeiro
              .Include(x => x.Hospital)
              .Include(x => x.Enfermeiro)
              .Select(x => new ListEnfermeiroViewModel
              {
                Id = x.Enfermeiro.Id,
                Nome = x.Enfermeiro.Nome,
                CPF = x.Enfermeiro.CPF,
                Coren = x.Enfermeiro.Coren, 
                DataNascimento = x.Enfermeiro.DataNascimento,
                HospitalId = x.Hospital.Id,
                Hospital = x.Hospital
              })
              .AsNoTracking()
              .ToList();
    }

    public Enfermeiro Get(int id)
    {
        return _context.Enfermeiro.Find(id);
    }

    public void Save(Enfermeiro enfermeiro) 
    {
        _context.Enfermeiro.Add(enfermeiro);
        _context.SaveChanges();

    }
    public void Update(Enfermeiro enfermeiro) 
    {
        _context.Entry<Enfermeiro>(enfermeiro).State = EntityState.Modified;
        _context.SaveChanges();
    }
    public void Delete(Enfermeiro enfermeiro) 
    {
        _context.Enfermeiro.Remove(enfermeiro);
        _context.SaveChanges();
    }

  }
}