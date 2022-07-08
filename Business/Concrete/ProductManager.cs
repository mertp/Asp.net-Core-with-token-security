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
    public class ProductManager : IProductService
    {
        //Dependency Injection
        private IProductDal productDal;

        //BusinessLayer
        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public IResult Add(Product product)
        {

            if (product.Discontinued)
            {
                product.ProductName = "isContinued";

                productDal.Update(product);
            }
            productDal.Add(product);
            
            //Using success result 
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
        public IResult Update(Product product)
        {
            productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(productDal.GetList().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(productDal.GetList(p => p.CategoryID == categoryId).ToList());
        }

        public IDataResult<Product> GetProductById(int Productid)
        {
            return new SuccessDataResult<Product>(productDal.Get(p => p.ProductID == Productid));
        }

        
    }
}
