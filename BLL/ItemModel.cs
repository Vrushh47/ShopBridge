using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;
namespace BLL
{
   public class ItemModel
    {
       public ItemModel()
        {
            DeleteYN = false;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float? Price { get; set; }
        public byte[] Photo { get; set; }
        public bool? DeleteYN { get; set; }
       // [Required(ErrorMessage = "Please select file.")]
       // [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        public HttpPostedFileBase File { get; set; }

    }
}
