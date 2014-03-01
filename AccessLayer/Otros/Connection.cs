using System.Data.SqlClient;
using System.Configuration;


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
                 _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aPrestentationLayer.Properties.Settings.SGFConnectionString"].ConnectionString);
             return _connection;
         }
        }
    }

    }

