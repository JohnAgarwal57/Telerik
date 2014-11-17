namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ForumSystem.Common;
    using ForumSystem.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private const string InitialPassword = "123456";
        private readonly IRandomGenerator randomGenerator;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
            this.randomGenerator = RandomGenerator.Instance;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.SeedUsers(context);
            this.SeedTags(context);
            this.SeedPosts(context);
        }

        private void SeedPosts(ApplicationDbContext context)
        {
            if (context.Posts.Any())
            {
                return;
            }

            var users = context.Users.ToList();
            var tags = context.Tags.ToList();

            for (int i = 0; i < 10; i++)
            {
                var userId = users[this.randomGenerator.GetRandomNumber(0, users.Count - 1)].Id;
                var postTags = new List<Tag>();

                for (int j = 0; j < 5; j++)
                {
                    var tag = tags[this.randomGenerator.GetRandomNumber(0, tags.Count - 1)];
                    postTags.Add(tag);
                }

                var post = new Post()
                {
                    Title = this.randomGenerator.GetRandomStringWithRandomLength(5, 15),
                    Content = this.randomGenerator.GetRandomStringWithRandomLength(40, 400),
                    AuthorId = userId,
                    Tags = postTags
                };

                context.Posts.Add(post);
            }

            context.SaveChanges();
        }

        private void SeedTags(ApplicationDbContext context)
        {
            if (context.Tags.Any())
            {
                return;
            }

            for (int i = 0; i < 20; i++)
            {
                var tag = new Tag
                {
                    Name = this.randomGenerator.GetRandomStringWithRandomLength(3, 6)
                };

                context.Tags.Add(tag);
            }

            context.SaveChanges();
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            var user = new ApplicationUser { UserName = "ivan@abv.bg", Email = "ivan@abv.bg" };
            manager.Create(user, InitialPassword);

            user = new ApplicationUser { UserName = "peter@abv.bg", Email = "peter@abv.bg" };
            manager.Create(user, InitialPassword);

            context.SaveChanges();
        }
    }
}