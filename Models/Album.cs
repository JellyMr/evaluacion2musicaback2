using System;
using System.Collections.Generic;

namespace EvaluacionMusicaAPI.Models;

public partial class Album
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Artista { get; set; }

    public decimal? Precio { get; set; }

    public string? Img { get; set; }
}
