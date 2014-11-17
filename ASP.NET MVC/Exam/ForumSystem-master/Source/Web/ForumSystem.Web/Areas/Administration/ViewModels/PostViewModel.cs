namespace ForumSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [UIHint("SingleLineTemplate")]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

        [AllowHtml]
        [Required]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        public string Content { get; set; }

        public string TrimContent
        { 
            get
            {
                if (this.Content.Length > 50)
                {
                    return string.Format("{0}...", this.Content.Substring(0, 30));
                }

                return this.Content;
            }
        }

        public bool IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                         .ForMember(s => s.AuthorName, opt => opt.MapFrom(s => s.Author.UserName));
            configuration.CreateMap<PostViewModel, Post>();
        }
    }
}