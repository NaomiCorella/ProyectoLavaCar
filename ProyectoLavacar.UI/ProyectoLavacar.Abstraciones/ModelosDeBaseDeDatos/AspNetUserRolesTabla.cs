using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    [Table("AspNetUserRoles")]
    public class AspNetUserRolesTabla
    {


        public string UserId { get; set; }


        public string RoleId { get; set; }
    }
}
