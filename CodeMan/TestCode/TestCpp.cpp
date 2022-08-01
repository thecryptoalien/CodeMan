#include <iostream>
#include <string>

using namespace std;
using namespace System;
using namespace System::Runtime::InteropServices;

const char* externalVar;

const char* getStr(String^ strng) {
    IntPtr ip = Marshal::StringToHGlobalAnsi(strng);
    return static_cast<const char*>(ip.ToPointer());
}

void setVar(String^ text) {
    externalVar = getStr(text);
}

void doStuff(String^ msg) {
    cout << getStr(msg) << endl;
}

int main() {
    cout << "Hello World, from C++!" << endl;
    cout << externalVar << endl;
    doStuff("Internal Call to Function");
    return 0;
}

