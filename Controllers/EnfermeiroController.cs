using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalMark.Models;
using DigitalMark.Repositories;
using DigitalMark.ViewModels;
using DigitalMark.ViewModels.EnfermeiroViewModels;

namespace DigitalMark.Controllers
{
    public class EnfermeiroController : Controller
    {

      // private readonly EnfermeiroRepository _enfermeiro;
      private readonly HospitalEnfermeiroRepository _hospEnfrepository;

      public EnfermeiroController(HospitalEnfermeiroRepository hospEnfrepository)
      {
          _hospEnfrepository = hospEnfrepository;
      }

      [Route("v1/enfermeiros")]
      [HttpGet]
      public IEnumerable<ListEnfermeiroViewModel> Get([FromServices] EnfermeiroRepository _enfermeiro) 
      {
        return _enfermeiro.Get();
      }

      [Route("v1/enfermeiros/{id}")]
      [HttpGet]
      public ResultViewModel Get([FromServices] HospitalEnfermeiroRepository _hospitalEnfermeiro,
                            int id) 
      {
        var detalhesEnfermeiro = _hospitalEnfermeiro.Get(id);

       if (detalhesEnfermeiro == null) {
        return new ResultViewModel
                {
                  Success = false,
                  Message = "Enfermeiro não encontrado !",
                  Data = null
                };
       }

       return new ResultViewModel
        {
          Success = true,
          Message = "Enfermeiro encontrado com sucesso !",
          Data = detalhesEnfermeiro
        };

      }

      [Route("v1/enfermeiros")]
      [HttpPost]
      public ResultViewModel Post([FromServices] EnfermeiroRepository _enfermeiro, 
                                  [FromServices] HospitalRepository _hospital,
                                  [FromBody] EditorEnfermeiroViewModel model) 
      {

        // model.Validate();
        // if (model.Invalid) {
        //   return new ResultViewModel
        //   {
        //     Success = false,
        //     Message = "Não foi possível cadastrar o produto",
        //     Data = model.Notifications
        //   };
        // }

        try
        {

        var hospital = _hospital.Get(model.HospitalId);

        if (hospital == null) {
          return new ResultViewModel
          {
            Success = false,
            Message = "Hospital não encontrado !",
            Data = null
          };
        }

        var enfermeiro = new Enfermeiro() {
          Id = model.Id,
          Nome = model.Nome,
          CPF = model.CPF,
          Coren = model.Coren,
          DataNascimento = model.DataNascimento,
          CreatedAt = DateTime.Now,
          UpdatedAt = DateTime.Now
        };

        _enfermeiro.Save(enfermeiro);

        var hospEnfermeiro = new HospitalEnfermeiro() {
          HospitalId = model.HospitalId,
          EnfermeiroId = enfermeiro.Id,      
          CreatedAt = DateTime.Now,
          UpdatedAt = DateTime.Now
        };

        _hospEnfrepository.Save(hospEnfermeiro);

        var enfViewModel = new EditorEnfermeiroViewModel() {
          Id = enfermeiro.Id,
          Nome = enfermeiro.Nome,
          CPF = enfermeiro.CPF,
          Coren = enfermeiro.Coren,
          DataNascimento = enfermeiro.DataNascimento,
          Hospital = hospital.Nome,
          HospitalId = hospital.Id
        };

        return new ResultViewModel
        {
          Success = true,
          Message = "Enfermeiro cadastrado com sucesso !",
          Data = enfViewModel
        };
        }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }

      }

      [Route("v1/enfermeiros")]
      [HttpPut]
      public ResultViewModel Put([FromServices] EnfermeiroRepository _enfermeiro, 
                                  [FromServices] HospitalRepository _hospital,
                                  [FromServices] HospitalEnfermeiroRepository _hospitalEnfermeiro,
                                  [FromBody] EditorEnfermeiroViewModel model) 
      {

        // model.Validate();
        // if (model.Invalid) {
        //   return new ResultViewModel
        //   {
        //     Success = false,
        //     Message = "Não foi possível cadastrar o produto",
        //     Data = model.Notifications
        //   };
        // }
        var hospital = _hospital.Get(model.HospitalId);

        if (hospital == null) {
          return new ResultViewModel
          {
            Success = false,
            Message = "Hospital não encontrado !",
            Data = null
          };
        }

        var enfermeiro = _enfermeiro.Get(model.Id);

        if (enfermeiro == null)  {
           return new ResultViewModel
          {
            Success = false,
            Message = "Enfermeiro não encontrado !",
            Data = null
          };
        }

          enfermeiro.Nome = model.Nome != null ? model.Nome : enfermeiro.Nome ;
          enfermeiro.CPF = model.CPF != null ? model.CPF : enfermeiro.CPF ;
          enfermeiro.Coren = model.Coren != null ? model.Coren : enfermeiro.Coren ;
          enfermeiro.DataNascimento = model.DataNascimento != null ? model.DataNascimento : enfermeiro.DataNascimento ;
          enfermeiro.UpdatedAt = DateTime.Now;

        _enfermeiro.Update(enfermeiro);

        var hospitalEnfermeiro = _hospitalEnfermeiro.GetHospitalEnfermeiro(enfermeiro.Id);
        hospitalEnfermeiro.HospitalId = hospital.Id;
        hospitalEnfermeiro.UpdatedAt = DateTime.Now;

        _hospitalEnfermeiro.Update(hospitalEnfermeiro);


        var enfViewModel = new EditorEnfermeiroViewModel() {
          Id = enfermeiro.Id,
          Nome = enfermeiro.Nome,
          CPF = enfermeiro.CPF,
          Coren = enfermeiro.Coren,
          DataNascimento = enfermeiro.DataNascimento,
          Hospital = hospital.Nome,
          HospitalId = hospital.Id
        };


        return new ResultViewModel
        {
          Success = true,
          Message = "Enfermeiro alterado com sucesso !",
          Data = enfViewModel
        };
      }

      [Route("v1/enfermeiros/{id}")]
      [HttpDelete]
      public ResultViewModel Delete([FromServices] EnfermeiroRepository _enfermeiro, 
                                    [FromServices] HospitalEnfermeiroRepository _hospitalEnfermeiro,
                                     int id) 
      {

        var hospitalEnfermeiro = _hospitalEnfermeiro.GetHospitalEnfermeiro(id);
        if (hospitalEnfermeiro != null) {
          _hospitalEnfermeiro.Delete(hospitalEnfermeiro);
        }

        var enfermeiro = _enfermeiro.Get(id);

       if (enfermeiro == null) {
        return new ResultViewModel
                {
                  Success = false,
                  Message = "Enfermeiro não encontrado !",
                  Data = null
                };
       }

         _enfermeiro.Delete(enfermeiro);

        return new ResultViewModel
        {
          Success = true,
          Message = "Enfermeiro deletado com sucesso !",
          Data = enfermeiro
        };
      }
    }
}