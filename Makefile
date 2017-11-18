SHELL=/bin/bash

all: nq1gcc nq2gcc nq3gcc nq4gcc nq1clang nq2clang nq3clang nq4clang nq5mcs.exe nq6mcs.exe Nq7.class Nq8.class

nq1gcc: nq1.cpp
	g++ -std=c++11 -O4 -o $@ $^
nq2gcc: nq2.cpp
	g++ -std=c++11 -O4 -o $@ $^
nq3gcc: nq3.cpp
	g++ -std=c++11 -O4 -o $@ $^
nq4gcc: nq4.cpp
	g++ -std=c++11 -O4 -o $@ $^

nq1clang: nq1.cpp
	clang++ -std=c++11 -O3 -o $@ $^
nq2clang: nq2.cpp
	clang++ -std=c++11 -O3 -o $@ $^
nq3clang: nq3.cpp
	clang++ -std=c++11 -O3 -o $@ $^
nq4clang: nq4.cpp
	clang++ -std=c++11 -O3 -o $@ $^

nq5mcs.exe: nq5.cs
	mcs -o+ -out:$@ $^
nq6mcs.exe: nq6.cs
	mcs -o+ -out:$@ $^

Nq7.class: Nq7.java
	javac $^
Nq8.class: Nq8.java
	javac $^

time:
	time ./nq1gcc > /dev/null
	time ./nq2gcc > /dev/null
	time ./nq3gcc > /dev/null
	time ./nq4gcc > /dev/null
	time ./nq1clang > /dev/null
	time ./nq2clang > /dev/null
	time ./nq3clang > /dev/null
	time ./nq4clang > /dev/null
	time mono ./nq5mcs.exe > /dev/null
	time mono ./nq6mcs.exe > /dev/null
	time java Nq7 > /dev/null
	time java Nq8 > /dev/null
