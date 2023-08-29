
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Enums;

public enum EnumResponseResultCodes : int
{
    [Display(Name = "Data not found.")]
    NotFound = 100,

    [Display(Name = "Done.")]
    Done = 101,

    [Display(Name = "Data is repeated.")]
    RepeatedData = 102,

    [Display(Name = "This data can't delete.")]
    NotDelete = 107,

    [Display(Name = "Done.")]
    Success = 200,

    [Display(Name = "Error happened.")]
    Error = 400,  
}
