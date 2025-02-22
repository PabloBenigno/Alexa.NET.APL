﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Alexa.NET.Response.APL
{
    public class Import:IEquatable<Import>
    {
        public Import() { }

        public Import(string name, string version)
        {
            Name = name;
            Version = version;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        public static Import AlexaStyles => new Import("alexa-styles","1.0.0");
        public static Import AlexaViewportProfilesV1 => new Import("alexa-viewport-profiles", "1.0.0");
        public static Import AlexaViewportProfilesV1_1 => new Import("alexa-viewport-profiles", "1.1.0");
        public static Import AlexaLayouts => new Import("alexa-layouts","1.1.0");

        public void Into(APLDocument document)
        {

            if (document.Imports == null)
            {
                document.Imports = new List<Import>();
            }
            else if (document.Imports.Contains(this))
            {
                return;
            }

            document.Imports.Add(this);
        }

        public bool Equals(Import other)
        {
            if (other == null)
            {
                return false;
            }

            return other.Name == Name && other.Version == Version;
        }
    }
}