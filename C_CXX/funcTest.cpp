#include <iostream>
using namespace std;

template<typename T1, typename T2>
void gt(T1 x, T2 y)
{
    decltype(x+y) xpy = x+y;
    cout << xpy << endl;
}

template<typename T3, typename T4>
auto gd(T3 x, T4 y) -> decltype(x + y)
{
    return x + y;
}

int main()
{
    int x = 3, y = 4;
    gt(x, y);
    double d1 = 3.33, d2 = 4.44;
    gt(d1, d2);

    cout << gd(x, y) << endl;
    cout << gd(d1, d2) << endl;
}
