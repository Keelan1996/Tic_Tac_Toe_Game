#include<stdio.h>

void main()
{
	//Variables
	float value1 = 0;
	float value2 = 0;
	float add = 0;
	float subtract = 0;
	float multiple = 0;
	float divide = 0;
	char letter;

	// inputs
	printf("Please enter the letter A to add, S to subtract, M to multiple, and D to divide the two values\n");
	scanf("%c", &letter);

	printf("Please enter your first value \n");
	scanf("%f", &value1);

	printf("Please enter your second value \n");
	scanf("%f", &value2);


	// which calculation

	if ((letter == 'A') || (letter == 'a')) {

		add = value1 + value2;
		printf("Your Addition is: %.2f \n", add);
	}
	else if ((letter == 'S') || (letter == 's')) {

		subtract = value1 - value2;
		printf("Your subtraction is: %.2f \n", subtract);
	}
	else if ((letter == 'M') || (letter == 'm')) {

		multiple = value1 * value2;
		printf("Your multiplication is: %.2f \n", multiple);
	}
	else if ((letter == 'D') || (letter == 'd')) {

		divide = value1 / value2;
		printf("Your division is: %.2f \n", divide);
	}
	else {
		printf(" Your input was invaild so your result is -9999\n");
	}

}