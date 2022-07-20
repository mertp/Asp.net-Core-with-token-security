using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static  class Messages
    {
        public static string ProductAdded = "Product has been added successfully";
        public static string ProductDeleted = "Product has been deleted successfully";
        public static string ProductUpdated = "Product has been updated successfully";
        public static string CategoryAdded = "Category has been added successfully";
        public static string CategoryDeleted = "Category has been deleted successfully";
        public static string CategorUpdated = "Category has been updated successfully";
        public static string UserNotFound = "User is not found";

        public static string PasswordError = "Password is wrong";

        public static string SuccessfullLogin = "Login is successfull";

        public static string UserAlreadyExists = "User already exists";

        public static string UserRegistered = "User registered successfully";
        public static string AccessTokenCreated = "Access token created successfully";
    }
}
