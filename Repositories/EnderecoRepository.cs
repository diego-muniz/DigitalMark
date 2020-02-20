using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DigitalMark.Data;
using DigitalMark.Models;
using DigitalMark.ViewModels.HospitalViewModels;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System;

namespace DigitalMark.Repositories 
{
  public class EnderecoRepository
  {
    public async Task<ViaCep> BuscarPorCep(string cep) 
      {
        try
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");
            var endereco = JsonConvert.DeserializeObject<ViaCep>(json);

            return endereco;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

      }
  }
}