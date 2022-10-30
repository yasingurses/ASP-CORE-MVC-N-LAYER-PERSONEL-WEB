using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogMan : IBlogService
    {
        IBlog _blog;
       
         
        public BlogMan(IBlog blog)
        {
            _blog = blog;
        }

        public void Adding(Blog blo)
        {
            _blog.ekle(blo);
        }

        public void Deleteing(Blog Blo)
        {
            _blog.Sil(Blo);
        }

        public Blog Getir(int id)
        {
            return _blog.Get(id);
        }

        public List<Blog> Listing()
        {
           return _blog.Listele();
        }

        public void Updating(Blog blo)
        {
            _blog.guncelle(blo);
        }
    }
}
