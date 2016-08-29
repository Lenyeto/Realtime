
#include "LogManager.cpp"



int main() {
	ssuge::LogManager LM("text_log.txt");
	LM.log("message A", LL_NORMAL);
	LM.log("message B", LL_DEBUG);
	LM.setLogMask(LL_NORMAL | LL_SCRIPT);
	LM.log("message C", LL_NORMAL);
	LM.log("message D", LL_SCRIPT);
	LM.log("message E", LL_DEBUG);
	LM.setLogMask(LL_ALL);
	LM.log("message F", LL_DEBUG);


	return 0;
}