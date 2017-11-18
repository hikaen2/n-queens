/*
 * スタック，ミュータブル
 */
#include <cstdint>
#include <cstring>
#include <iostream>
#include <string>

const int N = 30;

struct board {
    uint8_t squares[N * N];
public:
    board() {
        std::memset(squares, 0, N * N);
    }
    std::string to_string() const {
        std::string s;
        for (int y = 0; y < N; y++) {
            for (int x = 0; x < N; x++) {
                s += squares[x * N + y] == 255 ? 'Q' : '.';
            }
            s += '\n';
        }
        s += '\n';
        return s;
    }
    void put(int x, int y, int d) {
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
                squares[(i)* N + (y - x + i)] += d;
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
        squares[x * N + y] = (d == 1 ? 255 : 0);
    }
};

void search(board& p, int y) {
    if (y == N) {
        std::cout << p.to_string();
        exit(0);
    }
    for (int x = 0; x < N; x++) {
        if (p.squares[x * N + y] == 0) {
            p.put(x, y, 1);
            search(p, y + 1);
            p.put(x, y, -1);
        }
    }
}

int main() {
    board p;
    search(p, 0);
    return 0;
}
