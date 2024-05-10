using BlogMaster_Domain.Entities;
using BlogMaster_Domain.ValueObjects;

namespace BlogMaster_Domain.Agreggates {
    public class PostAgreggate {
        public Post Post { get; private set; }
        public List<Comment> Comments { get; private set; } = new List<Comment>();
        public List<Keyword> Keywords { get; private set; } = new List<Keyword>();

        public PostAgreggate(Post post, List<Comment> comments, List<Keyword> keywords)
        {
            Post = post;
            Comments = comments;
            Keywords = keywords;
        }
    }
}
