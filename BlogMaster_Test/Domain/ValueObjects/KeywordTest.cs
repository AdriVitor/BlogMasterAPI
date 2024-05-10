using BlogMaster_Domain.ValueObjects;

namespace BlogMaster_Test.Domain.ValueObjects {
    public class KeywordTest {

        [Fact]
        public void ValidatePropertyPostId() {
            var exception = Assert.Throws<Exception>(() => {
                var keyword = new Keyword(0, "word test");
            });

            Assert.Equal("Informe um post válido", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public void ValidatePropertyWord() {
            var exception = Assert.Throws<Exception>(() => {
                var keyword = new Keyword(1, "");
            });

            Assert.Equal("Informe um título com tamanho válido", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }
    }
}
