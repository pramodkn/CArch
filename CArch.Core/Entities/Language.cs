using System;
using System.Collections.Generic;
using System.Text;

namespace CArch.Core.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MovieLanguage> MovieLanguages { get; set; }
    }
}
