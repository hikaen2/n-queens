/*
 * ヒープ，イミュータブル
 */
#include <cstdint>
#include <cstring>
#include <iostream>
#include <string>

const int N = 30;

struct board {
    uint8_t* squares;
public:
    board() {
        squares = new uint8_t[N * N];
        std::memset(squares, 0, N * N);
    }
    board(const board& p) {
        squares = new uint8_t[N * N];
        std::memcpy(squares, p.squares, N * N);
    }
    ~board() {
        delete squares;
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
    board put(int x, int y) const {
        board p(*this);
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
                p.squares[(i)* N + (y - x + i)] = 1;
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
        p.squares[x * N + y] = 255;
        return p;
    }
};

void search(const board& p, int y) {
    if (y == N) {
        std::cout << p.to_string();
        exit(0);
    }
    for (int x = 0; x < N; x++) {
        if (p.squares[x * N + y] == 0) {
            search(p.put(x, y), y + 1);
        }
    }
}

int main() {
    board p;
    search(p, 0);
    return 0;
}
