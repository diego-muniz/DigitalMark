using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalMark.Models;
using DigitalMark.Repositories;
using DigitalMark.ViewModels;
using DigitalMark.ViewModels.HospitalViewModels;

namespace DigitalMark.Controllers
{
    public class HospitalController : Controller
    {

      private readonly HospitalRepository _repository;

      public HospitalController(HospitalRepository repository)
      {
          _repository = repository;
      }

      [Route("v1/hospitais")]
      [HttpGet]
      // [ResponseCache(Duration = 10)]
      public IEnumerable<ListHospitalViewModel> Get() 
      {
        return _repository.Get();
      }

      [Route("v1/hospitais/{id}")]
      [HttpGet]
      public Hospital Get(int id) 
      {
        return _repository.Get(id);
      }

      [Route("v1/hospitais-pornome/{hospital}")]
      [HttpGet]
      public IEnumerable<ListHospitalViewModel> ObterPorNome(string hospital) 
      {
        return _repository.ObterPorNome(hospital);
      }

      [Route("v1/hospitais")]
      [HttpPost]
      public ResultViewModel Post([FromBody] EditorHospitalViewModel model) 
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

        var hospital = new Hospital() {
          Nome = model.Nome,
          CNPJ = model.CNPJ,
          Cep = model.Cep,
          Logradouro = model.Logradouro,
          Complemento= model.Complemento,
          Bairro = model.Bairro,
          Localidade = model.Localidade,
          UF = model.UF,
          CreatedAt =  DateTime.Now,
          UpdatedAt =  DateTime.Now,
        };

        _repository.Save(hospital);

        return new ResultViewModel
        {
          Success = true,
          Message = "Hospital cadastrado com sucesso !",
          Data = hospital
        };
      }

      [Route("v1/hospitais")]
      [HttpPut]
      public ResultViewModel Put([FromBody] EditorHospitalViewModel model) 
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

        var hospital = _repository.Get(model.Id);
          hospital.Nome = model.Nome;
          hospital.CNPJ = model.CNPJ;
          hospital.Cep = model.Cep;
          hospital.Logradouro = model.Logradouro;
          hospital.Complemento= model.Complemento;
          hospital.Bairro = model.Bairro;
          hospital.Localidade = model.Localidade;
          hospital.UF = model.UF;
          hospital.UpdatedAt =  DateTime.Now;

        _repository.Update(hospital);

        return new ResultViewModel
        {
          Success = true,
          Message = "Hospital alterado com sucesso !",
          Data = hospital
        };
      }

      [Route("v1/hospitais/{id}")]
      [HttpDelete]
      public ResultViewModel Delete(int id) 
      {
        Hospital hospital = _repository.Get(id);
        _repository.Delete(hospital);

        return new ResultViewModel
        {
          Success = true,
          Message = "Hospital deletado com sucesso !",
          Data = hospital
        };
      }
    }
}