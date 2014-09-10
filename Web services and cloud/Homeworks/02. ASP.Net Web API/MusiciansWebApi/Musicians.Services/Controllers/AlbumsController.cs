namespace Musicians.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using Musicians.Data;
    using Musicians.Models;
    using Musicians.Services.Models;
    
    public class AlbumsController : ApiController
    {
        private readonly IMusiciansData data;

        public AlbumsController() : this(new MusiciansData())
        {
        }

        public AlbumsController(IMusiciansData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult AllWithSongs()
        {
            var albums = this.data
                .Albums
                .All()
                .Select(AlbumModel.FromAlbumWithSongs);

            return this.Ok(albums);
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var albums = this.data
                .Albums
                .All()
                .Select(AlbumModel.FromAlbum);

            return this.Ok(albums);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var album = this.data
            .Albums
                .All()
                .Where(s => s.Id == id)
                .Select(AlbumModel.FromAlbum)
                .FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest("Album does not exist - invalid id");
            }

            return this.Ok(album);
        }

        [HttpGet]
        public IHttpActionResult ByTitle(string id)
        {
            var album = this.data
            .Albums
                            .All()
                            .Where(s => s.Title == id)
                            .Select(AlbumModel.FromAlbum)
                            .FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest("Album does not exist - invalid title");
            }

            return this.Ok(album);
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newAlbum = new Album
            {
                Title = album.Title,
                NumberOfSongs = album.NumberOfSongs,
                Year = album.Year,
            };

            this.data.Albums.Add(newAlbum);
            this.data.SaveChanges();

            album.Id = newAlbum.Id;
            return this.Ok(album);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingAlbum = this.data.Albums.All().FirstOrDefault(a => a.Id == id);
            if (existingAlbum == null)
            {
                return this.BadRequest("Such song does not exists!");
            }

            existingAlbum.Title = album.Title;
            existingAlbum.Year = album.Year;

            if (album.NumberOfSongs != null)
            {
                existingAlbum.NumberOfSongs = album.NumberOfSongs;
            }
                      
            this.data.SaveChanges();

            album.Id = id;
            album.NumberOfSongs = existingAlbum.NumberOfSongs;

            var newAlbum = new
            {
                Id = album.Id,
                Title = album.Title,
                NumberOfSongs = album.NumberOfSongs,
                Year = album.Year
            };

            return this.Ok(newAlbum);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingAlbum = this.data.Albums.All().FirstOrDefault(a => a.Id == id);
            if (existingAlbum == null)
            {
                return this.BadRequest("Such album does not exists!");
            }

            this.data.Albums.Delete(existingAlbum);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddSong(int id, int songId)
        {
            var album = this.data.Albums.All().FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return this.BadRequest("Such album does not exists - invalid id!");
            }

            var song = this.data.Songs.All().FirstOrDefault(s => s.Id == songId);
            if (song == null)
            {
                return this.BadRequest("Such song does not exists - invalid id!");
            }

            album.Songs.Add(song);
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}