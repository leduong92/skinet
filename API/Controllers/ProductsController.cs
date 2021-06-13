using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interface;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Errors;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
      public class ProductsController : BaseApiController
      {
            private readonly IGenericRepository<Product> _productRepo;
            private readonly IGenericRepository<ProductBrand> _productBrandRepo;
            private readonly IGenericRepository<ProductType> _productTypeRepo;
            private readonly IMapper _mapper;

            public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> productBrandRepo
            , IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
            {
                  _mapper = mapper;
                  _productTypeRepo = productTypeRepo;
                  _productBrandRepo = productBrandRepo;
                  _productRepo = productRepo;

            }
            [HttpGet]
            public async Task<ActionResult<IReadOnlyList<ProductReturnDto>>> GetProducts()
            {
                  var spec = new ProductWithTypesAndBrandsSpecification();
                  var products = await _productRepo.ListAsync(spec);

                  return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductReturnDto>>(products));
                  
            }
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
            public async Task<ActionResult<ProductReturnDto>> GetProduct(int id)
            {
                  var spec = new ProductWithTypesAndBrandsSpecification(id);
                  var product = await _productRepo.GetEntityWithSpec(spec);
                  if (product == null)
                        return NotFound(new ApiResponse(404));
                  return _mapper.Map<Product, ProductReturnDto>(product);
            }

            [HttpGet("brands")]
            public async Task<ActionResult<ProductBrand>> GetProductBrands()
            {
                  var brands = await _productBrandRepo.ListAllAsync();
                  return Ok(brands);
            }


            [HttpGet("types")]
            public async Task<ActionResult<ProductType>> GetProductTypes()
            {
                  var types = await _productTypeRepo.ListAllAsync();
                  return Ok(types);
            }

      }
}