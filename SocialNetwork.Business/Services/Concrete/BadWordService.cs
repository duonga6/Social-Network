using Microsoft.Extensions.Logging;
using System.Reflection;

namespace SocialNetwork.Business.Services.Concrete
{
    public class BadWordService
    {
        private HashSet<string> BadWords;
        private readonly ILogger<BadWordService> _logger;

        public BadWordService(ILogger<BadWordService> logger)
        {
            _logger = logger;
            BadWords = new();
            LoadWord();
        }

        private void LoadWord()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Utilities", "bad_words.txt");
            if (File.Exists(path))
            {
                BadWords = File.ReadAllLines(path).ToHashSet();
                _logger.LogInformation("Loaded bad words: " + BadWords.Count);
            } else
            {
                _logger.LogInformation("Not found bad word file: " + path);
            }
        }

        public bool CheckBadWord(string content)
        {
            string[] splitContent = content.Split(" ");

            foreach (var text in splitContent)
            {
                if (BadWords.Contains(text)) return true;
            }

            return false;
        }
    }
}
