using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        void Adding(Blog blo);
        void Updating(Blog blo);
        void Deleteing(Blog Blo);
        List<Blog> Listing();
        Blog Getir(int id);
    }
}
