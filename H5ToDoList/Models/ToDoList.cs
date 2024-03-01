using System;
using System.Collections.Generic;

namespace H5ToDoList.Models;

public partial class ToDoList
{
    public int Id { get; set; }

    public string User { get; set; } = null!;

    public string Item { get; set; } = null!;
}
