﻿using System;
using System.Collections.Generic;

namespace CS043_Test_Scaffold.Models;

public partial class Donhang
{
    public int DonhangId { get; set; }

    public int? KhachhangId { get; set; }

    public int? NhanvienId { get; set; }

    public DateOnly? Ngaydathang { get; set; }

    public int? ShipperId { get; set; }
}
