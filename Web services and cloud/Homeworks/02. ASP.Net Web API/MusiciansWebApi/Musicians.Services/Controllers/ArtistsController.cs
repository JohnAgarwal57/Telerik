namespace Musicians.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using Musicians.Data;
    using Musicians.Models;
    using Musicians.Services.Models;

    public class ArtistsController : ApiController
    {
        private readonly IMusiciansData data;

        public ArtistsController() : this(new MusiciansData())
        {
        }

        public ArtistsController(IMusiciansData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult AllWithSongs()
        {
            var artists = this.data
                .Artists
                .All()
                .Select(ArtistModels.FromArtistWithSongs);

            return this.Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var artists = this.data
                .Artists
                .All()
                .Select(ArtistModels.FromArtist);

            return this.Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var artist = this.data
            .Artists
                .All()
                .Where(a => a.Id == id)
                .Select(ArtistModels.FromArtist)
                .FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest("Artist does not exist - invalid id");
            }

            return this.Ok(artist);
        }

        [HttpGet]
        public IHttpActionResult ByName(string id)
        {
            var artist = this.data
            .Artists
                .All()
                .Where(a => a.Name == id)
                .Select(ArtistModels.FromArtist)
                .FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest("Artist does not exist - invalid name");
            }

            return this.Ok(artist);
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistModels artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newArtist = new Artist
            {
                Name = artist.Name,
                Country = artist.Country,
                BirthDate = artist.BirthDate,
                WebSite = artist.WebSite
            };

            this.data.Artists.Add(newArtist);
            this.data.SaveChanges();

            artist.Id = newArtist.Id;
            return this.Ok(artist);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ArtistModels artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingArtist = this.data.Artists.All().FirstOrDefault(a => a.Id == id);
            if (existingArtist == null)
            {
                return this.BadRequest("Such artist does not exists!");
            }

            existingArtist.Name = artist.Name;
            existingArtist.Country = artist.Country;
            existingArtist.BirthDate = artist.BirthDate;
            if (artist.WebSite != null)
            {
                existingArtist.WebSite = artist.WebSite;
            }
            
            this.data.SaveChanges();

            artist.Id = id;
            artist.WebSite = existingArtist.WebSite;

            var newArtist = new
            {
                Id = artist.Id,
                Name = artist.Name,
                Country = artist.Country,
                BirthDate = artist.BirthDate,
                WebSite = artist.WebSite
            };

            return this.Ok(newArtist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingArtist = this.data.Artists.All().FirstOrDefault(a => a.Id == id);
            if (existingArtist == null)
            {
                return this.BadRequest("Such artist does not exists!");
            }

            this.data.Artists.Delete(existingArtist);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddAlbum(int id, int albumId)
        {
            var artist = this.data.Artists.All().FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return this.BadRequest("Such artist does not exists - invalid id!");
            }

            var album = this.data.Albums.All().FirstOrDefault(a => a.Id == albumId);
            if (album == null)
            {
                return this.BadRequest("Such album does not exists - invalid id!");
            }

            artist.Albums.Add(album);
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}