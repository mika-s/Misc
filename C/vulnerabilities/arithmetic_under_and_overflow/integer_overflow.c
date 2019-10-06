#include <stdio.h>

int main(int argc, char *argv[]) {
    unsigned int close_to_max = 4294967295;

    close_to_max += 1;

    printf("close_to_max = %u\n", close_to_max);

    return 0;
}
