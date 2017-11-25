using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary;
using ASF.Entities;

namespace ASF.Data
{
    public class ClientDAC : DataAccessComponent
    {

        public Client Create ( Client Client )
        {
            const string sqlStatement = "INSERT INTO dbo.Client ([FirstName], [LastName], [Email], [CountryId], [AspNetUsers], [City], [SignupDate], [Rowid], [OrderCount], " + 
                "[CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@FirstName, @LastName, @Email, @CountryId, @AspNetUsers, @City, @SignupDate, @Rowid, @OrderCount, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); " + 
                "SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase( ConnectionName );
            using (var cmd = db.GetSqlStringCommand( sqlStatement ))
            {
                db.AddInParameter( cmd, "@FirstName", DbType.String, Client.FirstName );
                db.AddInParameter( cmd, "@LastName", DbType.String, Client.LastName );
                db.AddInParameter( cmd, "@Email", DbType.String, Client.Email );
                db.AddInParameter( cmd, "@CountryId", DbType.Int32, Client.CountryId );
                db.AddInParameter( cmd, "@AspNetUsers", DbType.String, Client.AspNetUsers );
                db.AddInParameter( cmd, "@City", DbType.String, Client.City );
                db.AddInParameter( cmd, "@SignupDate", DbType.DateTime, Client.SignupDate );
                db.AddInParameter( cmd, "@Rowid", DbType.Guid, Client.Rowid );
                db.AddInParameter( cmd, "@OrderCount", DbType.Int32, Client.OrderCount );
                db.AddInParameter( cmd, "@CreatedOn", DbType.DateTime2, Client.CreatedOn );
                db.AddInParameter( cmd, "@CreatedBy", DbType.Int32, Client.CreatedBy );
                db.AddInParameter( cmd, "@ChangedOn", DbType.DateTime2, Client.ChangedOn );
                db.AddInParameter( cmd, "@ChangedBy", DbType.Int32, Client.ChangedBy );
                // Obtener el valor de la primary key.
                Client.Id = Convert.ToInt32( db.ExecuteScalar( cmd ) );
            }

            return Client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Client"></param>
        public void UpdateById ( Client Client )
        {
            const string sqlStatement = "UPDATE dbo.Client " +
                "SET [FirstName]=@FirstName, " +
                    "[LastName]=@LastName, " +
                    "[Email]=@Email, " +
                    "[CountryId]=@CountryId, " +
                    "[AspNetUsers]=@AspNetUsers, " +
                    "[City]=@City, " +
                    "[SignupDate]=@SignupDate, " +
                    "[Rowid]=@Rowid, " +
                    "[OrderCount]=@OrderCount, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase( ConnectionName );
            using (var cmd = db.GetSqlStringCommand( sqlStatement ))
            {
                db.AddInParameter( cmd, "@FirstName", DbType.String, Client.FirstName );
                db.AddInParameter( cmd, "@LastName", DbType.String, Client.LastName );
                db.AddInParameter( cmd, "@Email", DbType.String, Client.Email );
                db.AddInParameter( cmd, "@CountryId", DbType.Int32, Client.CountryId );
                db.AddInParameter( cmd, "@AspNetUsers", DbType.String, Client.AspNetUsers );
                db.AddInParameter( cmd, "@City", DbType.String, Client.City );
                db.AddInParameter( cmd, "@SignupDate", DbType.DateTime, Client.SignupDate );
                db.AddInParameter( cmd, "@Rowid", DbType.Guid, Client.Rowid );
                db.AddInParameter( cmd, "@OrderCount", DbType.Int32, Client.OrderCount );
                db.AddInParameter( cmd, "@CreatedOn", DbType.DateTime2, Client.CreatedOn );
                db.AddInParameter( cmd, "@CreatedBy", DbType.Int32, Client.CreatedBy );
                db.AddInParameter( cmd, "@ChangedOn", DbType.DateTime2, Client.ChangedOn );
                db.AddInParameter( cmd, "@ChangedBy", DbType.Int32, Client.ChangedBy );
                db.AddInParameter( cmd, "@Id", DbType.Int32, Client.Id );

                db.ExecuteNonQuery( cmd );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById ( int id )
        {
            const string sqlStatement = "DELETE dbo.Client WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase( ConnectionName );
            using (var cmd = db.GetSqlStringCommand( sqlStatement ))
            {
                db.AddInParameter( cmd, "@Id", DbType.Int32, id );
                db.ExecuteNonQuery( cmd );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Client SelectById ( int id )
        {
            const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [Email], [CountryId], [AspNetUsers], [City], [SignupDate], [Rowid], [OrderCount], " + 
                " [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Client WHERE [Id]=@Id ";

            Client Client = null;
            var db = DatabaseFactory.CreateDatabase( ConnectionName );
            using (var cmd = db.GetSqlStringCommand( sqlStatement ))
            {
                db.AddInParameter( cmd, "@Id", DbType.Int32, id );
                using (var dr = db.ExecuteReader( cmd ))
                {
                    if (dr.Read()) Client = LoadClient( dr );
                }
            }

            return Client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Client> Select ()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [Email], [CountryId], [AspNetUsers], [City], [SignupDate], [Rowid], [OrderCount], " + 
                " [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Client ";

            var result = new List<Client>();
            var db = DatabaseFactory.CreateDatabase( ConnectionName );
            using (var cmd = db.GetSqlStringCommand( sqlStatement ))
            {
                using (var dr = db.ExecuteReader( cmd ))
                {
                    while (dr.Read())
                    {
                        var Client = LoadClient( dr ); // Mapper
                        result.Add( Client );
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Crea una nueva Categoría desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Categoria.</returns>		
        private static Client LoadClient ( IDataReader dr )
        {
            var Client = new Client
            {
                Id = GetDataValue<int>( dr, "Id" ),
                FirstName = GetDataValue<string>( dr, "FirstName" ),
                LastName = GetDataValue<string>( dr, "LastName" ),
                Email = GetDataValue<string>( dr, "Email" ),
                CountryId = GetDataValue<int>( dr, "CountryId" ),
                AspNetUsers = GetDataValue<string>( dr, "AspNetUsers" ),
                City = GetDataValue<string>( dr, "City" ),
                SignupDate = GetDataValue<DateTime>( dr, "SignupDate" ),
                Rowid = GetDataValue<Guid>( dr, "Rowid" ),
                OrderCount = GetDataValue<int>(dr, "OrderCount" ),
                CreatedOn = GetDataValue<DateTime>( dr, "CreatedOn" ),
                CreatedBy = GetDataValue<int>( dr, "CreatedBy" ),
                ChangedOn = GetDataValue<DateTime>( dr, "ChangedOn" ),
                ChangedBy = GetDataValue<int>( dr, "ChangedBy" )
            };
            return Client;
        }
    }
}
