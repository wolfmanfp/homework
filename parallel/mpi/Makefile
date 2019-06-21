all: factorial

WARNINGS = -Wall
DEBUG = -ggdb -fno-omit-frame-pointer
OPTIMIZE = -O2

factorial: Makefile factorial.c
	$(CC) -o $@ $(WARNINGS) $(DEBUG) $(OPTIMIZE) factorial.c

clean:
	rm -f factorial

# Builder will call this to install the application before running.
install:
	echo "Installing is not supported"

# Builder uses this target to run your application.
run:
	./factorial

