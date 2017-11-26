#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef void *Mutex_t;

void printArray(char *m, int len)
{
    int i;
    for (i = 0; i < len; i++)
    {
        printf("%d ", m[i]);
    }
}

int main(void)
{
    Mutex_t m;
    m = malloc(10);
    memset(m, 1, 10);
    printArray(m, 10);
    free(m);
    return 0;
}

