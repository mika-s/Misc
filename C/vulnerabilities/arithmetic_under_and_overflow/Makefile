CC=gcc
CFLAGS=-I. -Wall
COVERAGE_FLAGS=-fprofile-arcs -ftest-coverage -g
EXTRA_FLAGS=

all: integer_overflow integer_underflow
	@echo "Building all"

integer_overflow: integer_overflow.c
	@echo "Building integer_overflow"
	rm -f integer_overflow.gcno integer_overflow.gcda
	$(CC) $(CFLAGS) $(COVERAGE_FLAGS) $(EXTRA_FLAGS) integer_overflow.c -o integer_overflow

integer_underflow: integer_underflow.c
	@echo "Building integer_underflow"
	rm -f integer_underflow.gcno integer_underflow.gcda
	$(CC) $(CFLAGS) $(COVERAGE_FLAGS) $(EXTRA_FLAGS) integer_underflow.c -o integer_underflow

clean:
	@echo "Cleaning all"
	rm -f integer_underflow integer_underflow.gcno integer_underflow.gcda
	rm -f integer_overflow integer_overflow.gcno integer_overflow.gcda
