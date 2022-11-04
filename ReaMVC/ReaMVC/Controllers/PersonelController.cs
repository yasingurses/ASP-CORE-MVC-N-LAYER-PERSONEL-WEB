using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReaMVC.Controllers
{
    public class PersonelController : Controller
    {
        PersonelMan pm = new PersonelMan(new PersonelRepostories());
        private readonly IToastNotification _toastNotification;

        public PersonelController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        [Authorize(Roles ="izmir")]
        public IActionResult Index()
        {
            var values = pm.Listing();
            return View(values);
        }
        public IActionResult Main()
        {
            return View();

        }
        public IActionResult About()
        {
            return View();

        }
        public IActionResult experience()
        {
            return View();

        }
        public IActionResult education()
        {
            return View();

        }
      
        public IActionResult skills()
        {
            return View();

        }
        public IActionResult interests()
        {
            return View();

        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Login(Personel pers)
        {
            Context c = new Context();
            var admingiris = c.Personels.FirstOrDefault(x => x.PersonelName == pers.PersonelName && x.PersonelPassword == pers.PersonelPassword);
            if (admingiris != null)//eğer textler boş gelmez ise
            {
                var claims = new List<Claim> // claim ypaısı oluşuyor
                { new Claim(ClaimTypes.Name,admingiris.PersonelName),
                 new Claim(ClaimTypes.Role, admingiris.PersonelAdress)
                };
                

                var useridentity = new ClaimsIdentity(claims, "Login");//identitiy tanımı yapıp loginden aldırıyoruz.
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);//burdaki principal sorgu alanım.
                                                                              //ve bu alandan loginden gelenleri sorguluyorum.
                await HttpContext.SignInAsync(principal);//await kullanıp işlem sıramı düzenledim.
                _toastNotification.AddSuccessToastMessage("Başarılı giriş");
                if (TempData["returnUrl"] != null)
                {
                    if (Url.IsLocalUrl(TempData["returnUrl"].ToString()))
                    {
                        return Redirect(TempData["returnUrl"].ToString());
                    }
                }
                else
                {
                    return RedirectToAction("About", "Personel");
                }

            }
            _toastNotification.AddErrorToastMessage("Bilgileriniz yanlış");
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Cik()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login", "Personel");
        }
        public IActionResult Ekle()
        {
            return View();

        }
        [HttpPost]

        public IActionResult Ekle(Personel pers)
        {
            pm.Adding(pers);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Guncelle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guncelle(Personel pers)
        {
            pm.Updating(pers);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Personel pers)
        {

            pm.Deleteing(pers);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Sil(int id)
        {
            using (Context db = new Context())
            {
                var result = db.Personels.FirstOrDefault(o => o.PersonelID == id);
                db.Personels.Remove(result);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Guncelle2(int id)
        {
            using (Context db = new Context())
            {
                var result = db.Personels.FirstOrDefault(o => o.PersonelID == id);
                if (result==null)
                {
                    _toastNotification.AddErrorToastMessage("Böyle bir kullanucu yok");
                }
                return View(result);
            }
        }
        [HttpPost]
        public IActionResult Guncelle2(Personel pers)
        {
            var result =  pm.Updating(pers);
            if (result)
            {
                _toastNotification.AddSuccessToastMessage($"{pers.PersonelName} isimli personel güncellendi");
            }
            else
            {
                _toastNotification.AddErrorToastMessage($"{pers.PersonelName} isimli personel güncellenemedi");
            }
            return RedirectToAction("Index");
        }
        public IActionResult PersonelList()
        {
            var values = pm.Listing();
            return View(values);
        }
        [Authorize(Roles ="nus")]
        public IActionResult PersonelMuhasabe()
        {
            var values = pm.Listing();
            return View(values);
        }

    }
}
