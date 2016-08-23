
#include <string>
using namespace std;

namespace SchoolData
{

	class StudentRecord {
	protected:
		string mName;
		unsigned int mID;
		float mBalance;

	public:
		StudentRecord(string n, unsigned int i, float b);
		~StudentRecord();
		string getName();
	};

	

}