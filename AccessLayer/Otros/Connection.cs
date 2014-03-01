using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace DataAccessLayer.Otros
{
    class Connection
    {

        private Connection() 
        { }
      
        //Metodo Singlenton
        private static SqlConnection _connection = null;

        public static SqlConnection Get
        {
            get
         {
             if (_connection == null)
                 _connection = new SqlConnection(@"data source = HOEPELMAN-PC\SQLEXPRESS; integrated security = true; initial catalog = SGF; user id = sa; password = Dylan300903");
             return _connection;
         }
        }
    }

    }

