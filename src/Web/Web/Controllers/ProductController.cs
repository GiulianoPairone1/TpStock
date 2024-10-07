﻿using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            if (products == null || !products.Any())
            {
                return NotFound("No se encontraron productos");
            }

            return Ok(products);
        }


        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            return Ok(_productService.Add(product));
        }

    }
}