// ミュータブル
using System;
using System.Text;

namespace nq6
{
    class Board
    {
        public const int N = 30;
        public byte[] squares;
        public Board()
        {
            this.squares = new byte[N * N];
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int y = 0; y < N; y++)
            {
                for (int x = 0; x < N; x++)
                {
                    sb.Append(squares[x * N + y] == 255 ? 'Q' : '.');
                }
                sb.Append('\n');
            }
            sb.Append('\n');
            return sb.ToString();
        }
        public void put(int x, int y, int d)
        {
            for (int i = 0; i < N; i++)
            {
                squares[x * N + i] += (byte)d;
                squares[i * N + y] += (byte)d;
            }
            if (x > y)
            {
                for (int i = 0; i < N - (x - y); i++)
                {
                    squares[(x - y + i) * N + (i)] += (byte)d;
                }
            }
            else
            {
                for (int i = 0; i < N - (y - x); i++)
                {
                    squares[(i) * N + (y - x + i)] += (byte)d;
                }
            }
            if (x + y < N)
            {
                for (int i = 0; i <= x + y; i++)
                {
                    squares[(x + y - i) * N + (i)] += (byte)d;
                }
            }
            else
            {
                for (int i = x + y - N + 1; i < N; i++)
                {
                    squares[(x + y - i) * N + (i)] += (byte)d;
                }
            }
            squares[x * N + y] = (byte)(d == 1 ? 255 : 0);
        }
    }
    class Nq6
    {
        static void search(Board p, int y)
        {
            if (y == Board.N)
            {
                Console.WriteLine(p.ToString());
                System.Environment.Exit(0);
            }
            for (int x = 0; x < Board.N; x++)
            {
                if (p.squares[x * Board.N + y] == 0)
                {
                    p.put(x, y, 1);
                    search(p, y + 1);
                    p.put(x, y, -1);
                }
            }
        }
        static void Main(string[] args)
        {
            var p = new Board();
            search(p, 0);
        }
    }
}
