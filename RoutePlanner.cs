using System;
using System.Collections.Generic;

//Problem: https://www.testdome.com/questions/c-sharp/route-planner/110513

public class RoutePlanner
{
    public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                      bool[,] mapMatrix)
    {
        if (mapMatrix.GetLength(0) < 1) return false;
        
        bool[,] visitedMatrix = new bool[mapMatrix.GetLength(0), mapMatrix.GetLength(1)];
        
        return RouteFinder(fromRow, fromColumn, toRow, toColumn, mapMatrix, visitedMatrix);
    }
    
    public static bool RouteFinder(int fromRow, int fromColumn, int toRow, int toColumn,
                                      bool[,] mapMatrix, bool[,] visitedMatrix)
    {
        try {
            if (!mapMatrix[fromRow, fromColumn]) { //Is this a road?
                return false;
            }
            
            if (visitedMatrix[fromRow, fromColumn]) { //Did we already visit this cell?
                return false;
            }
            
            if (fromRow == toRow && fromColumn == toColumn) {
                return true;
            }
            
            visitedMatrix[fromRow, fromColumn] = true; //Now visiting this cell...
            
            if (
                RouteFinder(fromRow-1, fromColumn, toRow, toColumn, mapMatrix, visitedMatrix) ||
                RouteFinder(fromRow+1, fromColumn, toRow, toColumn, mapMatrix, visitedMatrix) ||
                RouteFinder(fromRow, fromColumn-1, toRow, toColumn, mapMatrix, visitedMatrix) ||
                RouteFinder(fromRow, fromColumn+1, toRow, toColumn, mapMatrix, visitedMatrix)
            ) {
                return true;
            }
            
            return false;
        } catch (IndexOutOfRangeException e) {
            return false;
        }
    }
    
    public static void Main(string[] args)
    {
        bool[,] mapMatrix = {
            {true, false, false},
            {true, true, false},
            {false, true, true}
        };
        
        Console.WriteLine(RouteExists(0, 0, 2, 2, mapMatrix));
    }
}