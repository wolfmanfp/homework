#include <stdio.h>
#include <time.h>

#define SIZE 50
#define MAX_ITERATION 10000

char mandelbrot_set[SIZE][SIZE];

void calculate_mandelbrot_set()
{
	double iterateX = 3.5 / SIZE, iterateY = 2.0 / SIZE;
	int setY = 0;

	for (double cy = -1; cy < 1; cy += iterateY) {
		int setX = 0;

		for (double cx = -2.5; cx < 1; cx += iterateX) {
			double x = 0.0, y = 0.0, xtemp = 0.0;
			int iteration = 0;

			while (x * x + y * y <= 4.0 && iteration < MAX_ITERATION)
			{
				xtemp = x * x - y * y + cx;
				y = 2 * x * y + cy;
				x = xtemp;
				iteration++;
			}

			if (iteration == MAX_ITERATION) {
				mandelbrot_set[setX][setY] = '*';
			}
			else {
				mandelbrot_set[setX][setY] = ' ';
			}
			
			setX++;
		}
		setY++;
	}
}

void output_set() {
	for (int x = 0; x < SIZE; x++) {
		for (int y = 0; y < SIZE; y++) {
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