#include <stdio.h>
#include <stdlib.h>

int main(int argc, char **argv)
{
  if (argc < 2) {
    printf("Kerem, adja meg a matrix meretet\n es a fajlnevet!\nPelda: randomgen 10000 matrix.txt");
    return 1;
  }

  int size = strtod(argv[1], NULL);
  FILE *testfile = fopen(argv[2], "w");

  for (int i = 0; i < size; i++)
  {
    for (int j = 0; j < size; j++)
    {
      double random = (double)rand() / (double)(RAND_MAX / 10);
      fprintf(testfile, "%.1f ", random);
    }
    fprintf(testfile, "\n");
  }

  fclose(testfile);
}
