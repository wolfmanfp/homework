cd Debug
if (!(Test-Path -path $Args[1])) {
  .\randomgen $Args[0] $Args[1]
}
.\hf1 $Args[0] $Args[1]
gc time.txt