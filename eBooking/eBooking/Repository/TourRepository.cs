using eBooking.Model;
using eBooking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBooking.Repository
{
    public class TourRepository
    {
        private const string filePath = "../../Data/tours.csv";
        private readonly Serializer<Tour> serializer;
        private List<Tour> tours;
        public TourRepository() 
        {
            serializer = new Serializer<Tour>();
            tours = serializer.FromCSV(filePath);
        }

        public List<Tour> GetAll()
        {
            return serializer.FromCSV(filePath);
        }
    }
}
