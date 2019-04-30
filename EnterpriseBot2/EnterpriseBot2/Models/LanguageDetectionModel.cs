using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseBot2.Models
{
    public class LanguageDetectionModel
    {
        public LanguageDetection languageDetection { get; set; }
        public KeyPhrases keyPhrases { get; set; }
        public Sentiment sentiment { get; set; }
        public Entities entities { get; set; }
    }
    public class DetectedLanguage
    {
        public string name { get; set; }
        public string iso6391Name { get; set; }
        public double score { get; set; }
    }

    public class LanguageDetection
    {
        public List<Document> documents { get; set; }
        public List<object> errors { get; set; }
    }

    public class Error
    {
        public string id { get; set; }
        public string message { get; set; }
    }

    public class KeyPhrases
    {
        public List<object> documents { get; set; }
        public List<Error> errors { get; set; }
    }

    public class Error2
    {
        public string id { get; set; }
        public string message { get; set; }
    }

    public class Sentiment
    {
        public List<object> documents { get; set; }
        public List<Error2> errors { get; set; }
    }

    public class Error3
    {
        public string id { get; set; }
        public string message { get; set; }
    }

    public class Entities
    {
        public List<object> documents { get; set; }
        public List<Error3> errors { get; set; }
    }

}
