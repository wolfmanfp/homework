#include <iostream>
#include <openmpi/mpi.h>
using namespace std;

const int MASTER = 0;
const int NUMBER = 20;

int main (int argc, char **argv)
{
    unsigned long long resz_szorzat = 1, szorzat = 1;
    int id, nproc;
    time_t time_start, time_end;

    srand(time(NULL));
    MPI_Init(&argc, &argv);
    MPI_Status status;
    MPI_Comm_rank(MPI_COMM_WORLD, &id);
    MPI_Comm_size(MPI_COMM_WORLD, &nproc);

    if (id == MASTER) {
        time_start = clock();
    }

    for (int i = 1 + id; i <= NUMBER; i += nproc) // loop splitting
    {
        szorzat *= i; // node részszorzata
    }

    if (id == MASTER) { // a master összegyűjti a részszorzatokat
        for (int j = 1; j < nproc; j++)
        {
            MPI_Recv(&resz_szorzat, 1, MPI_INT, MPI_ANY_SOURCE, 1, MPI_COMM_WORLD, &status);
            szorzat *= resz_szorzat;
        }
        time_end = clock();
    } else { // slave-ek elküldik a részszorzatot
        MPI_Send(&szorzat, 1, MPI_INT, 0, 1, MPI_COMM_WORLD);
    }
    
    if (id == MASTER) 
    {
        cout << "Eltelt ido: "
             << difftime(time_end, time_start) / CLOCKS_PER_SEC << " mp" << endl;
        cout << NUMBER << " faktorialisa: " << szorzat << "." << endl;
    }
    MPI_Finalize();
}
