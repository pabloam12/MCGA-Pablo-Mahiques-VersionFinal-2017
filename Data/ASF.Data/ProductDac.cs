﻿using System;
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
    public class ProductDac : DataAccessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        public Product Create(Product Product)
        {
            const string sqlStatement = @"INSERT INTO dbo.Product ([Title], [Description], [DealerId], [Image], [Price], [QuantitySold], [AvgStars], [Rowid], [CreatedOn],
                                         [CreatedBy], [ChangedOn], [ChangedBy]) 
                                         VALUES (@Title, @Description, @DealerId, @Image, @Price, @QuantitySold, @AvgStars, @Rowid, @CreatedOn,
                                         @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";
           
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Title", DbType.String, Product.Title);
                db.AddInParameter(cmd, "@Description", DbType.String, Product.Description);
                db.AddInParameter(cmd, "@DealerId", DbType.String, Product.DealerId);
                db.AddInParameter(cmd, "@Image", DbType.String, Product.Image);
                db.AddInParameter(cmd, "@Price", DbType.Double, Product.Price);
                db.AddInParameter(cmd, "@QuantitySold", DbType.Int32, Product.QuantitySold);
                db.AddInParameter(cmd, "@AvgStars", DbType.Double, Product.AvgStars);
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, Product.Rowid);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, Product.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, Product.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, Product.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, Product.ChangedBy);
                // Obtener el valor de la primary key.
                Product.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return Product;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Product"></param>
        public void UpdateById(Product Product)
        {
            const string sqlStatement = @"UPDATE dbo.Product
                SET [Title]=@Title, 
                    [Description]=@Descritpion,
                    [DealerId]=@DealerId, 
                    [Image]=@Image,
                    [Price]=@Price,
                    [QuantitySold]=@QuantitySold,
                    [AvgStars]=@AvgStars,
                    [Rowid]=@Rowid,
                    [CreatedOn]=@CreatedOn,
                    [CreatedBy]=@CreatedBy, 
                    [ChangedOn]=@ChangedOn, 
                    [ChangedBy]=@ChangedBy 
                    WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Title", DbType.String, Product.Title);
                db.AddInParameter(cmd, "@Description", DbType.String, Product.Description);
                db.AddInParameter(cmd, "@DealerId", DbType.String, Product.DealerId);
                db.AddInParameter(cmd, "@Image", DbType.String, Product.Image);
                db.AddInParameter(cmd, "@Price", DbType.Double, Product.Price);
                db.AddInParameter(cmd, "@QuantitySold", DbType.Int32, Product.QuantitySold);
                db.AddInParameter(cmd, "@AvgStars", DbType.Double, Product.AvgStars);
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, Product.Rowid);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, Product.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, Product.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, Product.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, Product.ChangedBy);
                db.AddInParameter(cmd, "@Id", DbType.Int32, Product.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Product WHERE [Id]=@Id ";
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
        public Product SelectById(int id)
        {
            const string sqlStatement = @"SELECT [Id], [Title], [Description], [DealerId], [Image], [Price], [QuantitySold], [AvgStars], [Rowid],
                                         [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]
                                         FROM dbo.Product WHERE [Id]=@Id ";

            Product Product = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) Product = LoadProduct(dr);
                }
            }

            return Product;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Product> Select()
        {
            // WARNING! Performance
            const string sqlStatement = @"SELECT [Id], [Title], [Description], [DealerId], [Image], [Price], [QuantitySold], [AvgStars], [Rowid],
                                         [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]
                                         FROM dbo.Product ";

            var result = new List<Product>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var Product = LoadProduct(dr); // Mapper
                        result.Add(Product);
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
        private static Product LoadProduct(IDataReader dr)
        {
            var Product = new Product
            {
                Id = GetDataValue<int>(dr, "Id"),
                Title = GetDataValue<string>(dr, "Title"),
                Description = GetDataValue<string>(dr, "Description"),
                DealerId = GetDataValue<Int32>(dr, "DealerId"),
                Image = GetDataValue<string>(dr, "Image"),
                Price = GetDataValue<double>(dr, "Price"),
                QuantitySold = GetDataValue<Int32>(dr, "QuantitySold"),
                AvgStars = GetDataValue<double>(dr, "AvgStars"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return Product;
        }
    }
}
