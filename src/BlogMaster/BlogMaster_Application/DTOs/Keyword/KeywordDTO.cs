using BlogMaster_Domain.ValueObjects;

namespace BlogMaster_Application.DTOs.KeywordDTO {
    public class KeywordDTO {
        public int PostId { get; set; }
        public string Word { get; set; }

        public Keyword ConvertToKeyword() {
            var keyword = new Keyword(PostId, Word);

            return keyword;
        }
    }
}
