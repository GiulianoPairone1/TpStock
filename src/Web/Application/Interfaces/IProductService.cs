﻿using Application.Models.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        List<ProductDTO> GetAll();
        ProductDTO GetByName(string name);
        ProductDTO Create(ProductDTO productDto);
    }
}
