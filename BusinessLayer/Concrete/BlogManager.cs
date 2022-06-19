using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogdal;

        public BlogManager(IBlogDal blogdal)
        {
            _blogdal = blogdal;
        }

     
        public List<Blog> GetBlogListWithCategory()
        {
            return _blogdal.GetListWithCategory().OrderByDescending(x=>x.BlogID).ToList();
        }
        public List<Blog> GetBlogListWithCategoryandWriter()
        {
            return _blogdal.GetListWithCategoryandWriter();
        }
        public List<Blog> GetBlogListWithCategoryLast3Blog()
        {
            return _blogdal.GetListWithCategory().TakeLast(4).ToList(); 
        }
        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return _blogdal.GetListWithCategoryByWriter(id);

        }

        public Blog TGetByID(int id)
        {
            return _blogdal.GetByID(id);
        }
        public List<Blog> GetBlogByID(int id)
        {
            return _blogdal.GetListAll(x => x.BlogID == id);
        }

        public List<Blog> GetList()
        {
            return _blogdal.GetListAll();
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogdal.GetListAll().TakeLast(3).ToList();
        }      
        public List<Blog> GetBlogListWithWriter(int id)
        {
            return _blogdal.GetListAll(x => x.WriterID == id) ;
        }

        public void TAdd(Blog t)
        {
            _blogdal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogdal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogdal.Update(t);
        }

        public void TUpdateDurum(Blog blog)
        {
            if(blog.BlogStatus == false)
            {
                blog.BlogStatus = true;
                _blogdal.Update(blog);
            }
            else
            {
                blog.BlogStatus = false;
                _blogdal.Update(blog);
            }
        }
    }
}
