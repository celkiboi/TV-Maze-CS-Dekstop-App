﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVLibrary.Database;

public interface IDatabase
{
    Task<string> FetchDataAsync(string url);
}
