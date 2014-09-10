namespace Musicians.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using Musicians.ConsoleClient.Models;

    public class EntryPoint
    {
        private const string ServerUri = "http://localhost:8570/";
        private const string HeaderValue = "application/json";

        private const string Artists = "api/Artists/";
        private const string Songs = "api/Songs/";
        private const string Albums = "api/Albums/";

        private const string All = "All";
        private const string AllWithSongs = "AllWithSongs";
        private const string Create = "Create";
        private const string ById = "ById/";
        private const string ByName = "ByName/";
        private const string ByTitle = "ByTitle/";
        private const string Update = "Update/";
        private const string Delete = "Delete/";

        private const string AddSong = "AddSong/";
        private const string AddArtist = "AddArtist/";

        private static readonly HttpClient client = new HttpClient 
        {
            BaseAddress = new Uri(ServerUri) 
        };

        private static void Main()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HeaderValue));

            AddNewArtist("Gosho", "Bulgaria", "2001-09-10 21:53:44.203", "www.gosho.com");
            AddNewArtist("Pesho", "Bulgaria", "2003-05-12 21:53:44.203", "www.pesho.com");

            AddNewSong("Gosho best song", "Gosho's rock", "2014", "5.1");
            AddNewSong("Pesho best song", "Pesho's rock", "2014", "3.3");
            AddNewSong("Gosho and Pesho best song", "Crazy's rock", "2014", "7.1");

            AddNewAlbum("Gosho The best", "2014", "2");
            AddNewAlbum("Pesho The best", "2014", "2");

            AddArtistToSong(1, 1);
            AddArtistToSong(2, 2);
            AddArtistToSong(3, 1);
            AddArtistToSong(3, 2);

            AddSongToAlbum(1, 1);
            AddSongToAlbum(1, 3);

            AddSongToAlbum(2, 2);
            AddSongToAlbum(2, 3);

            GetAllAlbums();
            GetAllArtists();
            GetAllSongs();

            GetSongById(1);
            GetSongByTitle("Pesho best song");


            UpdateArtist(2, "Pesho Peshov", "Albania", "2003-05-12 21:53:44.203", "www.pesho.alb");
            GetArtistByName("Pesho Peshov");

            DeleteSong(1);
            GetSongById(1);
        }

        private static void DeleteSong(int id)
        {
            Console.WriteLine("Deleting artist...");

            HttpResponseMessage response = client.DeleteAsync(Songs + Delete + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void UpdateArtist(int id, string newName, string newCountry, string newBirthDate, string newWebSite)
        {
            Console.WriteLine("Updating artist...");
            var artist = new ArtistModels
            {
                Name = newName,
                Country = newCountry,
                BirthDate = newBirthDate,
                WebSite = newWebSite
            };

            HttpResponseMessage response = client.PutAsJsonAsync(Artists + Update + id, artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void GetArtistByName(string name)
        {
            Console.WriteLine("Artist with name {0}:", name);
            HttpResponseMessage response = client.GetAsync(Artists + ByName + name).Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<ArtistModels>().Result;

                Console.WriteLine("Id : {0}, Name: {1}, Birthdate: {2}, Country : {3}, Website : {4}"
                        , artist.Id, artist.Name, artist.BirthDate, artist.Country, artist.WebSite);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.WriteLine(".............................");
        }

        private static void GetSongById(int id)
        {
            Console.WriteLine("Song with Id {0}:", id);
            HttpResponseMessage response = client.GetAsync(Songs + ById + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<SongModel>().Result;

                Console.WriteLine("Id : {0}, Title: {1}, Length: {2}, Year : {3}"
                        , song.Id, song.Title, song.Length, song.Year);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.WriteLine(".............................");
        }

        private static void GetSongByTitle(string title)
        {
            Console.WriteLine("Song with title {0}:", title);
            HttpResponseMessage response = client.GetAsync(Songs + ByTitle + title).Result;
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<SongModel>().Result;

                Console.WriteLine("Id : {0}, Title: {1}, Length: {2}, Year : {3}"
                        , song.Id, song.Title, song.Length, song.Year);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.WriteLine(".............................");
        }

        private static void AddSongToAlbum(int albumId, int songId)
        {
            var postData = new List<KeyValuePair<string, string>>();
            HttpContent content = new FormUrlEncodedContent(postData);
            HttpResponseMessage response = client.PostAsync(Albums + AddSong + albumId + "?songId=" + songId, content).Result;

        }

        private static void AddArtistToSong(int songId, int artistId)
        {   
            var postData = new List<KeyValuePair<string, string>>();
            HttpContent content = new FormUrlEncodedContent(postData);
            HttpResponseMessage response = client.PostAsync(Songs + AddArtist + songId + "?artistId=" + artistId, content).Result;
        }

        private static void AddNewAlbum(string title, string year, string numberOfSongs)
        {
            Console.WriteLine("Creating album...");
            var album = new AlbumModel
            {
                Title = title,
                NumberOfSongs = numberOfSongs,
                Year = year,
            };

            HttpResponseMessage response = client.PostAsJsonAsync(Albums + Create, album).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void AddNewSong(string title, string genre, string year, string length)
        {
            Console.WriteLine("Creating song...");
            var song = new SongModel
            {
                Title = title,
                Genre = genre,
                Year = year,
                Length = length
            };

            HttpResponseMessage response = client.PostAsJsonAsync(Songs + Create, song).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void AddNewArtist(string name, string country, string birthdate, string website)
        {
            Console.WriteLine("Creating artist...");
            var artist = new ArtistModels 
            { 
                Name = name, 
                Country = country,
                BirthDate = birthdate,
                WebSite = website
            };

            HttpResponseMessage response = client.PostAsJsonAsync(Artists + Create, artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void GetAllAlbums()
        {
            Console.WriteLine("Albums:");
            HttpResponseMessage response = client.GetAsync(Albums + AllWithSongs).Result;
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<AlbumModel>>().Result;

                foreach (var album in albums)
                {
                    Console.WriteLine("Id : {0}, Title: {1}, Number of songs: {2}, Year : {3}"
                        , album.Id, album.Title, album.NumberOfSongs, album.Year);

                    Console.WriteLine("Album songs:");

                    foreach (var song in album.Songs)
                    {
                        Console.WriteLine(song.Title);
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.WriteLine(".............................");
        }

        private static void GetAllArtists()
        {
            Console.WriteLine("Artists:");
            HttpResponseMessage response = client.GetAsync(Artists + AllWithSongs).Result;
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<ArtistModels>>().Result;

                foreach (var artist in artists)
                {
                    Console.WriteLine("Id : {0}, Name: {1}, Birthdate: {2}, Country : {3}, Website : {4}"
                        , artist.Id, artist.Name, artist.BirthDate, artist.Country, artist.WebSite);

                    Console.WriteLine("Artist songs:");
                    foreach (var song in artist.Songs)
                    {
                        Console.WriteLine(song.Title);
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.WriteLine(".............................");
        }

        private static void GetAllSongs()
        {
            Console.WriteLine("Songs:");
            HttpResponseMessage response = client.GetAsync(Songs + AllWithSongs).Result;
            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<SongModel>>().Result;

                foreach (var song in songs)
                {
                    Console.WriteLine("Id : {0}, Title: {1}, Length: {2}, Year : {3}"
                        , song.Id, song.Title, song.Length, song.Year);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.WriteLine(".............................");
        }
    }
}
