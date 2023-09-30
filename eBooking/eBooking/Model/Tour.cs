using eBooking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBooking.Model
{
    public class Tour : ISerializable
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string city { get; set; }
        public int maxGuests { get; set; }
        public int duration { get; set; }
        public string imageUrl { get; set; }

        public Tour() 
        { 
        }

        public Tour(string name, string description, string language, string city, int maxGuests, int duration, string imgUrl) 
        {
            this.name = name;
            this.description = description;
            this.language = language;
            this.city = city;
            this.maxGuests = maxGuests;
            this.duration = duration;
            this.imageUrl = imgUrl;
            
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                id.ToString(),
                name.ToString(),
                description.ToString(),
                language.ToString(),
                city.ToString(),
                maxGuests.ToString(),
                duration.ToString(),
                imageUrl.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values) 
        { 
            id = Convert.ToInt32(values[0]);
            name = Convert.ToString(values[1]);
            description = Convert.ToString(values[2]);
            language = Convert.ToString(values[3]);
            city = Convert.ToString(values[4]);
            maxGuests = Convert.ToInt32(values[5]);
            duration = Convert.ToInt32(values[6]);
            imageUrl = Convert.ToString(values[7]);
        }
    }
}
