namespace EasyPTC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EasyPTC.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<EasyPtcDbContext>
    {
        private const string InitialPassword = "123456";
        private const string AdminName = "admin@abv.bg";
        private const string AdminRole = "Admin";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EasyPtcDbContext context)
        {
            this.SeedRoles(context);
            this.SeedUsers(context);
            this.SeedAds(context);
        }

        private void SeedUsers(EasyPtcDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            var user = new User { UserName = AdminName, Email = AdminName };

            manager.Create(user, InitialPassword);
            manager.AddToRole(user.Id, AdminRole);

            context.SaveChanges();
        }

        private void SeedRoles(EasyPtcDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            context.Roles.Add(new IdentityRole { Name = AdminRole });
            context.SaveChanges();
        }

        private void SeedAds(EasyPtcDbContext context)
        {
            if (context.Advertisements.Any())
            {
                return;
            }

            context.Advertisements.AddOrUpdate(a => a.Id,
                new Advertisement
                {
                    Name = "We are cool 1",
                    AvailableClicks = 500,
                    Type = AdType.TextAd,
                    Target = "http://abv.bg"
                },
                new Advertisement
                {
                    Name = "We are cool 2",
                    AvailableClicks = 500,
                    Type = AdType.TextAd,
                    Target = "http://abv.bg"
                }, new Advertisement
                   {
                       Name = "We are cool 3",
                       AvailableClicks = 500,
                       Type = AdType.TextAd,
                       Target = "http://abv.bg"
                   },
                new Advertisement
                {
                    Name = "We are cool 4",
                    AvailableClicks = 500,
                    Type = AdType.TextAd,
                    Target = "http://abv.bg"
                },
                new Advertisement
                {
                    Name = "We are cool 5",
                    AvailableClicks = 500,
                    Type = AdType.TextAd,
                    Target = "http://abv.bg"
                }, new Advertisement
                   {
                       Name = "We are cool 6",
                       AvailableClicks = 500,
                       Type = AdType.TextAd,
                       Target = "http://abv.bg"
                   }, new Advertisement
                   {
                       Name = "We are cool 7",
                       AvailableClicks = 500,
                       Type = AdType.TextAd,
                       Target = "http://abv.bg"
                   }, new Advertisement
                      {
                          Name = "We are cool 8",
                          AvailableClicks = 500,
                          Type = AdType.TextAd,
                          Target = "http://abv.bg"
                      },
                new Advertisement
                {
                    Name = "We are cool 9",
                    AvailableClicks = 500,
                    Type = AdType.TextAd,
                    Target = "http://abv.bg"
                }, new Advertisement
                   {
                       Name = "We are cool 10",
                       AvailableClicks = 500,
                       Type = AdType.TextAd,
                       Target = "http://abv.bg"
                   }, new Advertisement
                      {
                          Name = "We are cool 11",
                          AvailableClicks = 500,
                          Type = AdType.TextAd,
                          Target = "http://abv.bg"
                      },
                new Advertisement
                {
                    Name = "We are cool 12",
                    AvailableClicks = 500,
                    Type = AdType.TextAd,
                    Target = "http://abv.bg"
                }, new Advertisement
                   {
                       Name = "We are cool 13",
                       AvailableClicks = 500,
                       Type = AdType.TextAd,
                       Target = "http://abv.bg"
                   }, new Advertisement
                      {
                          Name = "We are cool 14",
                          AvailableClicks = 500,
                          Type = AdType.TextAd,
                          Target = "http://abv.bg"
                      },
                new Advertisement
                {
                    Name = "Banner 1",
                    AvailableClicks = 500,
                    Url = "http://t2.ftcdn.net/jpg/00/35/62/69/400_F_35626947_AE3O3eYYsOnxyggDu0Ab6tW5jT14ocip.jpg",
                    Type = AdType.Banner,
                    Target = "http://abv.bg"
                }, new Advertisement
                   {
                       Name = "Banner 2",
                       AvailableClicks = 500,
                       Url = "http://images.all-free-download.com/images/graphiclarge/internet_text_banners_origami_style_310737.jpg",
                       Type = AdType.Banner,
                       Target = "http://abv.bg"
                   }, new Advertisement
                   {
                       Name = "Banner 3",
                       AvailableClicks = 500,
                       Url = "http://images.all-free-download.com/images/graphiclarge/origami_banners_310993.jpg",
                       Type = AdType.Banner,
                       Target = "http://abv.bg"
                   });
        }
    }
}