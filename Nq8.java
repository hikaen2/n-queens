// ミュータブル
public class Nq8 {

    private static class Board {
        public static final int N = 30;
        public byte[] squares;

        public Board() {
            squares = new byte[N * N];
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

        public void put(int x, int y, int d) {
            for (int i = 0; i < N; i++) {
                squares[x * N + i] += d;
                squares[i * N + y] += d;
            }
            if (x > y) {
                for (int i = 0; i < N - (x - y); i++) {
                    squares[(x - y + i) * N + (i)] += d;
                }
            } else {
                for (int i = 0; i < N - (y - x); i++) {
                    squares[(i) * N + (y - x + i)] += d;
                }
            }
            if (x + y < N) {
                for (int i = 0; i <= x + y; i++) {
                    squares[(x + y - i) * N + (i)] += d;
                }
            } else {
                for (int i = x + y - N + 1; i < N; i++) {
                    squares[(x + y - i) * N + (i)] += d;
                }
            }
            squares[x * N + y] = (byte) (d == 1 ? -1 : 0);
        }
    }

    private static void search(Board p, int y) {
        if (y == Board.N) {
            System.out.println(p.toString());
            System.exit(0);
        }
        for (int x = 0; x < Board.N; x++) {
            if (p.squares[x * Board.N + y] == 0) {
                p.put(x, y, 1);
                search(p, y + 1);
                p.put(x, y, -1);
            }
        }
    }

    public static void main(String[] args) {
        Board p = new Board();
        search(p, 0);
    }

}
