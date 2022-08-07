namespace BattleShipStateTracker
{
    public class BattleShipStateTracker
    {
        const int BoardSize = 10;
        const int EmptyCell = 0;
        const int ShipCell = 1;

        private int[,] board;

        public BattleShipStateTracker()
        {
            board = new int[BoardSize, BoardSize];
        }

        // Assume given head and tail cells are valid, i.e. tailRow >= headRow or tailCol >= headCol
        public Boolean AddShip(int headRow, int headCol, int tailRow, int tailCol)
        {
            if (!IsCoordinateValidToAddShip(headRow, headCol) || !IsCoordinateValidToAddShip(tailRow, tailCol))
            {
                return false;
            }

            if (headRow != tailRow)
            {
                if (headCol != tailCol) return false;
            }

            // Fill the given area with a ship 
            for (int i = headRow; i <= tailRow; i++)
            {
                for (int j = headCol; j <= tailCol; j++)
                {
                    board[i, j] = ShipCell;
                }
            }
            return true;
        }

        public String TakeHit(int row, int col)
        {
            if (row < 0 || col < 0 || row >= BoardSize || col >= BoardSize)
            {
                return "Miss";
            }
            if (board[row, col] == EmptyCell)
            {
                return "Miss";
            }
            
            board[row, col] = EmptyCell;
            return "Hit";
        }

        public Boolean IsLost()
        {
            return !HasShip();
        }


        private Boolean IsCoordinateValidToAddShip(int row, int col)
        {
            if (row < 0 || row >= BoardSize || col < 0 || col >= BoardSize) return false;

            // Check if there are ships in adjacent cells
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1;  j <= col+ 1; j++)
                {
                    if (i > 0 && i < BoardSize && j > 0 && j < BoardSize)
                    {
                        if (board[i, j] == 1) return false;
                    }
                }
            }
            return true;
        }

        private Boolean HasShip()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (board[i, j] == ShipCell) return true;
                }
            }
            return false;
        }

        public void PrintBoard()
        {
            Console.WriteLine("--------------------");
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------");
        }

    }
}
