using System;
using System.Collections.Generic;

namespace MusicServiceDomain.Model;

public partial class SongsAlbum : Entity
{
    public int SongId { get; set; }

    public int AlbumId { get; set; }

    public virtual Album Album { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
