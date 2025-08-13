using Microsoft.AspNetCore.Mvc;
using Kuafor.Web.Models;
using Microsoft.AspNetCore.OutputCaching;

namespace Kuafor.Web.Controllers;

public class HomeController : Controller
{
    // Basit bir ön bellek: 60sn (performans için)
    [OutputCache(Duration = 60)]
    public IActionResult Index()
    {
        var vm = new HomeViewModel
        {
            IsAuthenticated = User?.Identity?.IsAuthenticated ?? false,
            Services = new()
            {
                new ServiceItem
                {
                    Title = "Saç Kesimi",
                    Description = "Kişiye özel modern kesim.",
                    PriceFrom = 250,
                    IconSvg = "<i class='bi bi-scissors'></i>"
                },
                new ServiceItem
                {
                    Title = "Sakal Tıraşı",
                    Description = "Cilt tipine uygun bakım.",
                    PriceFrom = 150,
                    IconSvg = "<i class='bi bi-beard'></i>"
                },
                new ServiceItem
                {
                    Title = "Boya",
                    Description = "Profesyonel renk uygulamaları.",
                    PriceFrom = 600,
                    IconSvg = "<i class='bi bi-pallette'></i>"
                }
            },
            Testimonials = new()
            {
                new Testimonial { Name = "Elif K.", Message = "Tam istediğim gibi oldu, çok memnun kaldım!", Rating = 5 },
                new Testimonial { Name = "Murat A.", Message = "Hızlı ve temiz iş, tavsiye ederim.", Rating = 4 },
                new Testimonial { Name = "Cem S.", Message = "Personel güler yüzlü, ortam ferah.", Rating = 5 },
            }
        };
        return View(vm);
    }
}
