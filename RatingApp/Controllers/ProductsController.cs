using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatingApp.Database;
using RatingApp.Interfaces;
using RatingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Controllers
{
    public class ProductsController : Controller
    {
        SingleProductPageModel singleProductPageModel = new SingleProductPageModel();
        IProductController _productController;


        public ProductsController(IProductController productController)
        {
            _productController = productController;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SingelProduct(string slug)
        {
            singleProductPageModel.Product = _productController.GetProduct(slug);

            return View(singleProductPageModel);
        }

        [HttpPost]
        public IActionResult SaveProductRating(int productId, string radio, string slug)
        {
            var checkUser = _productController.GetUser();

            if (checkUser != null)
            {
                _productController.AddProductsRatingToDatabase(productId, int.Parse(radio), checkUser.Id);
            }
            else
            {
                return RedirectToRoute("login");
            }

            return RedirectToRoute("singleProduct", new { slug = slug});
        }
    }
}