using Currency.Api.Models;
using Currency.Api.Parameter;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Currency.Api.Repository
{
    public class CardRepository
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private readonly string _connectString =
        @"Server=.;Database=Currency;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;";

        /// <summary>
        /// 查詢卡片列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CardViewModel> GetList()
        {
            var sql = "SELECT * FROM Card";

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Query<CardViewModel>(sql);
                return result;
            }
        }

        /// <summary>
        /// 查詢卡片
        /// </summary>
        /// <returns></returns>
        public CardViewModel Get(int id)
        {
            var sql =
            @"
                SELECT * 
                FROM Card 
                Where Id = @id
            ";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.QueryFirstOrDefault<CardViewModel>(sql, parameters);
                return result;
            }
        }

        /// <summary>
        /// 新增卡片
        /// </summary>
        /// <param name="parameter">參數</param>
        /// <returns></returns>
        public int Create(CardParameter parameter)
        {
            var sql =
            @"
                INSERT INTO Card 
                (
                   [Name]
                  ,[Description]
                  ,[Attack]
                  ,[Health]
                  ,[Cost]
                ) 
                VALUES 
                (
                     @Name
                    ,@Description
                    ,@Attack
                    ,@Health
                    ,@Cost
                );
            
                SELECT @@IDENTITY;
            ";

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.QueryFirstOrDefault<int>(sql, parameter);
                return result;
            }
        }

        /// <summary>
        /// 修改卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <param name="parameter">參數</param>
        /// <returns></returns>
        public bool Update(int id, CardParameter parameter)
        {
            var sql =
            @"
                UPDATE Card
                SET 
                     [Name] = @Name
                    ,[Description] = @Description
                    ,[Attack] = @Attack
                    ,[Health] = @Health
                    ,[Cost] = @Cost
                WHERE 
                    Id = @id
            ";

            var parameters = new DynamicParameters(parameter);
            parameters.Add("Id", id, System.Data.DbType.Int32);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Execute(sql, parameters);
                return result > 0;
            }
        }

        /// <summary>
        /// 刪除卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <returns></returns>
        public void Delete(int id)
        {
            var sql =
            @"
                DELETE FROM Card
                WHERE Id = @Id
            ";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Execute(sql, parameters);
            }
        }
    }

}
