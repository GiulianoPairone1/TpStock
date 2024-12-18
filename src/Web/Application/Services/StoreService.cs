﻿using Application.Interfaces;
using Application.Models.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductStoreRepository _productStoreRepository;

        public StoreService(IStoreRepository storeRepository, IProductRepository productRepository, IProductStoreRepository productStoreRepository)
        {
            _storeRepository = storeRepository;
            _productRepository = productRepository;
            _productStoreRepository = productStoreRepository;
        }

        public List<StoreDTO> GetAll()
        {
            return _storeRepository.GetAll()
                .Select(store => StoreDTO.FromStore(store))
                .ToList();
        }

        public StoreDTO GetById(int id)
        {
            var store = _storeRepository.FindByCondition(s => s.Id == id);
            if (store == null) return null;
            return StoreDTO.FromStore(store);
        }

        public StoreDTO Create(StoreDTO storeDto)
        {
            var store = storeDto.ToStore();
            var addedStore = _storeRepository.add(store);
            return StoreDTO.FromStore(addedStore);
        }
        public void Update( StoreDTO storeDto)
        {
            var store = _storeRepository.FindByCondition(s => s.Name == storeDto.Name);
            if (store != null)
            {
                storeDto.UpdateStore(store);
                _storeRepository.update(store);
            }
        }

        public void DesactivateStoreByName(string name)
        {
            var store = _storeRepository.FindByCondition(s => s.Name == name);
            if (store != null && store.Active)
            {
                store.Active = false;
                _storeRepository.update(store);
            }
        }
    }
}
