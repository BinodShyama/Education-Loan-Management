using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.ViewModel.Datatable
{
    public class DataTablePostModel
    {

        // properties are not capital due to json mapping
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }
    }

    public class Column
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public List<Search> search { get; set; }
        public List<Order> order { get; set; }

    }

    //ttt
    public class sDTPostModel
    {
        // properties are not capital due to json mapping
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<sColumn> columns { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }
    }

    public class sColumn
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }

    }

    public class Search
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class Order
    {
        public int column { get; set; }
        public string dir { get; set; }
    }

    public class ColumnFilter
    {
        public string column { get; set; }
        public string dataType { get; set; }
        public string filter { get; set; }
        public List<string> value { get; set; }
        public Type type { get; set; }
    }
}

