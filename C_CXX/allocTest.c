#include <stdlib.h>
#include <stdio.h>

int *bufAlloc(void)
{
    int *p;
    p = (int *)malloc(sizeof(int) * 10);
    printf(" p = %p\n", p);
    return p;
}

int main(int argc, char **argv)
{
    int *p = NULL;
    p = bufAlloc();
    printf("p = %p\n", p);
    free(p);
    return 0;
}


