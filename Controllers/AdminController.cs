using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Models;

namespace Supermarket.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddMember()
        {
            return View();
        }
        public IActionResult DeleteMember()
        {
            return View();
        }
        public IActionResult EnquiryMember()
        {
            return View();
        }
        public IActionResult AmendMemberInfor()
        {
            return View();
        }
        public IActionResult AmendMemberLevel()
        {
            return View();
        }
        public IActionResult RecordShopInfor()
        {
            return View();
        }
        public IActionResult EnquiryShopInfor()
        {
            return View();
        }
        public IActionResult AmendShopInfor()
        {
            return View();
        }
        public IActionResult VipManage()
        {
            return View();
        }
        public IActionResult ImportMemberInfor()
        {
            return View();
        }
        public IActionResult ConsumptionStatistics()
        {
            return View();
        }
        public IActionResult TotalDiscountStatistics()
        {
            return View();
        }
        public IActionResult CreditsStatistics()
        {
            return View();
        }
    }
}
