#include <stdio.h>
#include <omp.h>

#define SIZE 50					// A halmaz m�rete
#define MAX_ITERATION 10000		// Az iter�ci�k sz�ma

char mandelbrot_set[SIZE][SIZE];
int num_threads;

/**
A Mandelbrot-halmaz kisz�m�t�sa "pixelenk�nt".
*/
void calculate_mandelbrot_set()
{
	// A komplex s�kot a megadott m�ret alapj�n felosztjuk, �s ezeket vizsg�ljuk
	// Az X �s Y tengelyt felosztjuk a megadott m�ret alapj�n
	// iterateX, iterateY: mennyi t�vols�g van k�t pixel k�zt
	// cx, cy: komplex s�k val�s �s k�pzetes tengely�nek sz�m�rt�kei
	double iterateX = 3.5 / SIZE, iterateY = 2.0 / SIZE, cy = -1;
	int setX, setY;

#pragma omp parallel private(setX, setY)
	{
		num_threads = omp_get_num_threads();
		
#pragma omp for ordered
		for (setY = 0; setY < SIZE; setY++) {
			double cx = -2.5;

#pragma omp ordered
			for (setX = 0; setX < SIZE; setX++) {
				double x = 0.0, y = 0.0, xtemp = 0.0;
				int iteration = 0;

				// Iter�ci�, am�g az abszol�t�rt�k el nem �ri a 2^2-et vagy a hat�rt.
				while (x * x + y * y <= 4.0 && iteration < MAX_ITERATION)
				{
					xtemp = x * x - y * y + cx;
					y = 2 * x * y + cy;
					x = xtemp;
					iteration++;
				}

				// Ha el�rte a hat�rt, a halmaz adott elem�nek be�ll�tunk egy karaktert,
				// ellenkez� esetben sz�k�zt adunk meg.
				if (iteration == MAX_ITERATION) {
					mandelbrot_set[setX][setY] = '*';
				}
				else {
					mandelbrot_set[setX][setY] = ' ';
				}

				// k�vetkez� pont
				cx += iterateX;
			}

			cy += iterateY;
		}
	}
}

/**
A Mandelbrot-halmaz k�p�nek ki�rat�sa.
*/
void output_set() 
{
	int x, y;
	for (x = 0; x < SIZE; x++) {
		for (y = 0; y < SIZE; y++) {
			// A k�t tengelyt megcser�lve �ratjuk ki a halmaz k�p�t.
			printf("%c", mandelbrot_set[y][x]);
		}
		printf("\n");
	}
}

int main() 
{
	double start, end, diff;

	start = omp_get_wtime();
	calculate_mandelbrot_set();
	end = omp_get_wtime();
	diff = end - start;

	output_set();
	printf("A Mandelbrot-halmaz kiszamitasa %.5lf mp-et vett igenybe.\n", diff);
	printf("A program %d szalon futott.", num_threads);
	return 0;
}
