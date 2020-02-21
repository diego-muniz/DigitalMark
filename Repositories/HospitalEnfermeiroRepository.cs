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
                        Id = x.Id,
                        EnfermeiroId = x.Enfermeiro.Id,
                        HospitalId  = x.Hospital.Id,
                        Nome = x.Enfermeiro.Nome, 
                        CPF = x.Enfermeiro.CPF,
                        Coren = x.Enfermeiro.Coren,
                        DataNascimento = x.Enfermeiro.DataNascimento, 
                        Hospital = x.Hospital.Nome,
                        CNPJ = x.Hospital.CNPJ, 
                        Cep = x.Hospital.Cep,
                        UF = x.Hospital.UF,
                        Logradouro = x.Hospital.Logradouro,
                        Localidade = x.Hospital.Localidade,
                        Bairro = x.Hospital.Bairro,
                        Complemento = x.Hospital.Complemento,
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
                        EnfermeiroId = x.Enfermeiro.Id,
                        HospitalId  = x.Hospital.Id,
                        Nome = x.Enfermeiro.Nome, 
                        CPF = x.Enfermeiro.CPF,
                        Coren = x.Enfermeiro.Coren,
                        DataNascimento = x.Enfermeiro.DataNascimento, 
                        Hospital = x.Hospital.Nome,
                        CNPJ = x.Hospital.CNPJ, 
                        Cep = x.Hospital.Cep,
                        UF = x.Hospital.UF,
                        Logradouro = x.Hospital.Logradouro,
                        Localidade = x.Hospital.Localidade,
                        Bairro = x.Hospital.Bairro,
                        Complemento = x.Hospital.Complemento,
                     })
                     .FirstOrDefault(x => x.EnfermeiroId == id);
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