using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace consoleShortestPath
{
    /// <summary>
    /// Definition of a path
    /// </summary>
    public class Path
    {
        //beginning and ending points
        string startingPoint, endingPoint;

        //distance of path
        double distance;

        public string EndingPoint
        {
            get { return endingPoint; }
        }

        public string StartingPoint
        {
            get { return startingPoint; }
        }
        

        public double Distance
        {
            get { return distance; }
        }

        public Path(string startingPoint, string endingPoint, double distance)
        {
            this.startingPoint = startingPoint;
            this.endingPoint = endingPoint;
            this.distance = distance;
        }

        //copy constructor
        public Path(Path Path)
        {
            this.startingPoint = Path.startingPoint;
            this.endingPoint = Path.endingPoint;
            this.distance = Path.distance;
        }

        public bool IsEquals(Path path)
        {
            if (this.startingPoint == path.startingPoint &&
                this.endingPoint == path.endingPoint)
                return true;
            else return false;
        }
    }
}
