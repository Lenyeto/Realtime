

#include <fstream>
#include <iostream>

#define LL_DEBUG 0x000001
#define LL_NORMAL 0x000010
#define LL_WARNING 0x000100
#define LL_ERROR 0x001000
#define LL_SCRIPT 0x010000
#define LL_ALL 0x011111

namespace ssuge {
	class LogManager {
	public:
		LogManager(std::string name);
		~LogManager();
		void log(std::string msg, unsigned int lvl = LL_NORMAL);
		void setLogMask(unsigned int lvl = LL_ALL);
	private:
		std::ofstream mFile;
		unsigned int mLogLevel;
	};

}