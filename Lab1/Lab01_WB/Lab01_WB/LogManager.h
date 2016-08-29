#pragma once

#include <fstream>
#include <iostream>

#define LL_DEBUG 1
#define LL_NORMAL 2
#define LL_WARNING 4
#define LL_ERROR 8
#define LL_SCRIPT 16
#define LL_ALL 31

namespace ssuge {


class LogManager {
public:
	LogManager(std::string name);
	~LogManager();
	void log(std::string msg, unsigned int lvl);
	void setLogMask(unsigned int lvl);
private:
	std::ofstream mFile;
	unsigned int mLogLevel;

};


}