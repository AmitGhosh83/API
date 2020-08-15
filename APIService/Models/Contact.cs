using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APIService.Models
{
    public class Contact
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        //[JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("date_added")]
        public DateTime DateAdded { get; set; }
       // [JsonProperty("phones")]
        public Phone[] Phones { get; set; }
    }

    public class Phone
    {
        [JsonProperty("number", DefaultValueHandling =DefaultValueHandling.Ignore)]
        public string Number { get; set; }

        [JsonProperty("phone_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PhoneType PhoneType { get; set; }
    }

    public enum PhoneType
    {
        Nil,
        Home,
        Mobile,
    }
}
