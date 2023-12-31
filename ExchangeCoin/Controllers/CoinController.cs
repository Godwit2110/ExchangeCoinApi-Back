﻿using ConversionDeMonedas.Data;
using ConversionDeMonedas.Entities;
using ConversionDeMonedas.Models.Dtos;
using ConversionDeMonedas.Services.Implementations;
using ExchangeCoinApi.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExchangeCoinApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoinController : ControllerBase
    {
        private readonly CoinService _coinService; ConversionDeMonedasContext _CDMContext;

        public CoinController(CoinService coinService, ConversionDeMonedasContext cdmContext)
        {
            _coinService = coinService;
            _CDMContext = cdmContext;
        }
        [HttpGet("Convertir")]

        public IActionResult Convert([FromQuery] double amount, [FromQuery] ToConvert toConvert)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            Usuario? usuario = _CDMContext.usuario.SingleOrDefault(u => u.Id == userId);

            if (usuario.TotalConversiones != 0)
            {
                try
                {
                    double result = _coinService.Convert(usuario, amount, toConvert);
                    usuario.TotalConversiones -= 1;
                    _CDMContext.SaveChanges();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            else
            {
                double result = -1;
                return Ok(result);
            }
        }

        [HttpPost("CrearMoneda")]

        public IActionResult CreateCoin(CreateAndUpdateCoinDto dto)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            try
            {
                _coinService.CreateCoin(userId, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok("Creada Correctamente");
        }

        [HttpPut("EditarMoneda")]
        public IActionResult UpdateCoin(int CoinId, string leyenda, CreateAndUpdateCoinDto dto)
        {
            try
            {
                _coinService.UpdateCoin(CoinId, leyenda, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok("Editada Correctamente");
        }

        [HttpDelete("EliminarMoneda")]

        public IActionResult DeleteCoin(int CoinId, string leyenda)
        {
            try
            {
                _coinService.DeleteCoin(CoinId, leyenda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok("Eliminada Correctamente");
        }
    }
}