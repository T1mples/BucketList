using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public string Comment { get; set; }
    }


}
