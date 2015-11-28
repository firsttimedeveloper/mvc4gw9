﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace mvc4gw9.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int NomenclatureId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<Parameter> Parameters { get; set; }
        public string currentParameters { get; set; }
        public List<string> Gallery { get; set; }
    }

    public class Parameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SelectedValue { get; set; }
        public List<string> Values { get; set; }
    }

}