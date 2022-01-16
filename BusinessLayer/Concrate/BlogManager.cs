using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> AllList()
        {
            return _blogDal.GetListAll();
        }

        public List<Blog> Get3Blogs()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }
        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory().Where(x=>x.Deleted==false).Where(x=>x.BlogStatus==true).ToList();
        }
       

        public List<Blog> GetBlogListWithWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterID == id);
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public Blog TGetByID(int id)
        {
            return _blogDal.GetByID(id);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }
        public List<Blog> CategoryByWriter(int id)
        {
            return _blogDal.GetCategoryByWriter(id);
        }
    }
}
