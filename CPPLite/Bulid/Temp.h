int __stdcall DllMain(void*, unsigned long, void*) {return 1;}


#define function extern "C" __declspec(dllexport) void


typedef void (__stdcall *FN_PRINT)(const char*);
FN_PRINT _fPrint;


using namespace std;

void Print(const char* format, ...)
{
	char buf[1024];

	va_list argptr;
	va_start(argptr, format);
	vsprintf(buf, format, argptr);
	va_end(argptr);

	_fPrint(buf);
}

void Print(string& format, ...)
{
	char buf[1024];

	va_list argptr;
	va_start(argptr, format);
	vsprintf(buf, format.c_str(), argptr);
	va_end(argptr);

	_fPrint(buf);
}


function Config(FN_PRINT fPrint)
{
	_fPrint = fPrint;
}
