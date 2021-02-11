#include <stdio.h>

//function to print the sum of A1
int sum_ext(int A1)
{
   //porint the sum of A1
   printf("%d\n", A1);
}

//Sum Function
int sum(int A0, int A1)
{
   //Loop, while A0 does not equal to 0
   while(A0 != 0)
   {
      //Add A1 and A0, set to A1
      A1 = A1 + A0;
      //subtract A0 -1, set to A0
      A0 = A0 - 1;
      //Loop again
   }
   //when A0 = 0, then call the sum_ext functio
   //passing variable (A1)
   sum_ext(A1);
}

//Main function
int main() {
   //Initialize variables A0 and A1 to last 2
   //digits of student ID, 8 and 8
   int A0 = 8;
   int A1 = 8;
   //call the sum function, while passing 
   //variables A0 and A1
   sum(A0, A1);

   return 0;
}