using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ERP.Web.Models.Database;

namespace ERP.Web.Api.Kho
{
    public class Api_HangHoaDaiLyController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/Api_HangHoaDaiLy
        public List<HH> GetHH()
        {
            var vData = db.HHs;
            var result = vData.ToList().Select(x => new HH()
            {
                MA_HANG = x.MA_HANG,
                TEN_HANG = x.TEN_HANG,
                MA_NHOM_HANG = x.MA_NHOM_HANG,
                DON_VI_TINH = x.DON_VI_TINH,
                KHOI_LUONG = x.KHOI_LUONG,
                XUAT_XU = x.XUAT_XU,
                BAO_HANH = x.BAO_HANH,
                THONG_SO_KY_THUAT = x.THONG_SO_KY_THUAT,
                QUY_CACH_DONG_GOI = x.QUY_CACH_DONG_GOI,
                HINH_ANH = x.HINH_ANH,
                GHI_CHU = x.GHI_CHU,
                TK_HACH_TOAN_KHO = x.TK_HACH_TOAN_KHO,
                TK_DOANH_THU = x.TK_DOANH_THU,
                TK_CHI_PHI = x.TK_CHI_PHI
            }).ToList();
            return result;
        }


        // GET: api/Api_HangHoaDaiLy/5
        [ResponseType(typeof(HH))]
        public IHttpActionResult GetHH(string id)
        {
            HH HH = db.HHs.Find(id);
            if (HH == null)
            {
                return NotFound();
            }

            return Ok(HH);
        }

        // PUT: api/Api_HangHoaDaiLy/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHH(string id, HH HH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != HH.MA_HANG)
            {
                return BadRequest();
            }

            db.Entry(HH).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HHExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Api_HangHoaDaiLy
        [ResponseType(typeof(HH))]
        public IHttpActionResult PostHH(HH HH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HHs.Add(HH);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HHExists(HH.MA_HANG))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = HH.MA_HANG }, HH);
        }

        // DELETE: api/Api_HangHoaDaiLy/5
        [ResponseType(typeof(HH))]
        public IHttpActionResult DeleteHH(string id)
        {
            HH HH = db.HHs.Find(id);
            if (HH == null)
            {
                return NotFound();
            }

            db.HHs.Remove(HH);
            db.SaveChanges();

            return Ok(HH);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HHExists(string id)
        {
            return db.HHs.Count(e => e.MA_HANG == id) > 0;
        }
    }
}