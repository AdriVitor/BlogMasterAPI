using BlogMaster_Domain.Entities;

namespace BlogMaster_Application.DTOs.PostDTO {
    public class PostDTO {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
        public int AuthorId { get; set; }

        public Post ConvertToPost() {
            var post = new Post(Id, Title, Description, PostDate, AuthorId);

            return post;
        }
    }
}
