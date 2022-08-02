// Test C++ source code
#include <iostream>

namespace TestCode {
	public ref class TestCpp {
	public: const char* externalVar;

		  const char* getStr(System::String^ strng) {
			  System::IntPtr ip = System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(strng);
			  return static_cast<const char*>(ip.ToPointer());
		  }

	public: void setVar(System::String^ text) {
		externalVar = TestCpp::getStr(text);
	}

	public: void doStuff(System::String^ msg) {
		std::cout << TestCpp::getStr(msg) << std::endl;
	}

	public: int Main() {
		std::cout << "Hello World, from C++!" << std::endl;
		std::cout << externalVar << std::endl;
		TestCpp::doStuff("Internal Call to Method");
		return 0;
	}

	};
}

int main() {
	TestCode::TestCpp test;
	return test.Main();	
}

