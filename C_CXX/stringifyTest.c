#include <stdio.h>
#include <stdlib.h>

#define __stringify__1(x) #x
#define __stringify(x) __stringify__1(x)
#define FOO bar

int main()
{
    printf(__stringify(FOO));
    printf("\n");
    printf(__stringify__1(FOO));
}
