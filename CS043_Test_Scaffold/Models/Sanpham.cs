﻿using System;
using System.Collections.Generic;

namespace CS043_Test_Scaffold.Models;

public partial class Sanpham
{
    public int SanphamId { get; set; }

    public string? TenSanpham { get; set; }

    public int? CungcapId { get; set; }

    public int? DanhmucId { get; set; }

    public string? Donvi { get; set; }

    public decimal? Gia { get; set; }
}
