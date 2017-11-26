#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define BITSPERWORD 32
#define SHIFT 5
#define MASK 0x1F
#define N 100

int a[1 + N / BITSPERWORD] = { 0 };

void set(int i)
{
    a[i >> SHIFT] |= (1 << (i & MASK));
}

void clr(int i)
{
    a[i >> SHIFT] &= ~(1 << (i & MASK));
}

int test(int i)
{
    return a[i >> SHIFT] & (1 << (i & MASK));
}

int main(void)
{
    long num = 0;
    srand((unsigned)time(NULL));
    for (int i = 0; i < N / 2; i++)
    {
        num = rand() % N;
        set(num);
        printf("%ld ", num);
    }


    printf("\nsort result: %ld", num);
    for (int i = 0; i < N; i++)
    {
        if (test(i))
        {
            printf("%d ", i);
        }
    }
    return 0;
}
