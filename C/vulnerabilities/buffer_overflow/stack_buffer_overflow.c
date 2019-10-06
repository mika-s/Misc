#include <stdio.h>
#include <string.h>

int main(int argc, char *argv[]) {
    char password[] = "passw0rd";
    char buffer[9];
    gets(buffer);

    if(strcmp(buffer, password) == 0)
        printf("You are in!\n");
    else
        printf("Wrong password!\n");

    return 0;
}
