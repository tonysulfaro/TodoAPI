using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models {
    public class Document {
        public int DocumentId { get; set; }
        public string RelativePath { get; set; }
        public string OriginalName { get; set; }
        public string MimeType { get; set; }
    }
}
