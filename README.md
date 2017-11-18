# n-queens

- Intel(R) Core(TM)2 Duo CPU     L9400  @ 1.86GHz
- gcc version 6.3.0 20170516 (Debian 6.3.0-18)
- clang version 3.8.1-24 (tags/RELEASE_381/final)
- Mono JIT compiler version 4.6.2 (Debian 4.6.2.7+dfsg-1)
- openjdk version "1.8.0_151"

~~~
$ make time
time ./nq1gcc > /dev/null

real    0m14.069s
user    0m14.052s
sys     0m0.000s
time ./nq2gcc > /dev/null

real    0m20.619s
user    0m20.604s
sys     0m0.000s
time ./nq3gcc > /dev/null

real    0m18.982s
user    0m18.972s
sys     0m0.000s
time ./nq4gcc > /dev/null

real    0m26.105s
user    0m26.096s
sys     0m0.000s
time ./nq1clang > /dev/null

real    0m11.562s
user    0m11.552s
sys     0m0.000s
time ./nq2clang > /dev/null

real    0m17.397s
user    0m17.384s
sys     0m0.000s
time ./nq3clang > /dev/null

real    0m15.896s
user    0m15.884s
sys     0m0.000s
time ./nq4clang > /dev/null

real    0m20.650s
user    0m20.628s
sys     0m0.000s
time mono ./nq5mcs.exe > /dev/null

real    0m48.663s
user    0m47.932s
sys     0m0.724s
time mono ./nq6mcs.exe > /dev/null

real    0m54.221s
user    0m54.176s
sys     0m0.016s
time java Nq7 > /dev/null

real    0m42.503s
user    0m42.240s
sys     0m0.408s
time java Nq8 > /dev/null

real    0m33.615s
user    0m33.712s
sys     0m0.048s
~~~
