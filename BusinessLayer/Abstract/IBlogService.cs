using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
       
        // kategoriye göre blog getir
        List<Blog> GetBlogListWithCategory();
        // Yazara Göre blog getir
        List<Blog> GetBlogListWithWriter(int id); 
        
    }
}
