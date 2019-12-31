#!/bin/sh
if [ ! -f $2 ]; then
  randomgen $1 $2
fi
hf1 $1 $2
cat time.txt
