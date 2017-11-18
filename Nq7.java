// イミュータブル
public class Nq7 {

    private static class Board {
        public static final int N = 30;
        public byte[] squares;

        public Board() {
            squares = new byte[N * N];
        }

        public Board(Board p) {
            squares = p.squares.clone();
        }

        @Override
        public String toString() {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < N; y++) {
                for (int x = 0; x < N; x++) {
                    sb.append(squares[x * N + y] == -1 ? 'Q' : '.');
                }
                sb.append('\n');
            }
            sb.append('\n');
            return sb.toString();
        }

        public Board put(int x, int y) {
            Board p = new Board(this);
            for (int i = 0; i < N; i++) {
                p.squares[x * N + i] = 1;
                p.squares[i * N + y] = 1;
            }
            if (x > y) {
                for (int i = 0; i < N - (x - y); i++) {
                    p.squares[(x - y + i) * N + (i)] = 1;
                }
            } else {
                for (int i = 0; i < N - (y - x); i++) {
                    p.squares[(i) * N + (y - x + i)] = 1;
                }
            }
            if (x + y < N) {
                for (int i = 0; i <= x + y; i++) {
                    p.squares[(x + y - i) * N + (i)] = 1;
                }
            } else {
                for (int i = x + y - N + 1; i < N; i++) {
                    p.squares[(x + y - i) * N + (i)] = 1;
                }
            }
            p.squares[x * N + y] = -1;
            return p;
        }
    }

    private static void search(Board p, int y) {
        if (y == Board.N) {
            System.out.println(p.toString());
            System.exit(0);
        }
        for (int x = 0; x < Board.N; x++) {
            if (p.squares[x * Board.N + y] == 0) {
                search(p.put(x, y), y + 1);
            }
        }
    }

    public static void main(String[] args) {
        Board p = new Board();
        search(p, 0);
    }

}
