using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendarCitasU2.Models.TableViewModels
{
    public class UserTableViewModel
    {
        // La funcionalidad de este ViewModel es el de mostrar solo algunos campos de mi tabla
        public int ID { get; set; }
        public string USERNAME { get; set; }
        public bool ISADMIN { get; set; }
        public bool ISACTIVE { get; set; }
    }
}