using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicServiceDomain.Model;

public partial class Album : Entity
{
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Назва")]
    public string Title { get; set; } = null!;

    [Display(Name = "Рік випуску")]
    [Range(1900, 2024, ErrorMessage = "Рік випуску може бути від 1900 до цього року")]
    public int? ReleaseYear { get; set; }

    public virtual ICollection<SongsAlbum> SongsAlbums { get; set; } = new List<SongsAlbum>();
}
