﻿using System;
using System.Collections.Generic;

namespace H5ToDoList.Models;

public partial class Cpr
{
    public int Id { get; set; }

    public string User { get; set; } = null!;

    public string Cpr1 { get; set; } = null!;
}
