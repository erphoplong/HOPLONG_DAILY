using ERP.Web.Models.BusinessModel;
using ERP.Web.Models.Database;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Controllers
{
    [AuthorizeBussiness]
    public class ImportFileController : Controller
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();
        int so_dong_thanh_cong, dong;

        // GET: ImportFile
        #region "Import Hàng Hóa"
        public ActionResult Import_Hanghoa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import_Hanghoa(HttpPostedFileBase file)
        {
            
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UploadedFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {

                                HH HH = new HH();
                                HH.MA_HANG = workSheet.Cells[rowIterator, 1].Value.ToString();
                                if (workSheet.Cells[rowIterator, 2].Value != null)
                                    HH.TEN_HANG = workSheet.Cells[rowIterator, 2].Value.ToString();
                                HH.MA_NHOM_HANG = workSheet.Cells[rowIterator, 3].Value.ToString();

                                if (workSheet.Cells[rowIterator, 5].Value != null)
                                    HH.DON_VI_TINH = workSheet.Cells[rowIterator, 5].Value.ToString();
                                if (workSheet.Cells[rowIterator, 6].Value != null)
                                    HH.XUAT_XU = workSheet.Cells[rowIterator, 6].Value.ToString();

                                if (workSheet.Cells[rowIterator, 8].Value != null)
                                    HH.HINH_ANH = workSheet.Cells[rowIterator, 8].Value.ToString();

                                if (workSheet.Cells[rowIterator, 10].Value != null)
                                    HH.GHI_CHU = workSheet.Cells[rowIterator, 10].Value.ToString();
                                if (workSheet.Cells[rowIterator, 11].Value != null)
                                    HH.TK_HACH_TOAN_KHO = workSheet.Cells[rowIterator, 11].Value.ToString();
                                if (workSheet.Cells[rowIterator, 12].Value != null)
                                    HH.TK_DOANH_THU = workSheet.Cells[rowIterator, 12].Value.ToString();
                                if (workSheet.Cells[rowIterator, 13].Value != null)
                                    HH.TK_CHI_PHI = workSheet.Cells[rowIterator, 13].Value.ToString();

                                db.HHs.Add(HH);

                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View();
        }

        #endregion

        #region "Update hàng hóa"
        public ActionResult Update_HangHoa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update_HangHoa(HttpPostedFileBase file)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UpFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                var mahang = workSheet.Cells[rowIterator, 1].Value.ToString();
                                var HH = db.HHs.Where(x => x.MA_HANG == mahang).FirstOrDefault();
                                

                                if (workSheet.Cells[rowIterator, 2].Value != null)
                                    HH.TEN_HANG = workSheet.Cells[rowIterator, 2].Value.ToString();
                                HH.MA_NHOM_HANG = workSheet.Cells[rowIterator, 3].Value.ToString();
                                if (workSheet.Cells[rowIterator, 5].Value != null)
                                    HH.DON_VI_TINH = workSheet.Cells[rowIterator, 5].Value.ToString();
                                if (workSheet.Cells[rowIterator, 6].Value != null)
                                    HH.XUAT_XU = workSheet.Cells[rowIterator, 6].Value.ToString();
                                if (workSheet.Cells[rowIterator, 8].Value != null)
                                    HH.HINH_ANH = workSheet.Cells[rowIterator, 8].Value.ToString();
                                if (workSheet.Cells[rowIterator, 10].Value != null)
                                    HH.GHI_CHU = workSheet.Cells[rowIterator, 10].Value.ToString();
                                if (workSheet.Cells[rowIterator, 11].Value != null)
                                    HH.TK_HACH_TOAN_KHO = workSheet.Cells[rowIterator, 11].Value.ToString();
                                if (workSheet.Cells[rowIterator, 12].Value != null)
                                    HH.TK_DOANH_THU = workSheet.Cells[rowIterator, 12].Value.ToString();
                                if (workSheet.Cells[rowIterator, 13].Value != null)
                                    HH.TK_CHI_PHI = workSheet.Cells[rowIterator, 13].Value.ToString();

                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View("Import_Hanghoa");
        }

        #endregion


        #region "Import kho"
        public ActionResult Import_Kho()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import_Kho(HttpPostedFileBase file)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UploadedFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                DM_KHO kho = new DM_KHO();
                                kho.MA_KHO = workSheet.Cells[rowIterator, 1].Value.ToString();
                                kho.TEN_KHO = workSheet.Cells[rowIterator, 2].Value.ToString();
                                kho.DIA_CHI_KHO = workSheet.Cells[rowIterator, 3].Value.ToString();
                                kho.MA_KHO_CHA = workSheet.Cells[rowIterator, 4].Value.ToString();
                                kho.TRUC_THUOC = workSheet.Cells[rowIterator, 5].Value.ToString();
                                kho.GHI_CHU = workSheet.Cells[rowIterator, 6].Value.ToString();

                                db.DM_KHO.Add(kho);

                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View("Import_Hanghoa");
        }

        #endregion



        #region "Import hàng tồn kho"
        public ActionResult Import_Hangtonkho()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import_Hangtonkho(HttpPostedFileBase file)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UploadedFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                HH_TON_KHO tonkho = new HH_TON_KHO();
                                tonkho.MA_HANG = workSheet.Cells[rowIterator, 1].Value.ToString();
                                tonkho.MA_KHO = workSheet.Cells[rowIterator, 2].Value.ToString();
                                tonkho.SL_TON = Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value.ToString());

                                db.HH_TON_KHO.Add(tonkho);

                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View("Import_Hanghoa");
        }

        #endregion

        #region "Update hàng tồn kho"
        public ActionResult Update_Hangtonkho()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update_Hangtonkho(HttpPostedFileBase file)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UpFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                var mahang = workSheet.Cells[rowIterator, 1].Value.ToString();
                                var makho = workSheet.Cells[rowIterator, 2].Value.ToString();
                                var tonkho = db.HH_TON_KHO.Where(x => x.MA_HANG == mahang && x.MA_KHO == makho).FirstOrDefault();
                                tonkho.SL_TON = Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value.ToString());
                                //db.HH_TON_KHO.Add(tonkho);

                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View("Import_Hanghoa");
        }

        #endregion


        #region "Import hãng"
        public ActionResult Import_Hangsp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import_Hangsp(HttpPostedFileBase file)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UploadedFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                HH_NHOM_VTHH hangsp = new HH_NHOM_VTHH();
                                hangsp.MA_NHOM_HANG_CHI_TIET = workSheet.Cells[rowIterator, 1].Value.ToString();
                                hangsp.CHUNG_LOAI_HANG = workSheet.Cells[rowIterator, 2].Value.ToString();
                                hangsp.MA_NHOM_HANG_CHA = workSheet.Cells[rowIterator, 3].Value.ToString();
                                hangsp.GHI_CHU = workSheet.Cells[rowIterator, 4].Value.ToString();

                                db.HH_NHOM_VTHH.Add(hangsp);

                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View("Import_Hanghoa");
        }

        #endregion


        #region "Import Tồn kho hãng"
        public ActionResult Import_TonKhoHang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import_TonKhoHang(HttpPostedFileBase file)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UploadedFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                HH_TONKHO_HANG HH = new HH_TONKHO_HANG();
                                HH.MA_HANG = workSheet.Cells[rowIterator, 1].Value.ToString();
                                HH.MA_NHOM_HANG = workSheet.Cells[rowIterator, 2].Value.ToString();
                                HH.SL_TON = Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value.ToString());

                                db.HH_TONKHO_HANG.Add(HH);

                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View("Import_Hanghoa");
        }

        #endregion



        #region "Update tồn kho hãng"
        public ActionResult Update_Tonkhohang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update_Tonkhohang(HttpPostedFileBase file)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UpFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                var mahang = workSheet.Cells[rowIterator, 1].Value.ToString();
                                var manhomhang = workSheet.Cells[rowIterator, 2].Value.ToString();
                                var tonkho = db.HH_TONKHO_HANG.Where(x => x.MA_HANG == mahang && x.MA_NHOM_HANG == manhomhang).FirstOrDefault();
                                tonkho.SL_TON = Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value.ToString());
                                //db.HH_TON_KHO.Add(tonkho);



                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator - 1;
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View("Import_Hanghoa");
        }

        #endregion

    }
}