

#include <fstream>
#include <iostream>

#define LL_DEBUG 0x000001
#define LL_NORMAL 0x000010
#define LL_WARNING 0x000100
#define LL_ERROR 0x001000
#define LL_SCRIPT 0x010000
#define LL_ALL 0x011111

/*! The LogManager Prototype */

namespace ssuge {
	class LogManager {
	public:

		/*! The Constructor Prototype */
		LogManager(std::string name);

		/*! The Deconstructor Prototype */
		~LogManager();

		/*! The log Prototype */
		void log(std::string msg, unsigned int lvl = LL_NORMAL);

		/*! The setLogMask Prototype */
		void setLogMask(unsigned int lvl = LL_ALL);
	private:

		/*! The file that is opened for writing */
		std::ofstream mFile;

		/*! The log level that things are written to */
		unsigned int mLogLevel;
	};

}