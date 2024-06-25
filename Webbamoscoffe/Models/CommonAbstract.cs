using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webbamoscoffe.Models
{
    public abstract class CommonAbstract
    {
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}