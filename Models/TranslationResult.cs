using System.Collections.Generic;

namespace TranslatorAzure.Models
{
    public class TranslationResult
    {
        public List<Translation> Translations { get; set; }
    }

    public class Translation
    {
        public string Text { get; set; }
        public string To { get; set; }
    }
}