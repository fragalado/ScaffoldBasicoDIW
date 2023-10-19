using System;
using System.Collections.Generic;

namespace ScaffoldingDIW.Models;

public partial class Prueba
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellidos { get; set; }

    public bool? EsProgramador { get; set; }
}
