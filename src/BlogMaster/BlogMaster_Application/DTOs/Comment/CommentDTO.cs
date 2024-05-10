using BlogMaster_Domain.ValueObjects;

namespace BlogMaster_Application.DTOs.CommentDTO {
    public class CommentDTO {
        public int AuthorId { get; set; }
        public int PostId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfPosting { get; set; }

        public Comment ConvertoToComment() {
            var comment = new Comment(AuthorId, PostId, Description, DateOfPosting);

            return comment;
        }
    }
}
