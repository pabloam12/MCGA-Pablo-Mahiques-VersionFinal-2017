using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ASF.Entities;

namespace ASF.Data
{
    public class CartDAC : DataAccessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CartItemDTO"></param>
        /// <returns></returns>
        public CartItemDTO Create(CartItemDTO CartItemDTO)
        {
            const string sqlStatement = "INSERT INTO dbo.CartItemDTO ([FirstName], [LastName], [CategoryId], [CountryId], [Description], [TotalProducts], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@FirstName, @LastName, @CategoryId, @CountryId, @Descritpion, @TotalProducts, @Rowid, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                //db.AddInParameter(cmd, "@FirstName", DbType.String, CartItemDTO.FirstName);
                //db.AddInParameter(cmd, "@LastName", DbType.String, CartItemDTO.LastName);
                //db.AddInParameter(cmd, "@CategoryId", DbType.Int32, CartItemDTO.CategoryId);
                //db.AddInParameter(cmd, "@CountryId", DbType.Int32, CartItemDTO.CountryId);
                //db.AddInParameter(cmd, "@Descritpion", DbType.String, CartItemDTO.Description);
                //db.AddInParameter(cmd, "@TotalProducts", DbType.Int32, CartItemDTO.TotalProducts);
                //db.AddInParameter(cmd, "@Rowid", DbType.Guid, CartItemDTO.Rowid);
                //db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, CartItemDTO.CreatedOn);
                //db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, CartItemDTO.CreatedBy);
                //db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, CartItemDTO.ChangedOn);
                //db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, CartItemDTO.ChangedBy);
                //// Obtener el valor de la primary key.
                //CartItemDTO.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return CartItemDTO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CartItemDTO"></param>
        public void UpdateById(CartItemDTO CartItemDTO)
        {
            const string sqlStatement = "UPDATE [dbo].[CartItemDTO] " +
                "SET [FirstName]=@FirstName, " +
                    "[LastName]=@LastName, " +
                    "[CategoryId]=@CategoryId, " +
                    "[CountryId]=@CountryId, " +
                    "[Description]=@Description, " +
                    "[TotalProducts]=@TotalProducts, " +
                    "[Rowid]=@Rowid, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                //db.AddInParameter(cmd, "@FirstName", DbType.String, CartItemDTO.FirstName);
                //db.AddInParameter(cmd, "@LastName", DbType.String, CartItemDTO.LastName);
                //db.AddInParameter(cmd, "@CategoryId", DbType.Int32, CartItemDTO.CategoryId);
                //db.AddInParameter(cmd, "@CountryId", DbType.Int32, CartItemDTO.CountryId);
                //db.AddInParameter(cmd, "@Description", DbType.String, CartItemDTO.Description);
                //db.AddInParameter(cmd, "@TotalProducts", DbType.Int32, CartItemDTO.TotalProducts);
                //db.AddInParameter(cmd, "@Rowid", DbType.Guid, CartItemDTO.Rowid);
                //db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, CartItemDTO.CreatedOn);
                //db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, CartItemDTO.CreatedBy);
                //db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, CartItemDTO.ChangedOn);
                //db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, CartItemDTO.ChangedBy);
                //db.AddInParameter(cmd, "@Id", DbType.Int32, CartItemDTO.Id);

                //db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.CartItemDTO WHERE [Id]=@Id ";
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
        public CartItemDTO SelectById(int id)
        {
            const string sqlStatement = @" SELECT [Id], [FirstName], [LastName], [CategoryId], [CountryId], [Description], [TotalProducts], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]
                FROM dbo.CartItemDTO WHERE [Id]=@Id ";

            CartItemDTO CartItemDTO = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                        CartItemDTO = LoadCartItemDTO(dr);
                }
            }

            return CartItemDTO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<CartItemDTO> Select()
        {
            // WARNING! Performance
            const string sqlStatement = @"SELECT [De].[Id], [De].[FirstName], [De].[LastName], [De].[CategoryId], [Ca].[Name] AS CategoryName, [De].[CountryId], [Co].[Name] AS CountryName, [De].[Description], 
                                        [De].[TotalProducts], [De].[Rowid], [De].[CreatedOn], [De].[CreatedBy], [De].[ChangedOn], [De].[ChangedBy] 
                                        FROM[dbo].[CartItemDTO] AS De INNER JOIN[dbo].[Country] AS Co 
                                        ON De.CountryId = Co.Id INNER JOIN[dbo].[Category] AS Ca 
                                        ON De.CategoryId = Ca.Id 
                                        order by [De].[Id] asc ";
            //const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [CategoryId], [CountryId], [Description], [TotalProducts], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], " +
            //    "[ChangedBy] FROM dbo.CartItemDTO ";

            var result = new List<CartItemDTO>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var CartItemDTO = LoadCartItemDTODTO(dr); // Mapper
                        result.Add(CartItemDTO);
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
        private static CartItemDTO LoadCartItemDTODTO(IDataReader dr)
        {
            var CartItemDTO = new CartItemDTO
            {
                //Id = GetDataValue<int>(dr, "Id"),
                //FirstName = GetDataValue<string>(dr, "FirstName"),
                //LastName = GetDataValue<string>(dr, "LastName"),
                //CategoryId = GetDataValue<int>(dr, "CategoryId"),
                //CategoryName = GetDataValue<string>(dr, "CategoryName"),
                //CountryId = GetDataValue<int>(dr, "CountryId"),
                //CountryName = GetDataValue<string>(dr, "CountryName"),
                //Description = GetDataValue<string>(dr, "Description"),
                //TotalProducts = GetDataValue<int>(dr, "TotalProducts"),
                //Rowid = GetDataValue<Guid>(dr, "Rowid"),
                //CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                //CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                //ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                //ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return CartItemDTO;
        }


        /// <summary>
        /// Crea una nueva Categoría desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Categoria.</returns>		
        private static CartItemDTO LoadCartItemDTO(IDataReader dr)
        {
            var CartItemDTO = new CartItemDTO
            {
                //Id = GetDataValue<int>(dr, "Id"),
                //FirstName = GetDataValue<string>(dr, "FirstName"),
                //LastName = GetDataValue<string>(dr, "LastName"),
                //CategoryId = GetDataValue<int>(dr, "CategoryId"),
                ////CategoryName = GetDataValue<string>( dr, "Name" ),
                //CountryId = GetDataValue<int>(dr, "CountryId"),
                ////CountryName = GetDataValue<string>( dr, "Name" ),
                //Description = GetDataValue<string>(dr, "Description"),
                //TotalProducts = GetDataValue<int>(dr, "TotalProducts"),
                //Rowid = GetDataValue<Guid>(dr, "Rowid"),
                //CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                //CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                //ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                //ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return CartItemDTO;
        }
    }
}
