using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS
{
    // Holds point data for the track. Since we need a lot of points, an array of this class is the best way to store the data.
    public class TrackPoint
    {
        private double lon;
        private double lat;
        private DateTime created;
        private int isEnd;

        /// <summary>
        /// Constructor for points.
        /// </summary>
        /// <param name="lo">longatude of the point</param>
        /// <param name="la">Latitude of the point</param>
        /// <param name="end">If the point is a break in the track. 0 for no, 1 for yes</param>
        public TrackPoint(double lo, double la, int end)
        {
            lon = lo;
            lat = la;
            created = DateTime.Now;
            isEnd = end;
        }

        /// <summary>
        /// Adds the point's data to a given string, then returns the updated string.
        /// </summary>
        /// <param name="target">A string to add the point data to</param>
        /// <returns>The given string, updated with the point's data</returns>
        public String appendSelf (string target)
        {
            // created is entered twice to give the data in the way Ozi reads, and a way a person can read, respectivly.
            // Why? Ask Ozi's creators.
            string updated = target + "\n " + lon + "," + lat + "," + isEnd + ", -777.0," + created.ToOADate() + "," + created;
            return updated;
        }  
     }
}
