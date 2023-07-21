
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Enums;

public static class EnumResponses
{

    [Display(Name = "Data not found.")]
    public const int NotFound = 100;
      
    [Display(Name = "Error happened.")]
    public const int Error = 101;
                
    [Display(Name = "This data can't delete.")]
    public const int NotDelete = 107;
                          
    [Display(Name = "Done.")]
    public const int Success = 200;

}
