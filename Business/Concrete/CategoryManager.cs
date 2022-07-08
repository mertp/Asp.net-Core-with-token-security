using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }
       

        public IResult Add(Category category)
        {
            categoryDal.Add(category);
            //Using success result 
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(Category category)
        {
            categoryDal.Delete(category);
            //Using success result 
            return new SuccessResult(Messages.CategoryDeleted);
        }
        public IResult Update(Category category)
        {
            categoryDal.Update(category);
            //Using success result 
            return new SuccessResult(Messages.CategorUpdated);
        }
        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(categoryDal.GetList().ToList());
        }

        public IDataResult<Category> GetCategoryById(int Categoryid)
        {
            return new SuccessDataResult<Category>(categoryDal.Get(p => p.CategoryId == Categoryid));
        }

        public IResult DeletebyId(int Categoryid, Category category)
        {
            categoryDal.Delete(category);
            //Using success result 
            return new SuccessResult(Messages.CategoryDeleted);
        }
    }

}

