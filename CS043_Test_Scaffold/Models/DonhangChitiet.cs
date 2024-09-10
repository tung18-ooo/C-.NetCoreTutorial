using System;
using System.Collections.Generic;

namespace CS043_Test_Scaffold.Models;

public partial class DonhangChitiet
{
    public int DonhangChitietId { get; set; }

    public int? DonhangId { get; set; }

    public int? SanphamId { get; set; }

    public int? Soluong { get; set; }
}
