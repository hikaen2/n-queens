// イミュータブル
using System;
using System.Text;

namespace nq5
{
    class Board
    {
        public const int N = 30;
        public byte[] squares;
        public Board()
        {
            this.squares = new byte[N * N];
        }
        public Board(Board p)
        {
            this.squares = (byte[])p.squares.Clone();
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
        public Board put(int x, int y)
        {
            var p = new Board(this);
            for (int i = 0; i < N; i++)
            {
                p.squares[x * N + i] = 1;
                p.squares[i * N + y] = 1;
            }
            if (x > y)
            {
                for (int i = 0; i < N - (x - y); i++)
                {
                    p.squares[(x - y + i) * N + (i)] = 1;
                }
            }
            else
            {
                for (int i = 0; i < N - (y - x); i++)
                {
                    p.squares[(i) * N + (y - x + i)] = 1;
                }
            }
            if (x + y < N)
            {
                for (int i = 0; i <= x + y; i++)
                {
                    p.squares[(x + y - i) * N + (i)] = 1;
                }
            }
            else
            {
                for (int i = x + y - N + 1; i < N; i++)
                {
                    p.squares[(x + y - i) * N + (i)] = 1;
                }
            }
            p.squares[x * N + y] = 255;
            return p;
        }
    }

    class Nq5
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
                    search(p.put(x, y), y + 1);
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
