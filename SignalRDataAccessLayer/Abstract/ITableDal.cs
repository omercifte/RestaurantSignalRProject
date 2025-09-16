﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SignalRDataAccessLayer.Abstract
{
    public interface ITableDal:IGenericDal<Table>
    {
        int TableCount();
    }
}
