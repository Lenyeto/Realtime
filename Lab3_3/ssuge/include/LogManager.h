#ifndef _LOGMANAGER_H_
#define _LOGMANAGER_H_

#define LL_DEBUG 0x0001
#define LL_NORMAL 0x0002
#define LL_WARNING 0x0004
#define LL_ERROR 0x0008
#define LL_SCRIPT 0x0010
#include <fstream>

namespace ssuge
{

	///Class for creating messages and writing them to a file
	class LogManager 
	{
	// @@@@@ member variables @@@@@ //
	protected:
		/// An ofstream file where message logs will be written
		std::ofstream mFile;

		/// An unsigned short int indicating what log-level messages to allow
		unsigned short mLogLevel;
	
	// @@@@@ constructors @@@@@ //
	public:
		///Will create a log manager and open a file to log our messages
		LogManager(std::string filename):mFile(filename) { setLogMask(); };

	// @@@@@ deconstructors @@@@@ //
	public:
		///Closses the opened file
		~LogManager() { mFile.close(); };
	
	// @@@@@ methods @@@@@ //
	public:
		///Changes the log mask. Future log calls will only be written to the file if they are one of these log levels.
		void setLogMask(unsigned short flags = 0x001F) { mLogLevel = flags; };

		/// Takes a string to write to the specifed log level. The level defaults to LL_NORMAL.
		void log(std::string message, unsigned short flag = LL_NORMAL);

	};


}
#endif // _LOGMANAGER_H_