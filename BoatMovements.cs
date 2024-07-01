using System;

//Problem: https://www.testdome.com/questions/c-sharp/boat-movements/113617

public class BoatMovements
{
    public static bool CanTravelTo(bool[,] gameMatrix, int fromRow, int fromColumn, int toRow, int toColumn)
    {
        try {
            if (toColumn  == fromColumn) {
                if (
                    (IsValidMove(gameMatrix, fromRow-1, fromColumn) && toRow == fromRow-1) ||
                    (IsValidMove(gameMatrix, fromRow+1, fromColumn) && toRow == fromRow+1)
                ) {
                    return true;
                } else {
                    return false;
                }
            } else if (toRow == fromRow) {
                if (
                    (IsValidMove(gameMatrix, fromRow, fromColumn-1) && toColumn == fromColumn-1) ||
                    (IsValidMove(gameMatrix, fromRow, fromColumn+1) && toColumn == fromColumn+1)
                ) {
                    return true;
                } else if (
                    IsValidMove(gameMatrix, fromRow, fromColumn+2) && toColumn == fromColumn+2
                    ) {
                    if (!IsValidMove(gameMatrix, fromRow, fromColumn+1)) { return false; }
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        } catch (IndexOutOfRangeException e) {
            return false;
        }
    }
    
    public static bool IsValidMove(bool[,] gameMatrix, int toRow, int toColumn)
    {
        try {
            if (gameMatrix[toRow, toColumn]) {
                return true;
            } else {
                return false;
            }            
        } catch (IndexOutOfRangeException e) {
            return false;
        }
    }

    public static void Main()
    {
        bool[,] gameMatrix = 
        {
            {false, true,  true,  false, false, false},
            {true,  true,  true,  false, false, false},
            {true,  true,  true,  true,  true,  true},
            {false, true,  true,  false, true,  true},
            {false, true,  true,  true,  false, true},
            {false, false, false, false, false, false},
        };

        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 2, 2)); // true, Valid move
        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 3, 4)); // false, Can't travel through land
        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 6, 2)); // false, Out of bounds
    }
}