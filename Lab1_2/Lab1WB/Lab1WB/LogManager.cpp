#include "stdafx.h"
#include "LogManager.h"
#include <ctime>
#include <string>


namespace ssuge {
	LogManager::LogManager(std::string name) {
		mFile = std::ofstream(name);
		mLogLevel = LL_NORMAL | LL_ERROR | LL_WARNING | LL_DEBUG;
	}

	LogManager::~LogManager() {
		mFile.close();
	}

	void LogManager::log(std::string msg, unsigned int lvl) {
		

		if (mLogLevel & lvl) {
			time_t t;
			tm *time_info;
			time(&t);

			time_info = localtime(&t);

			mFile << "[" << time_info->tm_mon << "/" << time_info->tm_mday << "/" << time_info->tm_year << "@" << time_info->tm_hour << ":" << time_info->tm_min << ":" << time_info->tm_sec << "]";
			
			if (lvl == LL_NORMAL) {
				;
			}
			else if (lvl == LL_DEBUG) {
				mFile << "[DEBUG]";
			}
			else if (lvl == LL_WARNING) {
				mFile << "[WARNING]";
			}
			else if (lvl == LL_SCRIPT) {
				mFile << "[SCRIPT]";
			}
			else if (lvl == LL_ERROR) {
				mFile << "[ERROR]";
			}
			mFile << msg << std::endl;
		}
	}

	void LogManager::setLogMask(unsigned int lvl) {
		mLogLevel = lvl;
	}

	
}