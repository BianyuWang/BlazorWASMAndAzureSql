﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BlazorWASMAndAzureSql.Server.databases.models
{
    public partial class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public decimal? AverageHeight { get; set; }
        public string AverageLifespan { get; set; }
        public int? HomeworldId { get; set; }
        public string Language { get; set; }
        public string Url { get; set; }
    }
}