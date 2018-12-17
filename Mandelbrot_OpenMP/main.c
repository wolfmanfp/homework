#include <stdio.h>
#include <time.h>

#define SIZE 50					// A halmaz m�rete
#define MAX_ITERATION 100		// Az iter�ci�k sz�ma

char mandelbrot_set[SIZE][SIZE];

/**
A Mandelbrot-halmaz kisz�m�t�sa "pixelenk�nt".
*/
void calculate_mandelbrot_set()
{
	// A komplex s�kot a megadott m�ret alapj�n felosztjuk, �s ezeket vizsg�ljuk
	// Az X �s Y tengelyt felosztjuk a megadott m�ret alapj�n
	// iterateX, iterateY: mennyi t�vols�g van k�t pixel k�zt
	double iterateX = 3.5 / SIZE, iterateY = 2.0 / SIZE;
	int setY = 0;

	// cx, cy: komplex s�k val�s �s k�pzetes tengely�nek sz�m�rt�kei
	for (double cy = -1; cy < 1; cy += iterateY) {
		int setX = 0;

		for (double cx = -2.5; cx < 1; cx += iterateX) {
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
			
			// k�vetkez� oszlop
			setX++;
		}

		// k�vetkez� sor
		setY++;
	}
}

/**
A Mandelbrot-halmaz k�p�nek ki�rat�sa.
*/
void output_set() {
	for (int x = 0; x < SIZE; x++) {
		for (int y = 0; y < SIZE; y++) {
			// A k�t tengelyt megcser�lve �ratjuk ki a halmaz k�p�t.
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