// HelloWorld.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <vector>
#include <map>
#include <string>
#include "StudentRecord.cpp"

std::vector<SchoolData::StudentRecord*> mvec;

void addNew() {
	std::string name;
	unsigned int age;
	float balance;
	char confirm;

	std::cout << "Hello, World!" << std::endl;

	std::cout << "Enter your name: ";
	std::cin >> name;

	std::cout << "Enter your age: ";
	std::cin >> age;

	mvec.push_back(new SchoolData::StudentRecord(name, age, 0));
}

int main()
{


	while (true) {
		std::string cmd;
		std::cout << "Command (Add, List, Quit):";
		std::cin >> cmd;

		if (cmd.compare("Add")) {
			addNew();
		}
		else if (cmd.compare("List")) {
			std::vector<SchoolData::StudentRecord*>::iterator iter;
			for (unsigned int i = 0; i < mvec.size(); i++) {
				cout << mvec[i]->getName();
			}
			
			for (; iter != mvec.end(); ++iter) {
				
			}
		}
		else if (cmd.compare("Quit")) {

		}


	}

	std::vector<SchoolData::StudentRecord*>::iterator iter;
	for (; iter != mvec.end(); ++iter) {

	}

    return 0;
}
