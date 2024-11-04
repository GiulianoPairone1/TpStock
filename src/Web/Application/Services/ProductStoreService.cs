using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductStoreService:IProductStoreService
    {
        private readonly IProductStoreRepository _productStoreRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IProductStoreRepository _productRepository;

        public ProductStoreService(IProductStoreRepository productStoreRepository, IStoreRepository storeRepository, IProductStoreRepository productRepository)
        {
            _productStoreRepository = productStoreRepository;
            _storeRepository = storeRepository;
            _productRepository = productRepository;
        }

        public void AddProductToStore(int productId, int storeId, int quantity)
        {
            var store = _storeRepository.FindByCondition(s => s.Id == storeId);
            var product = _productRepository.FindByCondition(p => p.Id == productId);

            if (store == null || product == null) return;

            var productStore = new ProductStore
            {
                ProductId = productId,
                StoreId = storeId,
                Quantity = quantity
            };
            _productStoreRepository.add(productStore);
        }

        public int GetProductQuantityInStore(int productId, int storeId)
        {
            return _productStoreRepository
                .FindByCondition(ps => ps.ProductId == productId && ps.StoreId == storeId)
                .Quantity;
        }

        public void UpdateProductInStore(int productId, int currentStoreId, int? newStoreId, int newQuantity)
        {
            var productStore = _productStoreRepository.FindByCondition(ps => ps.ProductId == productId && ps.StoreId == currentStoreId);

            if (productStore == null)
            {
                throw new InvalidOperationException("El producto no está en el almacén especificado.");
            }

            if (newStoreId.HasValue && newStoreId.Value != currentStoreId)
            {
                var newStore = _storeRepository.FindByCondition(s => s.Id == newStoreId.Value);
                if (newStore == null || !newStore.Active)
                {
                    throw new InvalidOperationException("El nuevo almacén no existe o está inactivo.");
                }

                productStore.StoreId = newStoreId.Value; 
            }

            if (newQuantity > 0)
            {
                productStore.Quantity = newQuantity;
            }
            else
            {
                throw new ArgumentException("La cantidad debe ser mayor a cero.");
            }

            _productStoreRepository.update(productStore); 
        }

    }
}
