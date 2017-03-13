using ERP.Web.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.Web.Api.Kho
{
    public class Api_TonKhoDaiLyController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();
        [Route("api/Api_TonKhoDaiLy/{mahang}/{macongty}")]
        public List<HH_TON_KHO> Gettonkho(string mahang, string macongty)
        {
            var congty = db.CCTC_CONG_TY.Where(x => x.MA_CONG_TY == macongty).FirstOrDefault();
            string tructhuoc = congty.CONG_TY_ME;


            List<HH_TON_KHO> listtonkho = new List<HH_TON_KHO>();
            var dskho = db.DM_KHO.Where(x => (x.TRUC_THUOC == tructhuoc || x.TRUC_THUOC == "HOPLONG")).ToList();
            foreach (var item in dskho)
            {
               
                var vData = db.HH_TON_KHO.Where(x => x.MA_HANG == mahang && x.MA_KHO == item.MA_KHO);
                if (vData.Count() > 0)
                {
                    var data = vData.FirstOrDefault();
                    HH_TON_KHO tonkho = new HH_TON_KHO();
                    tonkho.MA_HANG = data.MA_HANG;
                    tonkho.MA_KHO = data.MA_KHO;
                    tonkho.SL_TON = data.SL_TON;
                    listtonkho.Add(tonkho);
                    
                }
                

            }

            var tonhang = db.HH_TONKHO_HANG.Where(x => x.MA_HANG == mahang);
            if (tonhang.Count() > 0)
            {
                var data1 = tonhang.FirstOrDefault();
                HH_TON_KHO tonkhohang = new HH_TON_KHO();
                tonkhohang.MA_HANG = data1.MA_HANG;
                tonkhohang.MA_KHO = "TỒN TẠI HÃNG";
                tonkhohang.SL_TON = data1.SL_TON;
                listtonkho.Add(tonkhohang);
            }

            var result = listtonkho.ToList().Select(x => new HH_TON_KHO()
            {
                MA_HANG = x.MA_HANG,
                MA_KHO = x.MA_KHO,
                SL_TON = x.SL_TON
            }).ToList();
            return result;
        }

    }
}
