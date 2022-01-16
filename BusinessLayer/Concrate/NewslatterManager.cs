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
    public class NewslatterManager : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;

        public NewslatterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }

        public void AddNewsLetter(NewsLater newsLater)
        {
            _newsLetterDal.Insert(newsLater);
        }

        public List<NewsLater> GetList()
        {
            return _newsLetterDal.GetListAll();
        }
    }
}
