using MusicServiceDomain.Model;
using System.ComponentModel.DataAnnotations;

namespace MusicServiceInfrastructure.ViewModel
{
    public class SongsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Назва")]
        public string Title { get; set; }

        [Display(Name = "Виконавці")]
        public List<string> ArtistNames { get; set; }

        [Display(Name = "Жанри")]
        public List<string> GenreNames { get; set; }

        [Display(Name = "Текст")]
        public string LyricsText { get; set; }

        [Display(Name = "Альбом")]
        public string AlbumName { get; set; }

        [Display(Name = "Тривалість")]
        public int Duration { get; set; }
    }

}