using Core.Helper;
using OfficeOpenXml;
using System;
using System.Data.SqlClient;


//namespace Repositories.Service
//{
//    public class ProcessService : IProcessService
//    {
//        private AppSettings _appSettings=new AppSettings();
//        public BaseResponse UploadFile(dynamic File)
//        {
//            var response = new BaseResponse();
           
//            try
//            {
//                var excel = new ExcelPackage(File);
//                var dt = excel.ToDataTable();
//                using (SqlConnection con = new SqlConnection(_appSettings.ConnectionString))
//                {
//                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
//                    {

                       
                       
//                        con.Open();
//                        sqlBulkCopy.BulkCopyTimeout = 3600;
//                        //sqlBulkCopy.WriteToServer(dt);
//                        con.Close();


//                    }
//                }
//                return response;
//            }
//            catch (Exception ex)
//            {

//                return response;
//            }

//        }
//    }
//}
