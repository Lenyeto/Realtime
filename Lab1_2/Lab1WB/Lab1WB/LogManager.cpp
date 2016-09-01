#include "stdafx.h"
#include "LogManager.h"
#include <ctime>



namespace ssuge {
	LogManager::LogManager(std::string name) {
		std::ofstream mFile(name);
		mLogLevel = LL_NORMAL | LL_ERROR | LL_WARNING;
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

	}

	
}