﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    interface ISoldier
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
