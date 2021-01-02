using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOCAPP.Controllers
{
    public class MOCController : Controller
    {
        // GET: MOC

        MOCAPP.MOC_COMMON.Common objcom = new MOC_COMMON.Common();
        public ActionResult NewMOC()
        {
            return View();
        }

        public ActionResult MOCRecordView()
        {
          
            return View();
        }

        public ActionResult MOCRecordEdit()
        {

            return View();
        }
        public ActionResult MyMOC()
        {

            List<MOCAPP.Models.MOC_Model.New_MOC_Model> Moc_RecorList = objcom.Get_MocRecord();
            if (Moc_RecorList.Count > 0)
            {
                TempData["MOCLIST"] = Moc_RecorList;
            }
            else
            {
                TempData["MOCLIST"] = null;
            }
            return View();
        }

        public ActionResult MOCContact()
        {
            return View();
        }

        public ActionResult MOCRecordViewFor(string MOC_Number)
        {

            List<MOCAPP.Models.MOC_Model.New_MOC_Model> Moc_RecorList = objcom.Get_MocRecordView(MOC_Number);

            TempData["ViewMoc"] = Moc_RecorList;

           return RedirectToAction("MOCRecordView", "MOC");


        }
        public ActionResult MOCRecordEditFor(string MOC_Number)
        {

            List<MOCAPP.Models.MOC_Model.New_MOC_Model> Moc_RecorList = objcom.Get_MocRecordEdit(MOC_Number);

            TempData["EditMoc"] = Moc_RecorList;

            return RedirectToAction("MOCRecordEdit", "MOC");


        }


        public ActionResult MOCRecord()
        {

            List< MOCAPP.Models.MOC_Model.New_MOC_Model> Moc_RecorList = objcom.Get_MocRecord();
            if (Moc_RecorList.Count > 0)
            {
                TempData["MOCLIST"] = Moc_RecorList;
            }
            else
            {
                TempData["MOCLIST"] = null;
            }
            return View();
        }


        [HttpPost]
        public ActionResult MOCRecord(MOCAPP.Models.MOC_Model.New_MOC_Model obj)
        {

            List<MOCAPP.Models.MOC_Model.New_MOC_Model> Moc_RecorList = objcom.Get_MocRecordfilter(obj);
            if (Moc_RecorList.Count > 0)
            {
                TempData["MOCLIST"] = Moc_RecorList;
            }
            else
            {
                TempData["MOCLIST"] = null;
            }
            return View();
        }








        //[HttpPost]
        //public JsonResult New_MOC_POST(List<MOCAPP.Models.MOC_Model.New_MOC_Model> ListNew_Moc)

        //{

        //    //HttpPostedFileBase file = Session["UploadDoc"] as HttpPostedFileBase;

        //    int resultInvSave = -1;
        //    resultInvSave = objcom.SAVE_NEWMOC(ListNew_Moc);



        //    return Json(resultInvSave);

        //}


        //[HttpGet]
        //public JsonResult GetEditDataMoc(string MOC_Number)

        //{

        //    //HttpPostedFileBase file = Session["UploadDoc"] as HttpPostedFileBase;
        //    List<MOCAPP.Models.MOC_Model.New_MOC_Model> Moc_RecorList = objcom.Get_MocRecordEdit(MOC_Number);
        //    //int resultInvSave = -1;
        //    //resultInvSave = objcom.SAVE_NEWMOC(ListNew_Moc);

        //    return Json(Moc_RecorList, JsonRequestBehavior.AllowGet);



        //}






        [HttpPost]
        public ActionResult MOCRecordEdit(MOCAPP.Models.MOC_Model.New_MOC_Model model)
        {


           
            int resultInvSave = -1;
            resultInvSave = objcom.UpdateMoc(model);


            if (resultInvSave == 1)
            {

                List<MOCAPP.Models.MOC_Model.New_MOC_Model> Moc_RecorList = objcom.Get_MocRecordEdit(model.MOC_Number);
                TempData["EditMoc"] = Moc_RecorList;

                TempData["Updatesucee"] = "Update Save SuccesFully..";
                return RedirectToAction("MOCRecordEdit", "MOC");
            }
            if (resultInvSave != 1)
            {
                List<MOCAPP.Models.MOC_Model.New_MOC_Model> Moc_RecorList = objcom.Get_MocRecordEdit(model.MOC_Number);
                TempData["EditMoc"] = Moc_RecorList;
                TempData["UpdateErr"] = "Update Not , Please Try Again";
                return RedirectToAction("MOCRecordEdit", "MOC");
            }




            return View();

        }


        [HttpPost]
        public ActionResult NewMOC(MOCAPP.Models.MOC_Model.New_MOC_Model  ListNew_Moc)

        {
            if (ModelState.IsValid)
            {
               
                string fileName = string.Empty;
                var pic = System.Web.HttpContext.Current.Request.Files["ImageData"];
                if (pic.ContentLength != 0)
                {
                    HttpPostedFileBase filebase = new HttpPostedFileWrapper(pic);
                    string dirUrl = "IMAGES";
                    //var fileName = Path.GetFileName(filebase.FileName);
                     fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(pic.FileName);

                    string dirPath = Server.MapPath(dirUrl);
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    string fileUrl = dirUrl + "/" + fileName;


                    var supportedTypes = new[] { "jpeg", "jpg", "png", "pdf" };


                    var fileExt = System.IO.Path.GetExtension(pic.FileName).Substring(1);


                    if (!supportedTypes.Contains(fileExt))
                    {
                        TempData["ImageErr"] = "File Extension Is InValid - Only Upload JPEG/JPG/PDF/PNG , Please Add Result Again";
                        return RedirectToAction("NewMOC", "MOC");
                    }

                    filebase.SaveAs(Server.MapPath(fileUrl));
                }

                int resultInvSave = -1;
                resultInvSave = objcom.SAVE_NEWMOC(ListNew_Moc, fileName);

                if (resultInvSave == 1)
                {
                    TempData["SaveSuccees"] = "Data Save SuccesFully..";
                    return RedirectToAction("NewMOC", "MOC");
                }
                if (resultInvSave != 1)
                {
                    TempData["SaveErr"] = "Data not Save , Please Try Again";
                    return RedirectToAction("NewMOC", "MOC");
                }



                return RedirectToAction("NewMOC", "MOC");
            }
            return View();

        }



    }
}