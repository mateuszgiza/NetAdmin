using System.Collections.Generic;

namespace NetAdmin.Domain.Models
{
    public class TableData
    {
        public IEnumerable<string> FieldNames { get; set; }
        public IEnumerable<IEnumerable<string>> Result { get; set; }
        public int RowsAffected { get; set; }

        public string Error { get; set; }
    }
}