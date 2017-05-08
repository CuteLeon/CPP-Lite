@cd /d "%~dp0"

@cl.exe /nologo /MT /O2 /GX /Yu"stdafx.h" /Fp"MyDLL.pch" ../Bulid/Temp.cpp /c /D WIN32 /D NDEBUG /D _WINDOWS /D _MBCS /D _USRDLL > ../Bulid/ret.txt