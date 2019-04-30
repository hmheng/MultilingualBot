using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseBot2.Models
{
    public class Document
    {
        public string id { get; set; }
        public string text { get; set; }
        public List<DetectedLanguage> detectedLanguages { get; set; }
    }

    public class LanguageDetectionRequestModel
    {
        public List<Document> documents { get; set; }
    }
}
