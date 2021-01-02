using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MOCAPP.Models
{
    public class MOC_Model
    {

        public class New_MOC_Model
        {

            public int MOC_ID { get; set; }
            public string MOC_Number { get; set; }

            [Required(ErrorMessage = "Field is required")]
            public string Description { get; set; }

            [Required(ErrorMessage = "Field is required")]
            public string Station { get; set; }
            [Required(ErrorMessage = "Field is required")]
            public string Type_of_Change { get; set; }
            [Required(ErrorMessage = "Field is required")]
            public string Department { get; set; }
            [Required(ErrorMessage = "Field is required")]
            public string Identified_Tagno { get; set; }
            [Required(ErrorMessage = "Field is required")]

            public string Circuit { get; set; }
            [Required(ErrorMessage = "Field is required")]
            public string Reasons_Change { get; set; }
            [Required(ErrorMessage = "Field is required")]
            public string Impact_Change { get; set; }
            [Required(ErrorMessage = "Field is required")]
            public string Change_Proposed { get; set; }
            [Required(ErrorMessage = "Field is required")]
            public string Hazards_Identified { get; set; }
            [Required(ErrorMessage = "Field is required")]
            public string Arrang_mitigation { get; set; }
            //[Required(ErrorMessage = "Field is required")]
            public string Revised_Drawings { get; set; }
            [Required(ErrorMessage = "Field is required")]
            public string Periodicity_date_from { get; set; }
        
            public string Periodicity_time_from { get; set; }
            [Required(ErrorMessage = "Field is required")]
            public string Periodicity_date_To { get; set; }
            //[Required(ErrorMessage = "Field is required")]
            public string Periodicity_time_To { get; set; }
            public string Status { get; set; }
            [Required(ErrorMessage = "Field is required")]
            public string Remark { get; set; }
            public DateTime Cretedate { get; set; }
            public string CreateBy { get; set; }
            public string fileData { get; set; }
            

        }
    }
}