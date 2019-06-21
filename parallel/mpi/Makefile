all: factorial

THREADS = 2

factorial: Makefile factorial.cpp
	mpicxx -o $@ factorial.cpp

clean:
	rm -f factorial

# Builder will call this to install the application before running.
install:
	echo "Installing is not supported"

# Builder uses this target to run your application.
run:
	mpiexec -np $(THREADS) ./factorial

