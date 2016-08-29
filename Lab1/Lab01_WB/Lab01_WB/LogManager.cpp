
#include "LogManager.h"
#include <ctime>

namespace ssuge {
	LogManager::LogManager(std::string name) {
		std::ofstream mFile(name);

	}
	
	LogManager::~LogManager() {
		mFile.close();
	}

	void LogManager::log(std::string msg, unsigned int lvl) {
		if (lvl && mLogLevel) {
			mFile << msg.c_str() << std::endl;
		}
	}

	void LogManager::setLogMask(unsigned int lvl) {
		mLogLevel = lvl;
	}

	char* getTimeString(const struct tm *timeptr) {
		static char result[19];
		//result[0] = timeptr->tm_wday;
		return result;
	}
}
