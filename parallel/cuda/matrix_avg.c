/**
 * The program must read in an NxN matrix with floating point numbers. The program must determine
 * the index of columns, which contains one element that is equal to the average of the values in
 * the same column. The outputs are the indices of the columns.
 */

#include <stdio.h>
#include <stdlib.h>

double* readMatrix(int size, char *filename) {
	double *vector;

  FILE *fp = fopen(filename, "r");
	if (fp == NULL) {
		printf("A fajl nem talalhato!");
		exit(1);
	}

	vector = (double *) malloc(size * size * sizeof(double));
  int i = 0;
	while (fscanf(fp, "%lf ", &vector[i]) != EOF) {
		i++;
	}

	fclose(fp);
	return vector;
}

int* findIndices(int size, double *vector) {
  int *indices;
  double *averages;

  indices = (int *) malloc(size * sizeof(int));
  averages = (double *) malloc(size * sizeof(double));

  for (int col = 0; col < 5; col++) {
    double sum = 0.0;
    for (int row = 0; row < 5; row++) {
      sum += vector[col + row * 5];
    }
    averages[col] = sum / 5;

    indices[col] = -1;
    for (int row = 0; row < 5; row++) {
      if (vector[col + row * 5] == averages[col]) {
        indices[col] = col;
        break;
      }
    }
  }

  return indices;
}

void printResults(int *indices) {
	FILE *fp = fopen("output.txt", "w");
  for (int i = 0; i < 5; i++) {
    if (indices[i] != -1) {
      fprintf(fp, "%d ", indices[i]);
    }
  }
	fclose(fp);
}

int main(int argc, char **argv) {
  if (argc < 2) {
    printf("Kerem, adja meg a matrix meretet\n es az azt tartalmazo fajl\neleresi utvonalat!\nPelda: hf1 5 matrix.txt");
    return 1;
  }

  int size = strtod(argv[1], NULL);
  double *vector = readMatrix(size, argv[2]);
  int *indices = findIndices(size, vector);
  printResults(indices);

  return 0;
}