#include <iostream>
#include <string>
#include <cstring>
#include <array>
#include <vector>

using namespace std;
int main()
{
    short tell[10] = {0};
    cout << tell << endl;
    cout << &tell << endl;

    cout << tell + 1 << endl;
    cout << &tell + 1 << endl;

    int as[5] {5, 4, 3, 2,  1};
    array<int, 5> ai = {1, 2, 3, 4, 5};
    cout << "as = " << as << endl;
    cout << "&as + 1 = " << &as + 1 << endl;
    cout << "ai = " << ai[2] << endl;
    cout << "&ai[2] = " << &ai[2] << endl;
    cout << ai[1] << endl;
}
