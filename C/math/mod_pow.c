#include <stdio.h>

/*
A function for calculating expressions on the following form: a^b * mod n.

a^b can get very large, larger than long long. This function can be used to
handle such cases.

https://archive.org/details/Applied_Cryptography_2nd_ed._B._Schneier
*/

int mod_pow(int base, int exponent, int modulus) {
    if(modulus == 1) return 0;
    
    int result = 1;
    base = base % modulus;
    
    while(exponent > 0)
    {
        if(exponent % 2 == 1)
            result = (result * base) % modulus;
        
        exponent = exponent >> 1;
        base = (base * base) % modulus;
    }
    
    return result;
} 
    
int main()
{
    int result1 = mod_pow(34, 12, 54);
    int result2 = mod_pow(21, 55, 23);

    printf("result1 = %d, result2 = %d\n", result1, result2);

    return 0;
}



