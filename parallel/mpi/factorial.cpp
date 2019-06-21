#include <iostream>
using namespace std;

const int NUMBER = 20;

int main (int argc, char **argv)
{
    unsigned long long szorzat = 1;
    time_t time_start, time_end;

    srand(time(NULL));
    time_start = clock();
    for (int i = 1; i <= NUMBER; i++)
    {
        szorzat *= i;
    }
    time_end = clock();

    cout << "Eltelt ido: "
         << difftime(time_end, time_start) / CLOCKS_PER_SEC << " mp" << endl;
    cout << NUMBER << " faktorialisa: " << szorzat << "." << endl;
}
