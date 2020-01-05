/**
 * The program must read in an NxN matrix with floating point numbers. The program must determine
 * the index of columns, which contains one element that is equal to the average of the values in
 * the same column. The outputs are the indices of the columns.
 */

#include <stdio.h>
#include <stdlib.h>
#include <cuda.h>
#include <cuda_runtime.h>
#include "device_launch_parameters.h"

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

__global__ void findIndicesKernel(int size, double *vector, int *indices) {
  for (int col = 0; col < size; col++) {
    double sum = 0.0;
    for (int row = 0; row < size; row++) {
      sum += vector[col + row * size];
    }
    double avg = sum / size;

    indices[col] = -1;
    for (int row = 0; row < size; row++) {
      if (vector[col + row * size] == avg) {
        indices[col] = col;
        break;
      }
    }
  }
}

void printMeasuredTime(int size, double time) {
  FILE *fp = fopen("time.txt", "w");
  fprintf(fp, "%dx%d matrix: %.8lf s", size, size, time);
  fclose(fp);
}

int* findIndices(int size, double *vector) {
  int *indices, *device_indices;
  double *device_vector;
  size_t vector_size = size * size * sizeof(double);
  size_t indices_size = size * sizeof(int);

  cudaEvent_t start, end;
  cudaEventCreate(&start);
  cudaEventCreate(&end);

  indices = (int *)malloc(size * sizeof(int));
  cudaMalloc((void **)&device_vector, vector_size);
  cudaMalloc((void **)&device_indices, indices_size);
  cudaMemcpy(device_vector, vector, vector_size, cudaMemcpyHostToDevice);

  cudaEventRecord(start);
  findIndicesKernel<<<1, 1>>>(size, device_vector, device_indices);
  cudaEventRecord(end);

  cudaMemcpy(indices, device_indices, indices_size, cudaMemcpyDeviceToHost);
  cudaFree(device_vector);
  cudaFree(device_indices);

  cudaEventSynchronize(end);
  float milliseconds = 0;
  cudaEventElapsedTime(&milliseconds, start, end);
  printMeasuredTime(size, milliseconds / 1000);

  return indices;
}

void printResults(int size, int *indices) {
	FILE *fp = fopen("output.txt", "w");
  for (int i = 0; i < size; i++) {
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
  printResults(size, indices);

  free(vector);
  free(indices);
  return 0;
}