using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Models;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace Supermarket.Controllers
{
    public class AdminJobController : Controller
    {
        // GET: /<controller>/
        /// <summary>
        /// 添加新会员
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IActionResult AdminJob(string name, string phone, string password)
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
        /// <summary>
        /// 注销会员
        /// </summary>
        /// <param name="phonetail"></param>
        /// <returns></returns>
        public IActionResult DeleteByOneString(string phonetail)
        {
            using var context = new SupermarketDbContext();

            var members = context.Member.FirstOrDefault(x => x.Phone.Contains(phonetail));
            var id = members.Id;
            var mem2 = context.MemberLevelMapping.FirstOrDefault(x => x.MemberId.Equals(id));
            var mem3 = context.Statistics.FirstOrDefault(x => x.MemberId.Equals(id));

            context.Remove(mem2);
            context.Remove(mem3);
            context.Remove(members);
            context.SaveChanges();

            return View();
        }
        /// <summary>
        /// 会员信息查询
        /// </summary>
        /// <param name="phonetail"></param>
        /// <returns></returns>
        public IActionResult MemberDisplay(string phonetail)
        {
            using var context = new SupermarketDbContext();

            var members = new List<Member>();
            members = context.Member.Where(x => x.Phone.Contains(phonetail)).ToList();

            return View("MemberDisplay", members);
        }
        /// <summary>
        /// 会员信息修改
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="password"></param>
        /// <param name="nameafter"></param>
        /// <param name="phoneafter"></param>
        /// <param name="passwordafter"></param>
        /// <returns></returns>
        public IActionResult AmendInfor(string name, string phone, string password,string nameafter, string phoneafter, string passwordafter)
        {
            using var context = new SupermarketDbContext();

            var members = context.Member.FirstOrDefault(x => x.Phone.Contains(phone));

            members.Name = nameafter;
            members.Phone = phoneafter;
            members.Password = passwordafter;

            context.SaveChanges();

            return View();
        }
        /// <summary>
        /// 会员等级修改
        /// </summary>
        /// <param name="memberid"></param>
        /// <param name="levelafter"></param>
        /// <returns></returns>
        public IActionResult MemberLevelChange(int memberid, int levelafter)
        {
            using var context = new SupermarketDbContext();

            var levelitems = context.MemberLevelMapping.FirstOrDefault(x => x.MemberId.Equals(memberid));
            levelitems.LevelId = levelafter;

            context.SaveChanges();

            return View();
        }
        /// <summary>
        /// 增加会员消费记录
        /// </summary>
        /// <param name="memberid"></param>
        /// <param name="goodid"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public IActionResult RecordShopJob(int memberid, int goodid, int quantity)
        {
            using var context = new SupermarketDbContext();
            var shopitems = new MemberGoodMapping()
            {
                Id = Guid.NewGuid().ToString(),
                CreateTime = DateTime.Now.ToString()
            };
            shopitems.MemberId = memberid;
            shopitems.GoodId = goodid;
            shopitems.Quantity = quantity;

            

            //var find1 = context.Good.FirstOrDefault(x => x.Id.Equals(goodid));
            //find1.Price

            context.MemberGoodMapping.Add(shopitems);
            context.SaveChanges();

            return View();
        }
        /// <summary>
        /// 查询会员消费记录
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public IActionResult EnquiryShopJob(int memberid)
        {
            using var context = new SupermarketDbContext();

            var shopItems = new List<MemberGoodMapping>();
            shopItems = context.MemberGoodMapping.Where(x => x.MemberId.Equals(memberid)).ToList();

            return View("EnquiryShopJob", shopItems);
        }
        /// <summary>
        /// 修改会员消费记录
        /// </summary>
        /// <param name="memberid"></param>
        /// <param name="goodid"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public IActionResult AmendShopJob(int memberid, int goodid ,int quantity)
        {
            using var context = new SupermarketDbContext();

            var gooditems = context.MemberGoodMapping.FirstOrDefault(x => x.MemberId.Equals(memberid));

            gooditems.GoodId = goodid;
            gooditems.Quantity = quantity;

            context.SaveChanges();

            return View();
        }
        /// <summary>
        /// 会员制度管理
        /// </summary>
        /// <param name="viplevelid"></param>
        /// <param name="levelrateafter"></param>
        /// <returns></returns>
        public IActionResult VipManageJob(int viplevelid, double levelrateafter)
        {
            using var context = new SupermarketDbContext();

            var levelitems = context.Level.FirstOrDefault(x => x.Id.Equals(viplevelid));

            levelitems.DiscountRate = levelrateafter;

            context.SaveChanges();

            return View();
        }
        /// <summary>
        /// 用户信息导入
        /// </summary>
        /// <returns></returns>
        public IActionResult ImportMemInfJob()
        {
            using var context = new SupermarketDbContext();
            
            StreamReader sr = new StreamReader("test.txt");

            string name, phone, password;

            for(int i = 0; i < 3; i++)
            {
                var member = new Member()
                {
                    Credit = 0
                };

                name = sr.ReadLine();
                member.Name = name;

                phone = sr.ReadLine();
                member.Phone = phone;
                
                password = sr.ReadLine();
                member.Password = password;

                context.Member.Add(member);
                context.SaveChanges();
            }

            return View();
        }
        /// <summary>
        /// 会员消费信息统计
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public IActionResult MemberStatistics(int memberid)
        {
            using var context = new SupermarketDbContext();

            var gooditems = new List<MemberGoodMapping>();
            gooditems = context.MemberGoodMapping.Where(x => x.MemberId.Equals(memberid)).ToList();

            return View("memberstatistics", gooditems);
        }
    }
}
