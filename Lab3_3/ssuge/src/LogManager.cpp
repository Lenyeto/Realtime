#include "stdafx.h"
#include "logManager.h"
#include <string>
#include <ctime>


void ssuge::LogManager::log(std::string message, unsigned short flag)
	
{
	if ((flag & mLogLevel) != 0) {
		
		
		time_t rawtime;
		struct tm info;
		char buffer[22];
		time(&rawtime);
		localtime_s(&info,&rawtime);
		//Puts the time into the char list with this format: [mm/dd/yyyy@hr:min:sec]
		strftime(buffer, 22, "[%x@%X] ", &info);

		mFile << buffer;

		if (flag == LL_NORMAL) 
		{
			;
		} else if (flag == LL_DEBUG) 
		{

			mFile << "[DEBUG] ";

		}
		else if(flag == LL_WARNING) 
		{

			mFile << "[WARNING] ";

		}
		else if (flag == LL_ERROR) 
		{

			mFile << "[ERROR] ";
		}
		else if (flag == LL_SCRIPT)
		{

			mFile << "[SCRIPT] ";

		}
		
		mFile << message << std::endl;	

	}
	
}
