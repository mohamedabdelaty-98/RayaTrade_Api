using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RayaTrade.Core;
using RayaTrade.Core.AutoMapper;
using RayaTrade.Core.DTO;
using RayaTrade.Core.Interfaces;
using RayaTrade.Core.Models;

namespace RayaTrade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork _unitofwork, IMapper _mapper)
        {
            this._unitofwork = _unitofwork;
            this._mapper = _mapper;
        }
        [HttpGet("GetAll")]
        public ActionResult<DTOResult> GetALl()
        {
           List<Product> products = _unitofwork.Products.GetAll();
           List<DTOProduct> dTOProducts=_mapper.Map<List<DTOProduct>>(products);
            DTOResult result = new DTOResult();
            result.IsPass=dTOProducts.Count!=0?true:false;
            result.Data=dTOProducts;
            return result;

        }

        [HttpGet("GetById/{id}")]
        public ActionResult<DTOResult> GetById(int id)
        {
            Product product = _unitofwork.Products.GetById(id);
            DTOProduct dTOProduct=_mapper.Map<DTOProduct>(product);
            DTOResult result = new DTOResult();
            if (dTOProduct != null)
            {
                result.IsPass = true;
                result.Data = dTOProduct;
            }
            else
            {
                result.IsPass = false;
                result.Data = "Product Not Found";
            }
            return result;
        }
        [HttpPost("Insert")]
        public ActionResult<DTOResult> Insert(DTOProduct dTOProduct)
        {
            DTOResult result = new DTOResult();
            if(ModelState.IsValid)
            {
                try
                {
                        Product product = _mapper.Map<Product>(dTOProduct);
                        _unitofwork.Products.Insert(product);
                        _unitofwork.Save();
                        result.IsPass = true;
                        result.Data = $"Created unit with ID {product.Id}";
                    
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException is SqlException sqlException &&
                        (sqlException.Number == 2601 || sqlException.Number == 2627))
                        result.Data = "This Product Already Exist";
                    else
                        result.Data = "An error occurred during update ";
                    result.IsPass = false;
                }
                catch (Exception ex) 
                {
                    result.IsPass = false;
                    result.Data = "An error occurred while creating the Product.";
                }
            }
            else
            {
                result.IsPass = false;
                result.Data = ModelState.Values.SelectMany(e => e.Errors)
                    .Select(e => e.ErrorMessage).ToList();
            }
            return result;
        }
        [HttpPost("Update")]
        public ActionResult<DTOResult> Update(DTOProduct dTOProduct)
        {
            DTOResult result = new DTOResult();
            if(ModelState.IsValid)
            {
                try
                {
                    Product product = _unitofwork.Products.GetById(dTOProduct.Id);
                    if (product!=null)
                    {
                        _mapper.Map(dTOProduct, product);
                        _unitofwork.Products.Update(product);
                        _unitofwork.Save();
                        result.IsPass = true;
                        result.Data = "Product Updated Successfuly";
                    }
                    else
                    {
                        result.IsPass = false;
                        result.Data = "Product Not Found";
                    }
                }
                catch(DbUpdateException ex)
                {
                    if (ex.InnerException is SqlException sqlException && 
                        (sqlException.Number == 2601 || sqlException.Number == 2627))
                        result.Data = "Name Of This Product Already Exist";
                    else
                        result.Data = "An error occurred during update ";
                    result.IsPass = false;
                }
                catch(Exception ex)
                {
                    result.IsPass = false;
                    result.Data = "An error occurred during update";
                }
            }
            else
            {
                result.IsPass = false;
                result.Data = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
            }
            return result;
        }
        [HttpDelete("Delete/{id}")]
        public ActionResult<DTOResult> Delete(int id) 
        {
            DTOResult result = new DTOResult();
            Product product = _unitofwork.Products.GetById(id);
            if (product!=null)
            {
                _unitofwork.Products.Delete(product);
                _unitofwork.Save();
                result.IsPass = true;
                result.Data = "Product Has been deleted successfully";
            }
            else
            {
                result.IsPass = false;
                result.Data = "Product Not Found";
            }
            return result;
        }

        [HttpGet("FilterProductByName/{Name}")]
        public ActionResult<DTOResult> FilterProductByName(string Name)
        {
            List<Product> product =
                (List<Product>)_unitofwork.Products.FindAll(p => p.Name.Contains(Name));
            List<DTOProduct> dTOProduct = _mapper.Map<List<DTOProduct>>(product);
            DTOResult result = new DTOResult();
            if (dTOProduct.Count != 0)
            {
                result.IsPass = true;
                result.Data = dTOProduct;
            }
            else
            {
                result.IsPass = false;
                result.Data = "Product Not Found";
            }
            return result;
        }

        [HttpGet("FilterProductByPrice/{Price}")]
        public ActionResult<DTOResult> FilterProductByPrice(decimal Price)
        {
            List<Product> product =
                (List<Product>)_unitofwork.Products.FindAll(p=>p.Price==Price);
            List<DTOProduct> dTOProduct = _mapper.Map<List<DTOProduct>>(product);
            DTOResult result = new DTOResult();
            if(dTOProduct.Count != 0)
            {
                result.IsPass = true;
                result.Data = dTOProduct;
            }
            else
            {
                result.IsPass = false;
                result.Data = "Product Not Found";
            }
            return result;
        }
      
    }
}
