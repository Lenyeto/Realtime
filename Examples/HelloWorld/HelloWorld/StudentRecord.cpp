#include "stdafx.h"
#include "StudentRecord.h"
#include <iostream>

SchoolData::StudentRecord::StudentRecord(string n, unsigned int i, float b) :
	mName(n), mID(i), mBalance(b)
{
	std::cout << "In StudentRecord constructor" << std::endl;
}

SchoolData::StudentRecord::~StudentRecord() {
	std::cout << "In StudentRecord destructor" << std::endl;
}

std::string SchoolData::StudentRecord::getName() {
	return mName;
}