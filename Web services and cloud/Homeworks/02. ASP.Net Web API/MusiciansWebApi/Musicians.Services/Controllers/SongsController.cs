namespace Musicians.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using Musicians.Data;
    using Musicians.Models;
    using Musicians.Services.Models;

    public class SongsController : ApiController
    {
        private readonly IMusiciansData data;

        public SongsController() : this(new MusiciansData())
        {
        }

        public SongsController(IMusiciansData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var songs = this.data
            .Songs
                            .All()
                            .Select(SongModel.FromSong);

            return this.Ok(songs);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var song = this.data
            .Songs
                           .All()
                           .Where(s => s.Id == id)
                           .Select(SongModel.FromSong)
                           .FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest("Song does not exist - invalid id");
            }

            return this.Ok(song);
        }

        [HttpGet]
        public IHttpActionResult ByTitle(string id)
        {
            var song = this.data
            .Songs
                .All()
                .Where(s => s.Title == id)
                .Select(SongModel.FromSong)
                .FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest("Song does not exist - invalid title");
            }

            return this.Ok(song);
        }

        [HttpPost]
        public IHttpActionResult Create(SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newSong = new Song
            {
                Title = song.Title,
                Genre = song.Genre,
                Length = song.Length,
                Year = song.Year
            };

            this.data.Songs.Add(newSong);
            this.data.SaveChanges();

            song.Id = newSong.Id;
            return this.Ok(song);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingSong = this.data.Songs.All().FirstOrDefault(s => s.Id == id);
            if (existingSong == null)
            {
                return this.BadRequest("Such song does not exists!");
            }

            existingSong.Title = song.Title;

            if (song.Genre != null)
            {
                existingSong.Genre = song.Genre;
            }

            if (song.Length != null)
            {
                existingSong.Length = song.Length;
            }

            if (song.Year != null)
            {
                existingSong.Year = song.Year;
            }

            this.data.SaveChanges();

            song.Id = existingSong.Id;
            song.Genre = existingSong.Genre;
            song.Length = existingSong.Length;
            song.Title = existingSong.Title;

            var newSong = new
            {
                Id = existingSong.Id,
                Genre = existingSong.Genre,
                Length = existingSong.Length,
                Title = existingSong.Title
            };

            return this.Ok(newSong);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingSong = this.data.Songs.All().FirstOrDefault(s => s.Id == id);
            if (existingSong == null)
            {
                return this.BadRequest("Such song does not exists!");
            }

            this.data.Songs.Delete(existingSong);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddArtist(int id, int artistId)
        {
            var song = this.data.Songs.All().FirstOrDefault(s => s.Id == id);
            if (song == null)
            {
                return this.BadRequest("Such song does not exists - invalid id!");
            }

            var artist = this.data.Artists.All().FirstOrDefault(a => a.Id == artistId);
            if (artist == null)
            {
                return this.BadRequest("Such artist does not exists - invalid id!");
            }

            song.Artists.Add(artist);
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}