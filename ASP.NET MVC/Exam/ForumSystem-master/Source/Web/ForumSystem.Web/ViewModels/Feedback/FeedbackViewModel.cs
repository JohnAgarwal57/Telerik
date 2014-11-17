namespace ForumSystem.Web.ViewModels.Feedback
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class FeedbackViewModel : IMapFrom<Feedback>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [UIHint("SingleLineTemplate")]
        public string AuthorName { get; set; }

        public string AuthorId { get; set; }

        [AllowHtml]
        [MaxLength(20)]
        [Required(ErrorMessage = "Title is required")]
        [UIHint("SingleLineTemplate")]
        public string Title { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Content is required")]
        [UIHint("MultiLineTemplate")]
        public string Content { get; set; }

        public DateTime? CreatedOn { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Feedback, FeedbackViewModel>()
                         .ForMember(s => s.AuthorName, opt => opt.MapFrom(s => s.Author.UserName));
            configuration.CreateMap<FeedbackViewModel, Feedback>();
        }
    }
}