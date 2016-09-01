// Lab1WB.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "LogManager.h"

int main()
{
	ssuge::LogManager LM("test_log.txt");
	LM.log("message A");
	LM.log("message B", LL_DEBUG);
	LM.setLogMask(LL_NORMAL | LL_SCRIPT);
	LM.log("message C");
	LM.log("message D", LL_SCRIPT);
	LM.log("message E", LL_DEBUG);
	LM.setLogMask();
	LM.log("message F", LL_DEBUG);

    return 0;
}

