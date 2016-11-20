using System.Collections.Generic;

namespace NetAdmin.Models
{
    public class TableDataModel
    {
        public IEnumerable<string> FieldNames { get; set; }
        public IEnumerable<IEnumerable<string>> Result { get; set; }
        public int RowsAffected { get; set; }

        public string Error { get; set; }
    }
}