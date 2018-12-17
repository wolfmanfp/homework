#include <stdio.h>
#include <time.h>

#define SIZE 50					// A halmaz mérete
#define MAX_ITERATION 100		// Az iterációk száma

char mandelbrot_set[SIZE][SIZE];

/**
A Mandelbrot-halmaz kiszámítása "pixelenként".
*/
void calculate_mandelbrot_set()
{
	// A komplex síkot a megadott méret alapján felosztjuk, és ezeket vizsgáljuk
	// Az X és Y tengelyt felosztjuk a megadott méret alapján
	// iterateX, iterateY: mennyi távolság van két pixel közt
	double iterateX = 3.5 / SIZE, iterateY = 2.0 / SIZE;
	int setY = 0;

	// cx, cy: komplex sík valós és képzetes tengelyének számértékei
	for (double cy = -1; cy < 1; cy += iterateY) {
		int setX = 0;

		for (double cx = -2.5; cx < 1; cx += iterateX) {
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
			
			// következõ oszlop
			setX++;
		}

		// következõ sor
		setY++;
	}
}

/**
A Mandelbrot-halmaz képének kiíratása.
*/
void output_set() {
	for (int x = 0; x < SIZE; x++) {
		for (int y = 0; y < SIZE; y++) {
			// A két tengelyt megcserélve íratjuk ki a halmaz képét.
			printf("%c", mandelbrot_set[y][x]);
		}
		printf("\n");
	}
}

int main() 
{
	clock_t start, end;
	double diff;

	start = clock();
	calculate_mandelbrot_set();
	end = clock();
	diff = ((double) end - start) / CLOCKS_PER_SEC;

	output_set();
	printf("A Mandelbrot-halmaz kiszamitasa %.5lf mp-et vett igenybe.\n", diff);
	return 0;
}