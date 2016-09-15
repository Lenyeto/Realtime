
#include "LogManager.h"
#include <ctime>
#include <string>

/*! The LogManager Definitions */

namespace ssuge {

	/*! The LogManager Constructor */
	LogManager::LogManager(std::string name) {
		mFile = std::ofstream(name);
		mLogLevel = LL_NORMAL | LL_ERROR | LL_WARNING | LL_DEBUG;
	}

	/*! The LogManager Deconstructor */
	LogManager::~LogManager() {
		mFile.close();
	}


	/*! The log function */
	void LogManager::log(std::string msg, unsigned int lvl) {
		

		if (mLogLevel & lvl) {
			time_t t;
			tm *time_info;
			time(&t);

			time_info = localtime(&t);

			mFile << "[" << time_info->tm_mon << "/" << time_info->tm_mday << "/" << time_info->tm_year + 1900 << "@" << time_info->tm_hour << ":" << time_info->tm_min << ":" << time_info->tm_sec << "]";
			
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

	/*! The setLogMask function to set what log level the log is showing */
	void LogManager::setLogMask(unsigned int lvl) {
		mLogLevel = lvl;
	}

	
}