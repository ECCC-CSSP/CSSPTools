using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateCodeBase.Models
{
    public class Table
    {
        public Table()
        {
            colList = new List<Col>();
        }
        public string TableName { get; set; }

        public List<Col> colList { get; set; }
        public int ordinalToDelete { get; set; }
    }
}
