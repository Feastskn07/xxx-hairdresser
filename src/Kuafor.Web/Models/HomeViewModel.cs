using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kuafor.Web.Models
{
    public class ServiceItem
    {
        public string IconSvg { get; set; } = "";
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal? PriceFrom { get; set; }
    }
    public class Testimonial
    {
        public string Name { get; set; } = "";
        public string Message { get; set; } = "";
        public int Rating { get; set; } = 5; // 1..5
    }
    public class HomeViewModel
    {
        public bool IsAuthenticated { get; set; }
        public List<ServiceItem> Services { get; set; } = new();
        public List<Testimonial> Testimonials { get; set; } = new();
    }
}