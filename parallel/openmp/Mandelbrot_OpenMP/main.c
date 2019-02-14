#include <stdio.h>
#include <omp.h>

#define SIZE 50					// A halmaz mérete
#define MAX_ITERATION 10000		// Az iterációk száma

char mandelbrot_set[SIZE][SIZE];
int num_threads;

/**
A Mandelbrot-halmaz kiszámítása "pixelenként".
*/
void calculate_mandelbrot_set()
{
	// A komplex síkot a megadott méret alapján felosztjuk, és ezeket vizsgáljuk
	// Az X és Y tengelyt felosztjuk a megadott méret alapján
	// iterateX, iterateY: mennyi távolság van két pixel közt
	// cx, cy: komplex sík valós és képzetes tengelyének számértékei
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

				// Iteráció, amíg az abszolútérték el nem éri a 2^2-et vagy a határt.
				while (x * x + y * y <= 4.0 && iteration < MAX_ITERATION)
				{
					xtemp = x * x - y * y + cx;
					y = 2 * x * y + cy;
					x = xtemp;
					iteration++;
				}

				// Ha elérte a határt, a halmaz adott elemének beállítunk egy karaktert,
				// ellenkezõ esetben szóközt adunk meg.
				if (iteration == MAX_ITERATION) {
					mandelbrot_set[setX][setY] = '*';
				}
				else {
					mandelbrot_set[setX][setY] = ' ';
				}

				// következõ pont
				cx += iterateX;
			}

			cy += iterateY;
		}
	}
}

/**
A Mandelbrot-halmaz képének kiíratása.
*/
void output_set() 
{
	int x, y;
	for (x = 0; x < SIZE; x++) {
		for (y = 0; y < SIZE; y++) {
			// A két tengelyt megcserélve íratjuk ki a halmaz képét.
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
