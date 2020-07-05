using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Models;

namespace Supermarket.Controllers
{
    public class MemberController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Enquiry()
        {
            return View();
        }
        public IActionResult Amend()
        {
            return View();
        }
        public IActionResult MemberJob(string name,string phone,string password)
        {
            using var context = new SupermarketDbContext();
            var member = new Member()
            {
                Credit = 0
            };
            member.Name = name;
            member.Phone = phone;
            member.Password = password;

            context.Member.Add(member);
            context.SaveChanges();

            return View();
        }
        public IActionResult MemberDisplay(string phonetail)
        {
            using var context = new SupermarketDbContext();

            var members = new List<Member>();
            members = context.Member.Where(x => x.Phone.Contains(phonetail)).ToList();

            return View("MemberDisplay", members);
        }
        public IActionResult MemAmendJob(string name, string phone, string password, string nameafter, string phoneafter, string passwordafter)
        {
            using var context = new SupermarketDbContext();

            var members = context.Member.FirstOrDefault(x => x.Phone.Contains(phone));

            members.Name = nameafter;
            members.Phone = phoneafter;
            members.Password = passwordafter;

            context.SaveChanges();

            return View();
        }
    }
}
