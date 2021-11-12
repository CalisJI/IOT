using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TEST.Data
{
    public class DocumentObject
    {
        public string LinkDocument { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentGroup { get; set; }
        public string DocumentCategory { get; set; }
        public float DocumentVersion { get; set; }
        public DateTime DocumentDateUpLoad { get; set; }
    }
}
