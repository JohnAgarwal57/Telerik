namespace ForumSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class IndexBlogPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string AuthorName { get; set; }

        public int VoteScore { get; set; }

        public List<TagViewModel> Tags { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Post, IndexBlogPostViewModel>()
                         .ForMember(s => s.AuthorName, opt => opt.MapFrom(s => s.Author.UserName));
        }
    }
}