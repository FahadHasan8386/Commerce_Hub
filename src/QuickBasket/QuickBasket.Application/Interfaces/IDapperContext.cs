using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QuickBasket.Application.Interfaces
{
    public interface IDapperContext
    {
        public  IDbConnection CreateConnection();       
    }
}
