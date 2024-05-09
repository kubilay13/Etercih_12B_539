using System;
using System.Collections.Generic;

namespace Etercih_12B_539.Models;

public partial class Etercih
{
    public int EtercihId { get; set; }

    public int? KullaniciId { get; set; }

    public int? SecenekId { get; set; }

    public DateTime? Zaman { get; set; }

    public string? Aciklama { get; set; }
}
