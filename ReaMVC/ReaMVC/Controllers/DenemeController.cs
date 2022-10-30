using BusinessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ReaMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        PersonelMan pm = new PersonelMan(new PersonelRepostories());
        [HttpGet("GetMemberById")]
        public ActionResult<List<Personel>> GetMemberById()
        {
            var values = pm.Listing();
            return values;
        }
    }
}
