namespace StringConverter.Data
{
    public class TranslationResult
    {
        public int Total { get; set; }

        public TranslationContents Contents { get; set; }

        public class TranslationContents
        {
            public string Translated { get; set; }

            public string Text { get; set; }

            public string Translation { get; set; }
        }
    }
}
