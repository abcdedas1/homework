﻿
using SQLite;

namespace HelloNetMauiBlazorHybridApp.Models
{
    public class Poetry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }
    }
}
