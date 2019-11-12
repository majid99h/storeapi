
using Core.Domain;
using Core.Extension;
using Core.Helper;
using Core.Repositories;
using OfficeOpenXml;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Core.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreDBContext context)
           : base(context)
        {
        }
        public BaseResponse UploadFile(dynamic File, string connStr)
        {
            var response = new BaseResponse();
            try
            {

                var excel = new ExcelPackage(File);
                var dt = excel.ToDataTable();
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        con.Open();
                        sqlBulkCopy.BulkCopyTimeout = 3600;
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
                return response;
            }
            catch (Exception ex)
            {

                return response;
            }

        }
        public BaseResponse GetCategory()
        {
            var response = new BaseResponse();
            try
            {
                response.data = this._dbContext.Category.Select(e => new Category { CategoryName = e.CategoryName }).ToList();
                response.status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.message = ex.ToString();
                response.status = false;
                return response;
            }
        }
        public StoreDBContext _dbContext
        {
            get { return Context as StoreDBContext; }
        }
    }
}
