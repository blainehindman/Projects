#include "Header.h"

void String_To_Stack()
{
	string User_Input;
	char Current_Char;
	stack <char> NewStack;
	cout << "Enter Your String:" << endl;
	cin >> User_Input;
	cout << "" << endl;

	cout << "Stack:" << endl;
	for (int i = 0; i <= User_Input.length(); i++)
	{
		Current_Char = User_Input[i];
		NewStack.push(Current_Char);
	}
	//Print in reverse to show first-in first-out
	for (int j = User_Input.length(); j >= 0; j--)
	{
		Current_Char = User_Input[j];
		cout << Current_Char << endl;
	}
}

void String_To_Queue()
{
	string User_Input;
	char Current_Char;
	queue <char> NewQueue;
	cout << "Enter Your String:" << endl;
	cin >> User_Input;
	cout << "" << endl;

	cout << "Queue:" << endl;
	for (int i = 0; i <= User_Input.length(); i++)
	{
		Current_Char = User_Input[i];
		NewQueue.push(Current_Char);
		cout << Current_Char;
		cout << " ";
	}
	cout << "" << endl;
}

void Menu()
{
	while (1)
	{
		string Menu_Choice;
		cout << "Enter Menu Function:" << endl;
		cin >> Menu_Choice;
		cout << "" << endl;

		if (Menu_Choice == "String_To_Stack")
		{
			String_To_Stack();
		}

		if (Menu_Choice == "String_To_Queue")
		{
			String_To_Queue();
		}
	}
}

int main() {
	Menu();
} 

