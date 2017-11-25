using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary;
using ASF.Entities;

namespace ASF.Data
{
   public class CountryDAC : DataAccessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Country"></param>
        /// <returns></returns>
        public Country Create(Country Country)
        {
            const string sqlStatement = "INSERT INTO dbo.Country ([Name], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@Name, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, Country.Name);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, Country.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, Country.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, Country.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, Country.ChangedBy);
                // Obtener el valor de la primary key.
                Country.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return Country;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Country"></param>
        public void UpdateById(Country Country)
        {
            const string sqlStatement = "UPDATE dbo.Country " +
                "SET [Name]=@Name, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, Country.Name);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, Country.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, Country.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, Country.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, Country.ChangedBy);
                db.AddInParameter(cmd, "@Id", DbType.Int32, Country.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Country WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Country SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Name], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Country WHERE [Id]=@Id ";

            Country Country = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) Country = LoadCountry(dr);
                }
            }

            return Country;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Country> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [Name], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Country ";

            var result = new List<Country>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var Country = LoadCountry(dr); // Mapper
                        result.Add(Country);
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
        private static Country LoadCountry(IDataReader dr)
        {
            var Country = new Country
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return Country;
        }
    }
}
