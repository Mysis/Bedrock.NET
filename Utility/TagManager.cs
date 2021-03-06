﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Bedrock.Utility {
    public class TagManager {
        private static readonly Regex ValidCharacters = new Regex(@"^[-_\+\.A-Za-z0-9]*$");
        public int NumUniqueTags { get; private set; }
        private HashSet<string> _tags { get; set; }
        public IReadOnlyCollection<string> Tags { 
            get {
                return _tags;
            }
        }

        public TagManager() {
            NumUniqueTags = 0;
            _tags = new HashSet<string>();
        }

        public Tag Create(string value) {
            if (!ValidCharacters.IsMatch(value)) {
                throw new Exception("Tag " + value + " has invalid characters.");
            }
            if (_tags.Contains(value)) {
                throw new Exception("Tag " + value + " already exists.");
            }

            _tags.Add(value);

            return new Tag(value, true);
        }
    }
}
