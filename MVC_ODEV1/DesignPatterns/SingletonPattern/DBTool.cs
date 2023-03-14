using MVC_ODEV1.Models.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ODEV1.DesignPatterns.SingletonPattern
{
    public class DBTool
    {
        DBTool() { }

        static MyContext _dbInstance;


        public static MyContext _DBInstance
        {
            get
            {
                if (_dbInstance==null)
                {
                    _dbInstance = new MyContext();
                }
                return _dbInstance;
            }
        }


        
    }
}