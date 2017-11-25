﻿using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ASF.Entities;

namespace ASF.Data
{
    public class DealerDAC : DataAccessComponent
    {
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dealer"></param>
        /// <returns></returns>
        public Dealer Create ( Dealer Dealer )
        {
            const string sqlStatement = "INSERT INTO dbo.Dealer ([FirstName], [LastName], [CategoryId], [CountryId], [Description], [TotalProducts], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@FirstName, @LastName, @CategoryId, @CountryId, @Descritpion, @TotalProducts, @Rowid, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase( ConnectionName );
            using (var cmd = db.GetSqlStringCommand( sqlStatement ))
            {
                db.AddInParameter( cmd, "@FirstName", DbType.String, Dealer.FirstName );
                db.AddInParameter( cmd, "@LastName", DbType.String, Dealer.LastName );
                db.AddInParameter( cmd, "@CategoryId", DbType.Int32, Dealer.CategoryId );
                db.AddInParameter( cmd, "@CountryId", DbType.Int32, Dealer.CountryId );
                db.AddInParameter( cmd, "@Descritpion", DbType.String, Dealer.Description );
                db.AddInParameter( cmd, "@TotalProducts", DbType.Int32, Dealer.TotalProducts );
                db.AddInParameter( cmd, "@Rowid", DbType.Guid, Dealer.Rowid );
                db.AddInParameter( cmd, "@CreatedOn", DbType.DateTime2, Dealer.CreatedOn );
                db.AddInParameter( cmd, "@CreatedBy", DbType.Int32, Dealer.CreatedBy );
                db.AddInParameter( cmd, "@ChangedOn", DbType.DateTime2, Dealer.ChangedOn );
                db.AddInParameter( cmd, "@ChangedBy", DbType.Int32, Dealer.ChangedBy );
                // Obtener el valor de la primary key.
                Dealer.Id = Convert.ToInt32( db.ExecuteScalar( cmd ) );
            }

            return Dealer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dealer"></param>
        public void UpdateById ( Dealer Dealer )
        {
            const string sqlStatement = "UPDATE [dbo].[Dealer] " +
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

            var db = DatabaseFactory.CreateDatabase( ConnectionName );
            using (var cmd = db.GetSqlStringCommand( sqlStatement ))
            {
                db.AddInParameter( cmd, "@FirstName", DbType.String, Dealer.FirstName );
                db.AddInParameter( cmd, "@LastName", DbType.String, Dealer.LastName );
                db.AddInParameter( cmd, "@CategoryId", DbType.Int32, Dealer.CategoryId );
                db.AddInParameter( cmd, "@CountryId", DbType.Int32, Dealer.CountryId );
                db.AddInParameter( cmd, "@Description", DbType.String, Dealer.Description );
                db.AddInParameter( cmd, "@TotalProducts", DbType.Int32, Dealer.TotalProducts );
                db.AddInParameter( cmd, "@Rowid", DbType.Guid, Dealer.Rowid );
                db.AddInParameter( cmd, "@CreatedOn", DbType.DateTime2, Dealer.CreatedOn );
                db.AddInParameter( cmd, "@CreatedBy", DbType.Int32, Dealer.CreatedBy );
                db.AddInParameter( cmd, "@ChangedOn", DbType.DateTime2, Dealer.ChangedOn );
                db.AddInParameter( cmd, "@ChangedBy", DbType.Int32, Dealer.ChangedBy );
                db.AddInParameter( cmd, "@Id", DbType.Int32, Dealer.Id );

                db.ExecuteNonQuery( cmd );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById ( int id )
        {
            const string sqlStatement = "DELETE dbo.Dealer WHERE [Id]=@Id ";
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
        public Dealer SelectById ( int id )
        {
            const string sqlStatement = @" SELECT [Id], [FirstName], [LastName], [CategoryId], [CountryId], [Description], [TotalProducts], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]
                FROM dbo.Dealer WHERE [Id]=@Id ";

            Dealer Dealer = null;
            var db = DatabaseFactory.CreateDatabase( ConnectionName );
            using (var cmd = db.GetSqlStringCommand( sqlStatement ))
            {
                db.AddInParameter( cmd, "@Id", DbType.Int32, id );
                using (var dr = db.ExecuteReader( cmd ))
                {
                    if (dr.Read()) Dealer = LoadDealer( dr );
                }
            }

            return Dealer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<DealerDTO> Select ()
        {
            // WARNING! Performance
            const string sqlStatement = @"SELECT [De].[Id], [De].[FirstName], [De].[LastName], [De].[CategoryId], [Ca].[Name] AS CategoryName, [De].[CountryId], [Co].[Name] AS CountryName, [De].[Description], 
                                        [De].[TotalProducts], [De].[Rowid], [De].[CreatedOn], [De].[CreatedBy], [De].[ChangedOn], [De].[ChangedBy] 
                                        FROM[dbo].[Dealer] AS De INNER JOIN[dbo].[Country] AS Co 
                                        ON De.CountryId = Co.Id INNER JOIN[dbo].[Category] AS Ca 
                                        ON De.CategoryId = Ca.Id 
                                        order by [De].[Id] asc ";
            //const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [CategoryId], [CountryId], [Description], [TotalProducts], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], " +
            //    "[ChangedBy] FROM dbo.Dealer ";

            var result = new List<DealerDTO>();
            var db = DatabaseFactory.CreateDatabase( ConnectionName );
            using (var cmd = db.GetSqlStringCommand( sqlStatement ))
            {
                using (var dr = db.ExecuteReader( cmd ))
                {
                    while (dr.Read())
                    {
                        var Dealer = LoadDealerDTO( dr ); // Mapper
                        result.Add( Dealer );
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
        private static DealerDTO LoadDealerDTO ( IDataReader dr )
        {
            var Dealer = new DealerDTO
            {
                Id = GetDataValue<int>( dr, "Id" ),
                FirstName = GetDataValue<string>( dr, "FirstName" ),
                LastName = GetDataValue<string>( dr, "LastName" ),
                CategoryId = GetDataValue<int>( dr, "CategoryId" ),
                CategoryName = GetDataValue<string>(dr, "CategoryName" ),
                CountryId = GetDataValue<int>( dr, "CountryId" ),
                CountryName = GetDataValue<string>(dr, "CountryName" ),
                Description = GetDataValue<string>( dr, "Description" ),
                TotalProducts = GetDataValue<int>( dr, "TotalProducts" ),
                Rowid = GetDataValue<Guid>( dr, "Rowid" ),
                CreatedOn = GetDataValue<DateTime>( dr, "CreatedOn" ),
                CreatedBy = GetDataValue<int>( dr, "CreatedBy" ),
                ChangedOn = GetDataValue<DateTime>( dr, "ChangedOn" ),
                ChangedBy = GetDataValue<int>( dr, "ChangedBy" )
            };
            return Dealer;
        }


        /// <summary>
        /// Crea una nueva Categoría desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Categoria.</returns>		
        private static Dealer LoadDealer ( IDataReader dr )
        {
            var Dealer = new Dealer
            {
                Id = GetDataValue<int>( dr, "Id" ),
                FirstName = GetDataValue<string>( dr, "FirstName" ),
                LastName = GetDataValue<string>( dr, "LastName" ),
                CategoryId = GetDataValue<int>( dr, "CategoryId" ),
                //CategoryName = GetDataValue<string>( dr, "Name" ),
                CountryId = GetDataValue<int>( dr, "CountryId" ),
                //CountryName = GetDataValue<string>( dr, "Name" ),
                Description = GetDataValue<string>( dr, "Description" ),
                TotalProducts = GetDataValue<int>( dr, "TotalProducts" ),
                Rowid = GetDataValue<Guid>( dr, "Rowid" ),
                CreatedOn = GetDataValue<DateTime>( dr, "CreatedOn" ),
                CreatedBy = GetDataValue<int>( dr, "CreatedBy" ),
                ChangedOn = GetDataValue<DateTime>( dr, "ChangedOn" ),
                ChangedBy = GetDataValue<int>( dr, "ChangedBy" )
            };
            return Dealer;
        }
    }
}
