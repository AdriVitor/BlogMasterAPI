using BlogMaster_Application.DTOs.KeywordDTO;
using BlogMaster_Application.Services;
using BlogMaster_Domain.ValueObjects;
using BlogMaster_Infraestructure.Repositories.Interfaces;
using Moq;

namespace BlogMaster_Test.Application {
    public class KeywordServiceTest {

        [Fact]
        public async Task ValidateQuantityKeywordsOfPost_Add() {
            var keywordRepositoryMock = new Mock<IKeywordRepository>();

            var postId = 1;

            var keywords = MockListKeyword(postId);

            var wordList = new List<string> ();
            wordList.AddRange(keywords.Select(w => w.Word));

            keywordRepositoryMock.Setup(k => k.GetAllByPostId(postId))
                            .Returns(Task.FromResult(keywords));

            var keywordService = new KeywordService(keywordRepositoryMock.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => {
                await keywordService.Add(postId, wordList);
            });


            Assert.Equal("O limite de palavras-chave é de 10 pra cada post", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public async Task ValidateKeywordsDuplicatesOfPost_Add() {
            var keywordRepositoryMock = new Mock<IKeywordRepository>();

            var postId = 1;

            var keyword = new Keyword(postId, "keywordTest");
            var keyword1 = new Keyword(postId, "keywordTest1");

            List<Keyword> keywords = new List<Keyword> { keyword, keyword1 };

            var wordList = new List<string>() { "keywordTest" };

            keywordRepositoryMock.Setup(k => k.GetAllByPostId(postId))
                            .Returns(Task.FromResult(keywords));

            var keywordService = new KeywordService(keywordRepositoryMock.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => {
                await keywordService.Add(postId, wordList);
            });


            Assert.Equal("Não é possível adicionar a mesma palavra-chave identicas no mesmo post", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        [Fact]
        public async Task ValidateKeywordsDuplicatesOfPost_Update() {
            var keywordRepositoryMock = new Mock<IKeywordRepository>();

            var postId = 1;

            var keywordDTO = new KeywordDTO() { PostId = 1, Word = "keywordTest" };          

            var keywords = MockListKeyword(postId);
            keywordRepositoryMock.Setup(k => k.GetAllByPostId(postId))
                            .Returns(Task.FromResult(keywords));

            var keywordService = new KeywordService(keywordRepositoryMock.Object);

            var exception = await Assert.ThrowsAsync<Exception>(async () => {
                await keywordService.Update(keywordDTO);
            });


            Assert.Equal("Não é possível adicionar a mesma palavra-chave identicas no mesmo post", exception.Message);
            Assert.Equal(typeof(Exception), exception.GetType());
        }

        private List<Keyword> MockListKeyword(int postId) {
            var keyword = new Keyword(postId, "keywordTest");
            var keyword1 = new Keyword(postId, "keywordTest1");
            var keyword2 = new Keyword(postId, "keywordTest2");
            var keyword3 = new Keyword(postId, "keywordTest3");
            var keyword4 = new Keyword(postId, "keywordTest4");
            var keyword5 = new Keyword(postId, "keywordTest5");
            var keyword6 = new Keyword(postId, "keywordTest6");
            var keyword7 = new Keyword(postId, "keywordTest7");
            var keyword8 = new Keyword(postId, "keywordTest8");
            var keyword9 = new Keyword(postId, "keywordTest9");
            var keyword10 = new Keyword(postId, "keywordTest10");
            List<Keyword> keywords = new List<Keyword> { keyword, keyword1, keyword2, keyword3, keyword4, keyword5, keyword6, keyword7, keyword8, keyword9, keyword10 };

            return keywords;
        }
    }
}
