#include <stdio.h>

/*
    Set a bit:      bit_fld |=  (1 << n)
    Clear a bit:    bit_fld &= ~(1 << n)
    Toggle a bit:   bit_fld ^=  (1 << n)
    Test a bit:     bit_fld  &  (1 << n)
*/

int main()
{
    // Ignoring endianess.

    unsigned int i = 0;
    printf("Initial:\t\t%d\n", i);
    // 0000 0000 0000 0000 0000 0000 0000 0000

    // Set first bit.           i = 1
    // 0000 0000 0000 0000 0000 0000 0000 0001

    i |= (1U << 0);
    printf("i |=  (1U << 0):\t\t%u\n", i);

    // Set the second bit too.  i = 3
    // 0000 0000 0000 0000 0000 0000 0000 0011

    i |= (1U << 1);
    printf("i |=  (1U << 1):\t\t%u\n", i);

    // Clear the first bit.     i = 2
    // 0000 0000 0000 0000 0000 0000 0000 0010

    i &= ~(1U << 0);
    printf("i &= ~(1U << 0):\t\t%u\n", i);

    // Toggle the third bit.    i = 6
    // 0000 0000 0000 0000 0000 0000 0000 0110

    i ^= (1U << 2);
    printf("i ^=  (1U << 2):\t\t%u\n", i);

    /*******************************/

    printf("\n\n\n");

    // Set both first and second bit without using a variable.
    printf("(1U << 14) | (1U << 15):\t%d\n", (1U << 1) | (1U << 0));

    return 0;
}
