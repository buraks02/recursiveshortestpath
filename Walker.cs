using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace consoleShortestPath
{
    /// <summary>
    /// Main actor of application.
    /// Holds full paths
    /// Walks through all combination of path to reach target point.
    /// starts walking from a starting point
    /// </summary>
    public class Walker
    {
        string startingPoint = string.Empty, targetPoint = string.Empty;

        //Holds all paths in memory
        List<Path> allPaths;

        //contains the shortest path
        List<Path> shortestPath;

        //contains currently experiencing path
        List<Path> currentPath;

        public string TargetPoint
        {
            set { targetPoint = value; }
        }

        public string StartingPoint
        {
            set { startingPoint = value; }
        }


        public Walker()
        {
            this.allPaths = new List<Path>();
            this.shortestPath = new List<Path>();
            this.currentPath = new List<Path>();
        }

        /// <summary>
        /// Learn the path
        /// </summary>
        /// <param name="startingPoint"></param>
        /// <param name="endingPoint"></param>
        /// <param name="distance"></param>
        public void AddPath(string startingPoint, string endingPoint, double distance)
        {
            Path path = new Path(startingPoint, endingPoint, distance);
            this.allPaths.Add(path);
        }

        /// <summary>
        /// Moves through a path
        /// </summary>
        /// <param name="?"></param>
        bool Move(Path path)
        {
            if(CheckPathIsAlreadyExperienced(path))
                return false;
            
            currentPath.Add(path);

            Console.WriteLine("Moved from {0} to {1} distance of {2}", path.StartingPoint, path.EndingPoint, path.Distance);

            return true;
        }

        /// <summary>
        /// Gets avaible paths to move according to currentPoint
        /// </summary>
        /// <returns></returns>
        List<Path> GetAvailablePaths(string point)
        {
            List<Path> availablePaths = new List<Path>();
            foreach(Path path in this.allPaths)
            {
                if(path.StartingPoint == point)
                    availablePaths.Add(path);   
            }

            return availablePaths;
        }

        /// <summary>
        /// Start walking from starting point
        /// </summary>
        public void ExperiencePaths()
        {
            Console.WriteLine("Start walking from starting point {0}", this.startingPoint);
            Experience(this.startingPoint);
        }

        void SetShortestPath(List<Path> pathList)
        {
            this.shortestPath.RemoveRange(0, this.shortestPath.Count);
            foreach (Path path in pathList)
            {
                this.shortestPath.Add(path);
            }
        }

        /// <summary>
        /// Experience all combination of paths from a given point
        /// </summary>
        /// <param name="point"></param>
        public void Experience(string point)
        {
            Console.WriteLine("Experiencing all paths from point {0}", point);
            List<Path> availablePaths = GetAvailablePaths(point);
            foreach (Path path in availablePaths)
            {
                if (Move(path))
                {
                    //if target point is reached then check whether current path is shorter than shortestPath
                    if (path.EndingPoint == this.targetPoint)
                    {
                        //Decide if current path is shorter than shortest path
                        if(TotalDistance(this.shortestPath) == 0 || TotalDistance(this.shortestPath) > TotalDistance(this.currentPath))
                            SetShortestPath(this.currentPath);
                    }
                    else
                        //try to reach targetpoint by walking recursively available paths
                        Experience(path.EndingPoint);
                }
                //After experiencing all paths from point go back to get the original state of current path
                this.currentPath.Remove(path);
            }
            Console.WriteLine("Experienced all paths from point {0}", point);
        }

        /// <summary>
        /// Display shortest path
        /// </summary>
        public void DisplayShortestPath()
        {
            foreach (Path path in this.shortestPath)
                Console.WriteLine("{0} to {1} distance of {2}", path.StartingPoint, path.EndingPoint, path.Distance);

            Console.WriteLine("Total Distance : {0}", TotalDistance(this.shortestPath));
        }

        /// <summary>
        /// Calculates total distance of a given path list
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        double TotalDistance(List<Path> paths)
        {
            double totalDistance  = 0;
            foreach (Path path in paths)
                totalDistance += path.Distance;

            return totalDistance;
        }


        /// <summary>
        /// Check whether a path is experienced in currentPath
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        bool CheckPathIsAlreadyExperienced(Path path)
        {
            foreach(Path pathItem in this.currentPath)
                if(pathItem.IsEquals(path))
                    return true;

            return false;
        }


    }
}
