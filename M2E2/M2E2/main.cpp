//written by Daniel Beckerich
//test recursion functions for exercise 5 from chapter 2.
#include <iostream>
#include <string>

using namespace std;

//first recursive function
string writebackwards(string str) {
	//base case.
	//if str has 1 char left, print it and return without another iteration
	if (str.length() == 1) {
		cout << str;
		return str;
	}
	else {
		//if there is more, print the next char and return another iteration
		cout << str.substr(str.length() - 1, 1);
		return writebackwards(str.substr(0, str.length() - 1));
	}

}

//void recursive function
void writebackwards2(string str) {
		//if str is empty, do nothing.
	if (str.length() == 0);
	else {
		//else, print the next char and iterate again.
		cout << str[str.length() - 1];
		writebackwards2(str.substr(0, str.length() - 1));
	}
}

int main() {

	//driver program
	string teststr;
	cout << "Enter a word to reverse: ";
	cin >> teststr;

	cout << "writebackwords: ";
	writebackwards(teststr);
	cout << "\n";

	cout << "writebackwords2: ";
	writebackwards2(teststr);
	cout << "\n";

	system("pause");
	return 0;
}