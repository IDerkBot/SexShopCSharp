using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using SexShop.DataAccessLayer.Interfaces;
using SexShop.Domain.Entity;
using SexShop.Models;
using SexShop.Service.Interfaces;

namespace SexShop.Controllers;

/// <summary>
/// Контроллер товара
/// </summary>
public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;
    private readonly IImageRepository _imageRepository;
    private readonly IManufacturerRepository _manufacturerRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="productService"></param>
    public ProductController(ILogger<ProductController> logger, IProductService productService,
        IImageRepository imageRepository, IManufacturerRepository manufacturerRepository)
    {
        _logger = logger;
        _productService = productService;
        _imageRepository = imageRepository;
        _manufacturerRepository = manufacturerRepository;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProducts(20);
        // var products = await _productService.GetProducts();
        foreach (var product in products.Data)
        {
            var manufacturer = await _manufacturerRepository.Get(product.ManufacturerId ?? 1);
            var images = await _imageRepository.GetAllByProduct(product);
            product.Manufacturer = manufacturer;
            product.Images = images;
        }

        return View(products.Data);
    }

    [HttpGet]
    public async Task<IActionResult> Product(int id)
    {
        var product = (await _productService.Get(id)).Data;
        
        var manufacturer = await _manufacturerRepository.Get(product.ManufacturerId ?? 1);
        var images = await _imageRepository.GetAllByProduct(product);
        product.Manufacturer = manufacturer;
        product.Images = images;

        return View(product);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}