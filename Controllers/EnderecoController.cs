using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalMark.Models;
using DigitalMark.Repositories;
using DigitalMark.ViewModels;
using DigitalMark.ViewModels.HospitalViewModels;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DigitalMark.Controllers
{
    public class EnderecoController : Controller
    {
      private readonly EnderecoRepository _repository;
      public EnderecoController(EnderecoRepository repository)
      {
          _repository = repository;
      }

      [Route("v1/buscarcep/{cep}")]
      [HttpGet]
      public async Task<ResultViewModel> BuscarPorCep(string cep) 
      {
        try
        {
          var endereco = await _repository.BuscarPorCep(cep);

          return new ResultViewModel {
             Success = true,
             Message = "Endereço encontrado com sucesso !",
             Data = endereco
          };
        }
        catch (Exception ex)
        {
           throw new Exception(ex.Message);
        }

      }
    }
}