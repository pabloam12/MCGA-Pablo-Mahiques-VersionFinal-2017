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
    public class LocaleStringResourceDAC : ASF.Data.DataAccessComponent
    {

        public LocaleStringResource CreateLocaleStringResource(LocaleStringResource localeStringResource)
        {
            const string sqlStatement = @"
            INSERT INTO [dbo].[LocaleStringResource]
           ([ResourceValue]
           ,[LocaleResourceKey_Id]
           ,[Language_Id])
            VALUES
           (@ResourceValue
           ,@LocaleResourceKey_Id
           ,@Language_Id);
            SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@ResourceValue", DbType.String, localeStringResource.ResourceValue);
                db.AddInParameter(cmd, "@LocaleResourceKey_Id", DbType.Int32, localeStringResource.LocaleResourceKey_Id);
                db.AddInParameter(cmd, "@Language_Id", DbType.Int32, localeStringResource.Language_Id);
                // Obtener el valor de la primary key.
                localeStringResource.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return localeStringResource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localeStringResource"></param>
        public void UpdateById(LocaleStringResource localeStringResource)
        {
            const string sqlStatement = @"
            UPDATE [dbo].[LocaleStringResource]
            SET [ResourceValue] = @ResourceValue
            ,[LocaleResourceKey_Id] = @LocaleResourceKey
            ,[Language_Id] = @Language_Id
            WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@ResourceValue", DbType.String, localeStringResource.ResourceValue);
                db.AddInParameter(cmd, "@LocaleResourceKey_Id", DbType.Int32, localeStringResource.LocaleResourceKey_Id);
                db.AddInParameter(cmd, "@Language_Id", DbType.Int32, localeStringResource.Language_Id);
                db.AddInParameter(cmd, "@Id", DbType.Int32, localeStringResource.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.LocaleStringResource WHERE [Id]=@Id ";
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
        public LocaleStringResource SelectById(int id)
        {
            const string sqlStatement = @"
                  SELECT [Id]
                  ,[ResourceValue]
                  ,[LocaleResourceKey_Id]
                  ,[Language_Id]
                  FROM [dbo].[LocaleStringResource]
                  WHERE [Id]=@Id ";

            LocaleStringResource localeStringResource = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) localeStringResource = LoadLocaleStringResource(dr);
                }
            }

            return localeStringResource;
        }

        public LocaleStringResource SelectByLanguageAndKey(int language_Id, int localeResourceKey_Id)
        {
            const string sqlStatement = @"
                  SELECT [Id]
                  ,[ResourceValue]
                  ,[LocaleResourceKey_Id]
                  ,[Language_Id]
                  FROM [dbo].[LocaleStringResource]
                  WHERE [LocaleResourceKey_Id]=@LocaleResourceKey_Id AND [Language_Id]=@Language_Id";

            LocaleStringResource localeStringResource = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@LocaleResourceKey_Id", DbType.Int32, localeResourceKey_Id);
                db.AddInParameter(cmd, "@Language_Id", DbType.Int32, language_Id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) localeStringResource = LoadLocaleStringResource(dr);
                }
            }

            return localeStringResource;
        }

        public List<LocaleStringResource> SelectByLanguage_Id(int language_Id)
        {
            const string sqlStatement = @"
                  SELECT [Id]
                  ,[ResourceValue]
                  ,[LocaleResourceKey_Id]
                  ,[Language_Id]
                  FROM [dbo].[LocaleStringResource]
                  WHERE [Language_Id]=@Language_Id";

            var result = new List<LocaleStringResource>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Language_Id", DbType.Int32, language_Id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var localeStringResource = LoadLocaleStringResource(dr); // Mapper
                        result.Add(localeStringResource);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Crea un nueva LocaleStringResource desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto LocaleStringResource.</returns>		
        private static LocaleStringResource LoadLocaleStringResource(IDataReader dr)
        {
            var localeStringResource = new LocaleStringResource
            {
                Id = GetDataValue<int>(dr, "Id"),
                ResourceValue = GetDataValue<string>(dr, "ResourceValue"),
                LocaleResourceKey_Id = GetDataValue<int>(dr, "LocaleResourceKey_Id"),
                Language_Id = GetDataValue<int>(dr, "Language_Id")

            };
            return localeStringResource;
        }
    }
}