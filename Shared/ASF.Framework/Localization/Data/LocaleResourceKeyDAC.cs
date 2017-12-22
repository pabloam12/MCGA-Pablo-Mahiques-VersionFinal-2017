using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ASF.Framework.Localization.Entities;

namespace ASF.Framework.Localization.Data
{
    public class LocaleResourceKeyDAC : ASF.Data.DataAccessComponent
    {

        public LocaleResourceKey CreateLocaleResourceKey(LocaleResourceKey localeResourceKey)
        {
            const string sqlStatement = @"
        INSERT INTO [dbo].[LocaleResourceKey]
           ([Name]
           ,[Notes]
           ,[DateAdded])
        VALUES
           (@Name
           ,@Notes
           ,@DateAdded); 
            SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, localeResourceKey.Name);
                db.AddInParameter(cmd, "@Notes", DbType.String, localeResourceKey.Notes);
                db.AddInParameter(cmd, "@DateAdded", DbType.DateTime, localeResourceKey.DateAdded);
                // Obtener el valor de la primary key.
                localeResourceKey.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return localeResourceKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localeResourceKey"></param>
        public void UpdateById(LocaleResourceKey localeResourceKey)
        {
            const string sqlStatement = @"
            UPDATE [dbo].[LocaleResourceKey]
            SET [Name] = @Name
            ,[Notes] = @Notes
            ,[DateAdded] = @DateAdded
            WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, localeResourceKey.Name);
                db.AddInParameter(cmd, "@Notes", DbType.String, localeResourceKey.Notes);
                db.AddInParameter(cmd, "@DateAdded", DbType.DateTime, localeResourceKey.DateAdded);
                db.AddInParameter(cmd, "@Id", DbType.Int32, localeResourceKey.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.LocaleResourceKey WHERE [Id]=@Id ";
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
        public LocaleResourceKey SelectById(int id)
        {
            const string sqlStatement = @"
                  SELECT [Id]
                  ,[Name]
                  ,[Notes]
                  ,[DateAdded]
                  FROM [dbo].[LocaleResourceKey]
                  WHERE [Id]=@Id ";

            LocaleResourceKey localeResourceKey = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) localeResourceKey = LoadLocaleResourceKey(dr);
                }
            }

            return localeResourceKey;
        }

        public LocaleResourceKey SelectByName(string name)
        {
            const string sqlStatement = @"
                  SELECT [Id]
                  ,[Name]
                  ,[Notes]
                  ,[DateAdded]
                  FROM [dbo].[LocaleResourceKey]
                  WHERE [Name]=@Name";

            LocaleResourceKey localeResourceKey = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, name);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) localeResourceKey = LoadLocaleResourceKey(dr);
                }
            }

            return localeResourceKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<LocaleResourceKey> Select()
        {
            // WARNING! Performance
            const string sqlStatement = @"
                  SELECT [Id]
                  ,[Name]
                  ,[Notes]
                  ,[DateAdded]
                  FROM [dbo].[LocaleResourceKey]";

            var result = new List<LocaleResourceKey>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var localeResourceKey = LoadLocaleResourceKey(dr); // Mapper
                        result.Add(localeResourceKey);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Crea un nueva LocaleResourceKey desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto LocaleResourceKey.</returns>		
        private static LocaleResourceKey LoadLocaleResourceKey(IDataReader dr)
        {
            var localeResourceKey = new LocaleResourceKey
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name"),
                Notes = GetDataValue<string>(dr, "Notes"),
                DateAdded = GetDataValue<DateTime>(dr, "DateAdded")
            };
            return localeResourceKey;
        }
    }
}
