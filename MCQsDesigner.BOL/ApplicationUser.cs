﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.BOL
{
    public class ApplicationUser :IdentityUser
    {
        public virtual StudentProfile StudentProfile{ get; set; }
    }
}
