using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSupportSystem.Enums
{
    public enum Statu
    {
        [Display(Name = "Gönderildi")]
        Gönderildi = 0,

        [Display(Name = "İşleme Alındı")]
        İşlemeAlındı = 1,

        [Display(Name = "Çözüldü")]
        Çözüldü = 2
    }
}
