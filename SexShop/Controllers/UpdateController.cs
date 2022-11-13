using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using SexShop.DataAccessLayer.Interfaces;
using SexShop.Domain.Entity;
using SexShop.Service.Interfaces;

namespace SexShop.Controllers;

public class UpdateController : Controller
{
    private readonly ILogger<UpdateController> _logger;
    private readonly IProductService _productService;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IColorRepository _colorRepository;
    private readonly IPackRepository _packRepository;
    private readonly IImageRepository _imageRepository;
    private readonly IProductColorRepository _productColorRepository;

    public UpdateController(ILogger<UpdateController> logger, IProductService productService,
        IManufacturerRepository manufacturerRepository, ICategoryRepository categoryRepository,
        ISubCategoryRepository subCategoryRepository, IColorRepository colorRepository, IPackRepository packRepository,
        IImageRepository pictureRepository, IProductColorRepository productColorRepository)
    {
        _logger = logger;
        _productService = productService;
        _manufacturerRepository = manufacturerRepository;
        _categoryRepository = categoryRepository;
        _subCategoryRepository = subCategoryRepository;
        _colorRepository = colorRepository;
        _packRepository = packRepository;
        _imageRepository = pictureRepository;
        _productColorRepository = productColorRepository;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var wc = new WebClient();
        await wc.DownloadFileTaskAsync(new Uri("http://stripmag.ru/datafeed/p5s_assort.csv"),
            $"{Environment.CurrentDirectory}\\data.csv");

        #region General

        using (var tfp = new TextFieldParser($"{Environment.CurrentDirectory}\\data.csv"))
        {
            tfp.TextFieldType = FieldType.Delimited;
            tfp.SetDelimiters(";");


            while (!tfp.EndOfData)
            {
                var fields = tfp.ReadFields();
                if (fields == null) continue;
                if (fields[0] == "Артикул") continue;

                #region Category

                // Добавляем категории
                await _categoryRepository.Create(new Category { Name = fields[1] });

                #endregion

                #region Manufacturer

                // Добавляем производителей
                await _manufacturerRepository.Create(new Manufacturer { Name = fields[5] });

                #endregion

                #region Colors

                // Добавляем цвета
                await _colorRepository.Create(new Color { Name = fields[13], HexCode = "#66666666" });

                #endregion

                #region Packs

                // Добавляем упаковки
                await _packRepository.Create(new Pack { Name = fields[17] });

                #endregion

                #region Sizes

                // Добавляем размеры
                // await _colorRepository.Create(new Color { Name = fields[13] });

                #endregion
            }
        }

        #endregion

        #region SubCategories

        using (var tfp = new TextFieldParser($"{Environment.CurrentDirectory}\\data.csv"))
        {
            tfp.TextFieldType = FieldType.Delimited;
            tfp.SetDelimiters(";");

            var categories = await _categoryRepository.Select();
            while (!tfp.EndOfData)
            {
                var fields = tfp.ReadFields();
                if (fields == null) continue;
                if (fields[0] == "Артикул") continue;
                
                // Добавляем под категории
                if (categories.Any(x => x.Name == fields[1]))
                    await _subCategoryRepository.Create(new SubCategory
                        { Name = fields[2], Category = categories.First(x => x.Name == fields[1]) });
            }
        }

        #endregion

        #region Products

        using (var tfp = new TextFieldParser($"{Environment.CurrentDirectory}\\data.csv"))
        {
            tfp.TextFieldType = FieldType.Delimited;
            tfp.SetDelimiters(";");

            var subCategories = await _subCategoryRepository.Select();
            var manufacturers = await _manufacturerRepository.Select();

            while (!tfp.EndOfData)
            {
                var fields = tfp.ReadFields();
                if (fields == null) continue;
                if (fields[0] == "Артикул") continue;

                // 0: Артикул;
                // 1: Основная категория товара;
                // 2: Подраздел категории товара;
                // 3: Наименование;
                // 4: Описание;
                // 5: Производитель;
                // 6: Артикул производителя;
                // 7: Цена (Розница);
                // 8: Цена (Опт);
                // 9: Можно купить;
                // 10: На складе;
                // 11: Время отгрузки;
                // 12: Размер;
                // 13: Цвет;
                // 14: aID;
                // 15: Материал;
                // 16: Батарейки;
                // 17: Упаковка;
                // 18: Вес (брутто);
                // 19: Фотография маленькая до 150*150;
                // 20: Фотография 1;
                // 21: Фотография 2;
                // 22: Фотография 3;
                // 23: Фотография 4;
                // 24: Фотография 5;
                // 25: Штрихкод

                var price = decimal.Parse(fields[7].Replace('.', ','));
                var originPrice = decimal.Parse(fields[8].Replace('.', ','));
                var barCode = fields[25];

                var imageLink1 = fields[20];
                var imageLink2 = fields[21];
                var imageLink3 = fields[22];
                var imageLink4 = fields[23];
                var imageLink5 = fields[24];

                var manufacturer = await _manufacturerRepository.GetByName(fields[5]);
                
                var product = new Product
                {
                    Name = fields[3],
                    Article = int.Parse(fields[0]),
                    SubCategory = subCategories.First(x => x.Name == fields[2]),
                    Description = fields[4],
                    OriginPrice = originPrice,
                    Price = price,
                    VendorCode = fields[6],
                    BarCode = barCode,
                    Weight = string.IsNullOrWhiteSpace(fields[18]) ? null : int.Parse(fields[18]),
                    Battery = fields[16],
                    Manufacturer = manufacturer,
                };
                await _productService.Create(product);

                #region Colors

                // var color = new Color { Name = fields[13], HexCode = "#666666"};
                //
                // await _colorRepository.Create(color);

                var color = await _colorRepository.GetByName(fields[13]);
                
                // await 

                #endregion

                await _productColorRepository.Create(new ProductColor { Product = product, Color = color });

                #region Add Images

                if (!string.IsNullOrWhiteSpace(imageLink1))
                    await _imageRepository.Create(new Image
                    {
                        Link = imageLink1,
                        Product = product
                    });
                if (!string.IsNullOrWhiteSpace(imageLink2))
                    await _imageRepository.Create(new Image
                    {
                        Link = imageLink2,
                        Product = product
                    });
                if (!string.IsNullOrWhiteSpace(imageLink3))
                    await _imageRepository.Create(new Image
                    {
                        Link = imageLink3,
                        Product = product
                    });
                if (!string.IsNullOrWhiteSpace(imageLink4))
                    await _imageRepository.Create(new Image
                    {
                        Link = imageLink4,
                        Product = product
                    });
                if (!string.IsNullOrWhiteSpace(imageLink5))
                    await _imageRepository.Create(new Image
                    {
                        Link = imageLink5,
                        Product = product
                    });

                #endregion
            }
        }

        #endregion
        
        return View();
    }

    public async Task<IActionResult> LoadImage()
    {
        var images = await _imageRepository.Select();

        images.ForEach(async image =>
        {
            if (image.Product != null)
            {
                var product = await _productService.Get(image.Product.Id);
                product.Data.Images.Add(image);
            }
        });

        return View();
    }
}