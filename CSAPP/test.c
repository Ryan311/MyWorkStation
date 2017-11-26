#include <stdio.h>
#include <stdlib.h>

char *gets(char *s)
{
    int c;
    char *dest = s;
    while ((c = getchar()) != '\n' && c != EOF)
    {
        *dest++ = c;
    }
    if (c == EOF && dest == s)
    {
        return NULL;
    }
    *dest++ = '\0';
    return s;
}

void echo()
{
    char buf[8];
    gets(buf);
}

int main(int argc, char **argv)
{
    echo();
}

