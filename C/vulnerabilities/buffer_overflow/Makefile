CC=gcc
CFLAGS=-I. -Wall
COVERAGE_FLAGS=-fprofile-arcs -ftest-coverage -g
EXTRA_FLAGS=-fno-stack-protector

all: stack_buffer_overflow
	@echo "Building all"

stack_buffer_overflow: stack_buffer_overflow.c
	@echo "Building stack_buffer_overflow"
	rm -f stack_buffer_overflow.gcno stack_buffer_overflow.gcda
	$(CC) $(CFLAGS) $(COVERAGE_FLAGS) $(EXTRA_FLAGS) stack_buffer_overflow.c -o stack_buffer_overflow

clean:
	@echo "Cleaning all"
	rm -f stack_buffer_overflow stack_buffer_overflow.gcno stack_buffer_overflow.gcda
